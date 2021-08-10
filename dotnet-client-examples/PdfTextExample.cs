using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class PdfTextExample
    {
        // simple example from Getting Started - pdf-text
        public static void PdfInfoExampleOne(String key)
        {
            PdfResource resource = new PdfResource(@"c:/holding/pdf-text/fw4.pdf");
            PdfText pdfText = new PdfText(resource);
            pdfText.ApiKey = key;
            PdfTextResponse response = pdfText.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
