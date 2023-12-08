using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class ExtractingText
    {
        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "fw4.pdf");
            PdfText pdfText = new PdfText(resource);
            pdfText.ApiKey = apiKey;
            pdfText.StartPage = 1;
            pdfText.PageCount = 2;

            PdfTextResponse response = pdfText.Process();
            if (response.IsSuccessful)
            {
                Console.WriteLine((response.JsonContent));
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }

        }
    }
}
