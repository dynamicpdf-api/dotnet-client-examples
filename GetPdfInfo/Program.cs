using System;
using DynamicPDF.Api;

namespace GetPdfInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-samples/get-pdf-info/");
        }

        static void Run(string apiKey, string basePath)
        {
            PdfInfo pdfInfo = new PdfInfo(new PdfResource(basePath + "fw4.pdf"));
            pdfInfo.ApiKey = apiKey;
            PdfInfoResponse pdfInfoResponse = pdfInfo.Process();

            if (pdfInfoResponse.IsSuccessful)
            {
                Console.WriteLine(pdfInfoResponse.JsonContent);
            }
            else
            {
                Console.WriteLine(pdfInfoResponse.ErrorJson);
            }

        }
    }
}
