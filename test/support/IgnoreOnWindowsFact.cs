using System.Runtime.InteropServices;
using Xunit;

public sealed class IgnoreOnWindowsFact : FactAttribute
{
    public IgnoreOnWindowsFact() {
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            Skip = "Ignore on Windows";
        }
    }    
}
