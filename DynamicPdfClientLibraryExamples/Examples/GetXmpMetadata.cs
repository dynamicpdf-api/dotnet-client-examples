using DynamicPDF.Api;
using System;


namespace DynamicPdfClientLibraryExamples.Examples
{
    public class GetXmpMetadata
    {
        public static void Run(string apiKey, string basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse xmlResponse = pdfXmp.Process();

            if (xmlResponse.IsSuccessful)
            {
                Console.WriteLine(xmlResponse.Content.Trim());
            }
            else
            {
                Console.WriteLine(xmlResponse.ErrorJson);
            }
        }
    }
}
