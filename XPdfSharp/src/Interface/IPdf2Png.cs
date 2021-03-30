using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace XPdfSharp.Interface
{
    public interface IPdf2Png: IDisposable
    {
        /// <summary>
        /// Suffix used in the image file (Default: "page" / Pattern: Suffix-PageNumber.png / e.g. page-00001.png)
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// First page to print
        /// </summary>
        public int FirstPage { get; set; }
        /// <summary>
        /// Last page to print
        /// </summary>
        public int LastPage { get; set; }
        /// <summary>
        /// Resolution, in DPI (Default: 150)
        /// </summary>
        public int Dpi { get; set; }
        /// <summary>
        /// Generate a monochrome PNG file (Default: false)
        /// </summary>
        public bool Monochrome { get; set; }
        /// <summary>
        /// Generate a grayscale PNG file (Default: false)
        /// </summary>
        public bool GrayScale { get; set; }
        /// <summary>
        /// Include an alpha channel in the PNG file (Default: false)
        /// </summary>
        public bool IncludeAlpha { get; set; }
        /// <summary>
        /// Set page rotation angle (0, 90, 180 or 270) (Default: 0, no rotation)
        /// </summary>
        public int Rotation { get; set; }
        /// <summary>
        /// Enable FreeType font rasterizer (Default: false)
        /// </summary>
        public bool EnableFreeType { get; set; }
        /// <summary>
        /// Enable font anti-aliasing (Default: false)
        /// </summary>
        public bool FontAntiAliasing { get; set; }
        /// <summary>
        /// Enable vector anti-aliasing (Default: false)
        /// </summary>
        public bool VectorAntiAliasing { get; set; }
        /// <summary>
        /// Create N images PNG (one per page) from a pdf source.
        /// Reasons to return a value that is not zero:
        ///  1- fileName do not exists. (Return -1)
        ///  2- outputDirectory not exists and impossible to create (Check the path and name). (Return -1)
        ///  3- the program returns a value != 0 (Check the program dependencies such as libdgiplus, libc and others).
        /// </summary>
        /// <param name="fileName">Pdf name</param>
        /// <param name="outputDirectory">Output directory of the images</param>
        /// <returns></returns>
        public Task<int> GenerateImagesAsync([NotNull] string fileName, [NotNull] string outputDirectory);
    }
}