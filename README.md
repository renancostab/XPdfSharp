# XPdfSharp
Wrapper of XPdf Tools for C#

## How Install ##
Available at nuget [XPDFSharp](https://www.nuget.org/packages/XPDFSharp/)

## Features: ##
 * Extraction of PDF text

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
