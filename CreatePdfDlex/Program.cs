using DynamicPDF.Api;
using System;
using System.IO;

namespace CreatePdfDlex
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.F9KH87xzX6JFVE4YGbkLU4nvx7fbnjXOKIr7wPWYPRdaRJe7OlYQ+/cw", "C:/temp/dynamicpdf-api-samples/create-pdf-dlex/");
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
