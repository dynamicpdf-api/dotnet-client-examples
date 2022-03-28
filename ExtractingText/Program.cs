using DynamicPDF.Api;
using System;

// resources available at cloud.dynamicpdf.com Extract Text (pdf-text Endpoint) in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-text/tutorial-pdf-text

namespace ExtractingText
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP --- apikey ---", "C:/temp/dynamicpdf-api-samples/extract-text/");
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
