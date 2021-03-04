# XPdfSharp
Wrapper of XPdf Tools for C#

## Features: ##
 * Extraction of PDF text

## Roadmap: ##
 * Other tools related to xPDF such as pdftohtml and pdftopng.

 ## Quick Example ##
 ```C#
  using (var extract = ToolsFactory.NewPdf2Text)
  {
      extract.Raw = true;
      extract.NoBreakPage = true;
      var text = await extract.ExtractTextAsync("samples/sample.pdf");

      Console.WriteLine(text);
  }
