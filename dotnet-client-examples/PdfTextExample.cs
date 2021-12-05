using DynamicPDF.Api;
using System;

namespace DynamicPdfCloudApiClientExamples
{
    class PdfTextExample
    {
        public static void PdfInfoExampleOne(String key, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfText pdfText = new PdfText(resource);
            pdfText.ApiKey = key;
            PdfTextResponse response = pdfText.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
