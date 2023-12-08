using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class GetPdfInfo
    {
        public static void Run(string apiKey, string basePath)
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
