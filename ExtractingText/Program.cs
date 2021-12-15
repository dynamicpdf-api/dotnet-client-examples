using DynamicPDF.Api;
using System;

namespace ExtractingText
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.NKSoPxiwOgZoypSVYaXyEARo2cO9Kk5BRgY2ZRC0jF/KQq4pDzhfK8yO", "C:/temp/dynamicpdf-api-samples/extract-text/");
        }

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
            } else
            {
                Console.WriteLine(response.ErrorJson);
            }

        }
    }
}
