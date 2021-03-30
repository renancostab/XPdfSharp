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

        /// <summary>
        /// Create a new instance of IPdf2Png capable of create PNG files from a PDF source
        /// </summary>
        public static IPdf2Png NewPdf2Png => new Pdf2Png();
    }
}