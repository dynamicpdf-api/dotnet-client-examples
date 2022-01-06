using DynamicPDF.Api;
using System;
using System.IO;

namespace InstructionsDocumentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx---apikey---xxx", "C:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;
            pdf.AddPage(1008, 612);
            pdf.Author = "John Doe";
            pdf.Keywords = "dynamicpdf api example pdf java instructions";
            pdf.Creator = "John Creator";
            pdf.Subject = "topLevel document metadata";
            pdf.Title = "Sample PDF";

            ImageResource imageResource = new ImageResource(basePath + "dynamicpdflogo.png");
            pdf.AddImage(imageResource);

            Console.WriteLine(pdf.GetInstructionsJson());

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(Path.Combine(basePath, "instruction-only-output.pdf"), pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }

    }
}
