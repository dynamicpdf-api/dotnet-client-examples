using DynamicPDF.Api;
using System;

namespace DynamicPdfCloudApiClientExamples
{
    class PdfXmpExample
    {
        public static void PdfXmpExampleOne(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse response = pdfXmp.Process();
            Console.WriteLine(response.Content);
        }
    }
}
