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
        
        public static string RandomFileName(string ext = DefaultExt) => $"{Guid.NewGuid()}.{ext}";
        public static string RandomTempFile(string ext = DefaultExt) => $"{Path.GetTempPath()}{RandomFileName(ext)}";
        public static string QuotedStr(string str) => string.Concat(Quoted, str, Quoted);
        public static string ParseParameters(IEnumerable<string> arguments) => string.Join(ArgumentEnd, arguments);
        public static string WorkDirectory => Environment.CurrentDirectory;
        public static string GetProgramName(string programBase)
        {
            switch (RuntimeInfo.OsEnvironment())
            {
                case Platform.Windows:
                    return string.Concat(programBase, ".exe");
                case Platform.Linux:
                    return string.Concat(programBase, ".linux");
                case Platform.Osx:
                    return string.Concat(programBase, ".mac");
                case Platform.Unknown:                
                default:
                    throw new Exception("OS not supported");
            }
        }
        
    }
}