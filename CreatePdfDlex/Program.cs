using DynamicPDF.Api;
using System;
using System.IO;

// resources available at cloud.dynamicpdf.com Create PDF (pdf Endpoint) in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-dlex-pdf-endpoint

namespace CreatePdfDlex
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "C:/temp/dynamicpdf-api-samples/create-pdf-dlex/");
        }

        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");

            pdf.AddDlex("samples/creating-pdf-pdf-endpoint/SimpleReportWithCoverPage.dlex", layoutDataResource);

            PdfResource pdfResource = new PdfResource(basePath + "/DocumentA.pdf");
            pdf.AddPdf(pdfResource);


            PdfResponse response = pdf.Process();

            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorJson);
            }
            else
            {
                File.WriteAllBytes(basePath + "create-pdf-dlex-output.pdf", response.Content);
            }
        }
    }
}
