using System.Runtime.InteropServices;
using XPdfSharp.Enum;

namespace XPdfSharp.Implementation.Utils
{
    public static class RuntimeInfo
    {
        public static Platform OsEnvironment()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Platform.Windows;
            
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? Platform.Linux : Platform.Unknown;
        }
    }
}