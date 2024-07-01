using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class GetPdfInfo
    {
        public static void Run(string apiKey, string basePath)
        {
            PdfResource resource = new PdfResource(basePath + "fw4.pdf");
            PdfInfo pdfInfo = new PdfInfo(resource);
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
