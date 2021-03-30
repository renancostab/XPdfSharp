# XPdfSharp
Wrapper of XPdf Tools for C#

## How Install ##
Available at nuget [XPDFSharp](https://www.nuget.org/packages/XPDFSharp/)

## Features: ##
 * Extraction of PDF text
 * Print PDF to PNG files

## Roadmap: ##
 * Other tools related to xPDF such as pdftohtml and pdftopng.

 ## Quick Example ##
 ```C#
  using (var extractor = ToolsFactory.NewPdf2Text)
  {
      extractor.Raw = true;
      extractor.NoBreakPage = true;
      
      var text = await extractor.ExtractTextAsync("samples/sample.pdf");
      Console.WriteLine(text);
  }
  
   using (var pngConvertion = ToolsFactory.NewPdf2Png)
   {
       pngConvertion.Dpi = 75;
       var result = await pngConvertion.GenerateImagesAsync("samples/sample.pdf", "samples/images/");

       Console.WriteLine("Generated images success: {0} codeError: {1}", result == 0, result);
       if (result != 0)
           return;

       var files = Directory.GetFiles("samples/images/");
       Console.WriteLine("Image Count: {0}", files.Length);
   }
