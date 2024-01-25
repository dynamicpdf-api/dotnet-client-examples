

using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class SplitPdfs
    {

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            SplitPdfs.Split(apiKey, basePath, outputPath, 1, 3, "split-one.pdf");
            SplitPdfs.Split(apiKey, basePath, outputPath, 6, 2, "split-two.pdf");

        }

        static void Split(string apiKey, string basePath, string outputPath, int startPage, int pageCount, string outputFile)
        {

            Pdf pdf = new Pdf();

            PdfInput input = pdf.AddPdf(new PdfResource(basePath + "pdfnumberedinput.pdf"));
            input.StartPage = startPage;
            input.PageCount = pageCount;

            pdf.ApiKey = apiKey;


            PdfResponse response = pdf.Process();

            if (response.ErrorJson != null)
            {
                Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
            else
            {
                File.WriteAllBytes(outputPath + "/" + outputFile, response.Content);
            }
        }
    }

}
