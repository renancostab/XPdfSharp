using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using XPdfSharp.Implementation.Utils;
using XPdfSharp.Interface;

namespace XPdfSharp.Implementation
{
    public class Pdf2Text: IPdf2Text
    {
        private const string ProgramBaseName = "pdftotext";
        
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public string Encode { get; set; } = "UTF-8";
        public bool Layout { get; set; }
        public bool Raw { get; set; }
        public bool NoBreakPage { get; set; }
        public bool NoDiagonal { get; set; }
        public bool Clip { get; set; }
        
        public async Task<string> ExtractTextAsync(string fileName)
        {
            var temp = LibUtils.RandomTempFile("txt");
            var args = ParseParameters();
            
            args.Add(LibUtils.QuotedStr(fileName));
            args.Add(LibUtils.QuotedStr(temp));
            
            var programName = LibUtils.GetProgramName(ProgramBaseName);
            var fullArgs = LibUtils.ParseParameters(args);
            var workDir = LibUtils.WorkDirectory;

            await CustomProcess.RunProcessAsync(programName, fullArgs, workDir);
            if (!File.Exists(temp)) 
                return string.Empty;
            
            var text = await File.ReadAllTextAsync(temp);
            File.Delete(temp);
            
            return text;
        }

        public void Dispose()
        {
        }

        private List<string> ParseParameters()
        {
            var args = new List<string>();
            
            if (FirstPage > 0) args.Add($"-f {FirstPage}");
            if (LastPage > 0) args.Add($"-l {LastPage}");
            if (Layout) args.Add("-layout");
            if (Raw) args.Add("-raw");
            if (Clip) args.Add("-clip");
            if (NoDiagonal) args.Add("-nodiag");
            
            args.Add($"-enc {Encode}");
            
            if (NoBreakPage) args.Add("-nopgbrk");
            
            return args;
        }
    }
}