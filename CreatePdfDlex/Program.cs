using System;
using DynamicPDF.Api;
using System.IO;

namespace CreatePdfDlex
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.API-KEY", "c:/temp/dynamicpdf-api-samples/create-pdf-dlex/");
        }

        public static void Run(string apiKey, string basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
            pdf.AddDlex("samples/creating-pdf-pdf-endpoint/SimpleReportWithCoverPage.dlex", layoutDataResource);
            PdfResponse pdfResponse = pdf.Process();

            if(pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(basePath + "create-pdf-dlex-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
