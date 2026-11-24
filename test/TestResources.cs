using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestResources
  {
    // Many locales have no AM/PM markers of their own and fall back to the English ones.
    private static readonly string[] OptionalKeys = { "AMPeriod", "PMPeriod" };

    [Fact]
    public void TestEveryLocaleTranslatesEveryKey()
    {
      Assembly assembly = typeof(ExpressionDescriptor).Assembly;
      var resourceManager = new ResourceManager("CronExpressionDescriptor.Resources", assembly);
      string[] requiredKeys = GetKeys(resourceManager, CultureInfo.InvariantCulture).Except(OptionalKeys).ToArray();

      string[] locales = Directory.GetDirectories(Path.GetDirectoryName(assembly.Location))
          .Where(dir => File.Exists(Path.Combine(dir, "CronExpressionDescriptor.resources.dll")))
          .Select(Path.GetFileName)
          .ToArray();
      Assert.NotEmpty(locales);

      foreach (string locale in locales)
      {
        string[] missingKeys = requiredKeys.Except(GetKeys(resourceManager, new CultureInfo(locale))).ToArray();
        Assert.True(missingKeys.Length == 0, $"{locale} is missing: {string.Join(", ", missingKeys)}");
      }
    }

    private static string[] GetKeys(ResourceManager resourceManager, CultureInfo culture)
    {
      return resourceManager.GetResourceSet(culture, true, false)
          .Cast<DictionaryEntry>()
          .Select(entry => (string)entry.Key)
          .ToArray();
    }
  }
}
