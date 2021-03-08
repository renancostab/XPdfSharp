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

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return Platform.Linux;
            
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? Platform.Osx : Platform.Unknown;
        }
    }
}