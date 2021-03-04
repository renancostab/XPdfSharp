using XPdfSharp.Implementation;
using XPdfSharp.Interface;

namespace XPdfSharp.Factory
{
    public static class ToolsFactory
    {
        /// <summary>
        /// Create a new instance of IPdf2Text capable of extract text from a PDF
        /// </summary>
        public static IPdf2Text NewPdf2Text => new Pdf2Text();
    }
}