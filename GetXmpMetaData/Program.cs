using DynamicPDF.Api;
using System;

namespace GetXmpMetaData
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.JtmSyCt8jfAi5IfSa5+Egl7HDj7TBdUsNPy2pu9JqiWWS4AJ+g5/HkMF", "C:/temp/dynamicpdf-api-samples/get-xmp-metadata");
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
