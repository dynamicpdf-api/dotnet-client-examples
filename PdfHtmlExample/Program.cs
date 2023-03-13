using System;
using DynamicPDF.Api;

namespace PdfHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-samples/html-pdf/");
        }

        public static void Run(string apiKey, string basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            // add simple HTML string

            pdf.AddHtml("<html><p>This is a test.</p></html>");

            // add html from a path on local drive

            HtmlResource resource = new HtmlResource(System.IO.File.ReadAllText(basePath + "HtmlWithAllTags.html"));
            pdf.AddHtml(resource);

            // use basepath in an HTML string

            pdf.AddHtml("<html><img src='./images/logo.png'></img></html>", "https://www.dynamicpdf.com");

            Console.Write(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));


            PdfResponse pdfResponse = pdf.Process();
            System.IO.File.WriteAllBytes(basePath + "html-output-csharp.pdf", pdfResponse.Content);
        }
    }
}
