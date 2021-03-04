using System;
using System.IO;
using System.Threading.Tasks;
using XPdfSharp.Factory;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("====== XPdfToolsForSharp Demo ======");
            Console.WriteLine();
            
            using (var extract = ToolsFactory.NewPdf2Text)
            {
                extract.Raw = true;
                extract.NoBreakPage = true;
                var text = await extract.ExtractTextAsync("samples/sample.pdf");
                
                Console.WriteLine(text);
            }
        }
    }
}