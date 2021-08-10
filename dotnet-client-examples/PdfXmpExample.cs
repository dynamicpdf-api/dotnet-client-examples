using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class PdfXmpExample
    {
        public static void PdfXmpExampleOne(String apiKey)
        {
            PdfResource resource = new PdfResource(@"c:/holding/pdf-text/fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse response = pdfXmp.Process();
            Console.WriteLine(response.Content);
        }
    }
}
