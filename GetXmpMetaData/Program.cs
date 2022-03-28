using DynamicPDF.Api;
using System;

namespace GetXmpMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP --- API KEY ---", "c:/temp/dynamicpdf-api-samples/get-xmp-metadata/");
        }

        static void Run(string apiKey, string basePath)
        {
            PdfResource resource = new PdfResource(basePath + "fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse xmlResponse = pdfXmp.Process();

            if(xmlResponse.IsSuccessful)
            {
                Console.WriteLine(xmlResponse.Content);
            } else
            {
                Console.WriteLine(xmlResponse.ErrorJson);
            }
        }
    }
}
