using DynamicPDF.Api;
using System;
using System.IO;

// resources available at cloud.dynamicpdf.com Merge PDFs in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-merging-pdfs


namespace MergePdfs
{
    class Program
    {
    
 static void Main(string[] args)
        {
            Run("DP.xxxxxxxxxxx", "C:/temp/dynamicpdf-api-samples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            // create new pdf instance and set api key
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            var inputA = pdf.AddPdf(new PdfResource(basePath + "DocumentA.pdf"));
            inputA.StartPage = 1;
            inputA.PageCount = 1;

            // add all of pdf from local filesystem

            pdf.AddPdf(new PdfResource(basePath + "DocumentB.pdf"));

            // add pdf from cloud in resource manager

            pdf.AddPdf("/samples/merge-pdfs-pdf-endpoint/DocumentC.pdf");

            PdfResponse pdfResponse = pdf.Process();

            // if the response is successful, save merged pdf to file. if error, then printout JSON error

            if(pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(Path.Combine(basePath, "merge-pdfs-output.pdf"), pdfResponse.Content);
            } else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
