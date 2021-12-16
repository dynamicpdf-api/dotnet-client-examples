using DynamicPDF.Api;
using System;

namespace GetPdfInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.NKSoPxiwOgZoypSVYaXyEARo2cO9Kk5BRgY2ZRC0jF/KQq4pDzhfK8yO", "c:/temp/dynamicpdf-api-samples/get-pdf-info/");
        }

        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "fw4.pdf");
            PdfInfo pdfInfo = new PdfInfo(resource);
            pdfInfo.ApiKey = apiKey;
            PdfInfoResponse response = pdfInfo.Process();

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.JsonContent);
            } else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
