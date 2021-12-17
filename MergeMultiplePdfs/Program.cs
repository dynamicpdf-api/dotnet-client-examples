using DynamicPDF.Api;
using System;
using System.IO;

namespace MergePdfs
{
    class Program
    {
    
 static void Main(string[] args)
        {
            Run("DynamicPdfApiKey", "C:/temp/dynamicpdf-api-samples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            // create new pdf instance and set api key
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            // add pdfs to merge from the cloud
            pdf.AddPdf("samples/merge-pdfs/DocumentA.pdf");
            pdf.AddPdf("samples/merge-pdfs/DocumentB.pdf");

            // add pdf from local file system
            PdfResource pdfResource = new PdfResource(basePath + "DocumentC.pdf");
            pdf.AddPdf(pdfResource);

            PdfResponse pdfResponse = pdf.Process();

            // if the response is successful, save merged pdf to file. if error, then printout JSON error

            if(pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(Path.Combine(basePath, "merge-multiple-documents-output.pdf"), pdfResponse.Content);
            } else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
