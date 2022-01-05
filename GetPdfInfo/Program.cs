using DynamicPDF.Api;
using System;

namespace GetPdfInfo
{

    // resources available at cloud.dynamicpdf.com Get PDF Info in the Resource Manager
    // tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-info/tutorial-pdf-info

    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "c:/temp/dynamicpdf-api-samples/get-pdf-info/");
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
