using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class PdfInfoExample
    {
        public static void Run(string key, string basePath)
        {
            PdfResource resource = new PdfResource(basePath + "fw4.pdf");
            PdfInfo pdfInfo = new PdfInfo(resource);
            pdfInfo.ApiKey = key;
            PdfInfoResponse response = pdfInfo.Process();
            Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
