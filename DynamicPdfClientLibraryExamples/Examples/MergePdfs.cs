using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class MergePdfs
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            var inputA = pdf.AddPdf(new PdfResource(basePath + "DocumentA.pdf"));
            inputA.StartPage = 1;
            inputA.PageCount = 1;

            pdf.AddPdf(new PdfResource(basePath + "DocumentB.pdf"));

            pdf.AddPdf("samples/merge-pdfs-pdf-endpoint/DocumentC.pdf");

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/merge-pdfs-output-csharp.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }

    }
}
