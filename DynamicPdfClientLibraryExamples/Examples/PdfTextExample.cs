using DynamicPDF.Api;
using DynamicPdfClientLibraryExamples.Utility;
using System;


namespace DynamicPdfClientLibraryExamples.Examples
{
    public class PdfTextExample
    {
        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfText pdfText = new PdfText(resource);
            pdfText.StartPage = 1;
            pdfText.PageCount = 2;
            pdfText.ApiKey = apiKey;
            PdfTextResponse response = pdfText.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
