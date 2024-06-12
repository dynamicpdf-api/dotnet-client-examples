using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class PdfHtmlExample
    {

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            // add simple HTML string

            pdf.AddHtml("<html>An example HTML fragment.</html>");

            // add html from a path on local drive

            HtmlResource resource = new HtmlResource(System.IO.File.ReadAllText(basePath + "products.html"));
            pdf.AddHtml(resource);

            // use basepath in an HTML string

            pdf.AddHtml("<html><img src='./images/logo.png'></img><p style='color:red;font-family:verdana;font-size:30px'>Hello DynamicPDF Cloud API</html>", "https://www.dynamicpdf.com");
                       
            PdfResponse pdfResponse = pdf.Process();
            System.IO.File.WriteAllBytes(outputPath + "/converting-html-pdf-output-csharp.pdf", pdfResponse.Content);
        }
    }
}
