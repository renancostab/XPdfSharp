using System;
using System.Threading.Tasks;

namespace XPdfSharp.Interface
{
    public interface IPdf2Text: IDisposable
    {
        /// <summary>
        /// First page to convert
        /// </summary>
        int FirstPage { get; set; }
        /// <summary>
        /// Last page to convert
        /// </summary>
        int LastPage { get; set; }
        /// <summary>
        /// Maintain original physical layout
        /// </summary>
        bool Layout { get; set; }
        /// <summary>
        /// Keep strings in content stream order
        /// </summary>
        bool Raw { get; set; }
        /// <summary>
        /// Don't insert page breaks between pages
        /// </summary>
        bool NoBreakPage { get; set; }
        /// <summary>
        /// Discard diagonal text
        /// </summary>
        bool NoDiagonal { get; set; }
        /// <summary>
        /// Separate clipped text
        /// </summary>
        bool Clip { get; set; }
        /// <summary>
        /// Extract the text of a PDF 
        /// </summary>
        /// <param name="fileName">PDF</param>
        /// <returns>Extracted text</returns>
        Task<string> ExtractTextAsync(string fileName);
    }
}