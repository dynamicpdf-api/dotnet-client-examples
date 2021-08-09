using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_client_examples
{
    public static class PdfInfoExample
    {
        // simple example from Getting Started - pdf-info
        public static void PdfInfoExampleOne(String key)
        {
            PdfResource resource = new PdfResource(@"c:/holding/pdf-text/fw4.pdf");
            PdfInfo pdfInfo = new PdfInfo(resource);
            pdfInfo.ApiKey = key;
            PdfInfoResponse response = pdfInfo.Process();

            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
            Console.WriteLine("=========================================");
            Console.WriteLine(response.Content.Creator);

        }
    }
}
