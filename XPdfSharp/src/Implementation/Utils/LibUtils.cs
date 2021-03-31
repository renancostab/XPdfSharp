using System;
using System.Collections.Generic;
using System.IO;
using XPdfSharp.Enum;

namespace XPdfSharp.Implementation.Utils
{
    public static class LibUtils
    {
        private const string DefaultExt = "tmp";
        private const string Quoted = "\"";
        private const string ArgumentEnd = " ";
        private const string WindowsExtension = ".exe";
        private const string LinuxExtension = ".linux";
        private const string MacExtension = ".mac";
        
        public static string RandomFileName(string ext = DefaultExt) => $"{Guid.NewGuid()}.{ext}";
        public static string RandomTempFile(string ext = DefaultExt) => $"{Path.GetTempPath()}{RandomFileName(ext)}";
        public static string QuotedStr(string str) => string.Concat(Quoted, str, Quoted);
        public static string ParseParameters(IEnumerable<string> arguments) => string.Join(ArgumentEnd, arguments);
        public static string WorkDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public static string GetProgramName(string programBase)
        {
            switch (RuntimeInfo.OsEnvironment())
            {
                case Platform.Windows:
                    return string.Concat(programBase, WindowsExtension);
                case Platform.Linux:
                    return string.Concat(programBase, LinuxExtension);
                case Platform.Osx:
                    return string.Concat(programBase, MacExtension);
                case Platform.Unknown:                
                default:
                    throw new Exception("OS not supported");
            }
        }
        
    }
}