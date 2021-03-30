using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using XPdfSharp.Implementation.Utils;
using XPdfSharp.Interface;

namespace XPdfSharp.Implementation
{
    public class Pdf2Png: IPdf2Png
    {
        private const string ProgramBaseName = "pdftopng";

        public string Suffix { get; set; } = "page";
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int Dpi { get; set; } = 150;
        public bool Monochrome { get; set; }
        public bool GrayScale { get; set; }
        public bool IncludeAlpha { get; set; }
        public int Rotation { get; set; } = 0;
        public bool EnableFreeType { get; set; }
        public bool FontAntiAliasing { get; set; }
        public bool VectorAntiAliasing { get; set; }
        
        public async Task<int> GenerateImagesAsync([NotNull] string fileName, [NotNull] string outputDirectory)
        {
            if (!File.Exists(fileName) || !Directory.CreateDirectory(outputDirectory).Exists)
                return -1;
            
            if (outputDirectory[^1] != Path.DirectorySeparatorChar)
                outputDirectory = string.Concat(outputDirectory, Path.DirectorySeparatorChar);

            var args = ParseParameters();
            args.Add(LibUtils.QuotedStr(fileName));
            args.Add(LibUtils.QuotedStr($"{outputDirectory}{Suffix}"));

            var programName = LibUtils.GetProgramName(ProgramBaseName);
            var fullArgs = LibUtils.ParseParameters(args);
            var workDir = LibUtils.WorkDirectory;

            return await CustomProcess.RunProcessAsync(programName, fullArgs, workDir);
        }
        
        public void Dispose()
        {
        }

        private List<string> ParseParameters()
        {
            var args = new List<string>();
            
            if (FirstPage > 0) args.Add($"-f {FirstPage}");
            if (LastPage > 0) args.Add($"-l {LastPage}");
            
            args.Add($"-r {Dpi}");
            
            if (Monochrome) args.Add("-mono");
            if (GrayScale) args.Add("-gray");
            if (IncludeAlpha) args.Add("-alpha");
            
            args.Add($"-rot {Rotation}");
            
            if (EnableFreeType) args.Add("-freetype yes");
            if (FontAntiAliasing) args.Add("-aa yes");
            if (VectorAntiAliasing) args.Add("-aaVector yes");
            
            return args;
        }
    }
}