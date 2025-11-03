
using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class PdfSecurityInfoExample
    {
        public static void Run(string apiKey, string basePath)
        {
            PdfResource resource = new PdfResource(basePath + "aes256-security.pdf");
            PdfSecurityInfoEndpoint secInfoEndpoint = new PdfSecurityInfoEndpoint(resource);
            secInfoEndpoint.ApiKey = apiKey;
            PdfSecurityInfoResponse resp = secInfoEndpoint.Process();
            PdfSecurityInfo info = resp.Content;
            Console.WriteLine(resp.JsonContent);
            Console.WriteLine("EncryptionType: " + info.EncryptionTypeString);

        }
    }
}
