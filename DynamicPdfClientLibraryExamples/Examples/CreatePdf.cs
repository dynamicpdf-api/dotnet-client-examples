using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class CreatePdf
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
            pdf.AddDlex("samples/creating-pdf-pdf-endpoint/SimpleReportWithCoverPage.dlex", layoutDataResource);
            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/create-pdf-pdf-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
