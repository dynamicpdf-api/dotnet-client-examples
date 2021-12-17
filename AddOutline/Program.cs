using DynamicPDF.Api;
using System;
using System.IO;

namespace AddOutline
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.vg32AKtgL65WG0JKw7OrqggLV4oru6JD1I2j0fsboxfZQrVOHoJRUlH5", "C:/temp/dynamicpdf-api-samples/add-outline/");
        }

        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.Author = "John Doe";
            pdf.Title = "Existing Pdf Example";
            PdfResource resource = new PdfResource(basePath + "AllPageElements.pdf");
            PdfInput input = pdf.AddPdf(resource);
            MergeOptions mergeOptions = new MergeOptions();
            mergeOptions.Outlines = false;
            input.Id = "documentA";
            input.MergeOptions = mergeOptions;
            PdfInput input1 = pdf.AddPdf("samples/adding-outline-pdf-endpoint/outline-existing.pdf");
            input1.Id = "documentB";
            
            //rootOutline.Expanded = true;
            //rootOutline.Children.AddPdfOutlines(input1);
            pdf.ApiKey = apiKey;
            PdfResponse response = pdf.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));
            File.WriteAllBytes(basePath + "outline-tutorial-output.pdf", response.Content);
        }

    }
}
