using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class DeletePages
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            PerformDelete(apiKey, basePath, outputPath);
        }

        static void PerformDelete(string apiKey, string basePath, string outputPath)
        {

            //add pdf inputs

            Pdf pdf = new Pdf();
            pdf.Author = "Test Author";
            pdf.Creator = "Test Creator";

            PdfInput input = pdf.AddPdf(new PdfResource(basePath + "pdfnumberedinput.pdf"));
            input.StartPage = 1;
            input.PageCount = 3;

            PdfInput input2 = pdf.AddPdf(new PdfResource(basePath + "pdfnumberedinput.pdf"));
            input2.StartPage = 6;
            input2.PageCount = 2;

            
            // output combined pdf

            pdf.ApiKey = apiKey;


            PdfResponse response = pdf.Process();


            if (response.ErrorJson != null)
            {
                Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
            else
            {
                File.WriteAllBytes(outputPath + "/delete-pages-output.pdf", response.Content);
            }
        }
    }
}
