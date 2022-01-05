using DynamicPDF.Api;
using System;

// resources available at cloud.dynamicpdf.com Get XMP Metadata in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-xmp/tutorial-pdf-xmp

namespace GetXmpMetaData
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx---api-key--xxx", "C:/temp/dynamicpdf-api-samples/get-xmp-metadata");
        }

        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse response = pdfXmp.Process();


            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
