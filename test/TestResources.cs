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

      foreach (string locale in GetLocales())
      {
        string[] missingKeys = requiredKeys.Except(GetKeys(resourceManager, new CultureInfo(locale))).ToArray();
        Assert.True(missingKeys.Length == 0, $"{locale} is missing: {string.Join(", ", missingKeys)}");
      }
    }

    [Fact]
    public void TestEveryLocaleIsListedInReadmeAndDemo()
    {
      string root = Path.GetDirectoryName(typeof(TestResources).Assembly.Location);
      while (!File.Exists(Path.Combine(root, "CronExpressionDescriptor.sln")))
      {
        root = Path.GetDirectoryName(root);
      }
      string readme = File.ReadAllText(Path.Combine(root, "README.md"));
      string demo = File.ReadAllText(Path.Combine(root, "demo", "Pages", "Index.razor"));

      foreach (string locale in GetLocales())
      {
        Assert.True(readme.Contains($"| `{locale}`"), $"{locale} is missing from the README language table");
        Assert.True(demo.Contains($"(\"{locale}\","), $"{locale} is missing from the demo language list");
      }
    }

    private static string[] GetLocales()
    {
      string[] locales = Directory.GetDirectories(Path.GetDirectoryName(typeof(ExpressionDescriptor).Assembly.Location))
          .Where(dir => File.Exists(Path.Combine(dir, "CronExpressionDescriptor.resources.dll")))
          .Select(Path.GetFileName)
          .ToArray();
      Assert.NotEmpty(locales);
      return locales;
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
