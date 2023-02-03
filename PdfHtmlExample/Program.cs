using System;
using DynamicPDF.Api;

namespace PdfHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "<api key>";
            string savePath = "c:/temp/html-pdf/html-output.pdf";
            string resourcePath = "c:/temp/html-pdf/test.html";
            Program.Run(key, savePath, resourcePath);
        }

        public static void Run(string apiKey, string savePath, string resourcePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            // add simple HTML string

            pdf.AddHtml("<html><p>This is a test.</p></html>");

            // add html from a path on local drive

            HtmlResource resource = new HtmlResource(System.IO.File.ReadAllText(@"c:/temp/html-pdf/test.html"));
            pdf.AddHtml(resource);

            // use basepath in an HTML string

            pdf.AddHtml("<html><img src='./images/logo.png'></img></html>", "https://www.dynamicpdf.com");

            Console.Write(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));


            PdfResponse pdfResponse = pdf.Process();
            System.IO.File.WriteAllBytes(savePath, pdfResponse.Content);
        }
    }
}
