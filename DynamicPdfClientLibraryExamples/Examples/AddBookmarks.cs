using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class AddBookmarks
    {

        public static void Run(string apiKey, string basePath, String outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PdfResource resource = new PdfResource(basePath + "DocumentA.pdf");
            PdfInput input = pdf.AddPdf(resource);
            input.Id = "documentA";

            PdfResource resourceB = new PdfResource(basePath + "DocumentB.pdf");
            PdfInput inputB = pdf.AddPdf(resourceB);
            inputB.Id = "documentB";

            PdfResource resourceC = new PdfResource(basePath + "DocumentC.pdf");
            PdfInput inputC = pdf.AddPdf(resourceC);
            inputC.Id = "documentC";

            Outline rootOutline = pdf.Outlines.Add("Three Bookmarks");
            Outline outlineA = rootOutline.Children.Add("DocumentA", input);
            Outline outlineB = rootOutline.Children.Add("DocumentB", inputB);

            rootOutline.Children.Add("DocumentC", inputC).Color = RgbColor.Purple;

            rootOutline.Color = RgbColor.Red;
            rootOutline.Style = OutlineStyle.BoldItalic;
            outlineA.Color = RgbColor.Orange;
            outlineB.Color = RgbColor.Green;

            Outline outlineD = rootOutline.Children.Add("DynamicPDF Cloud API");
            outlineD.Color = RgbColor.Blue;
            outlineD.Action = new UrlAction("https://cloud.dynamicpdf.com/");

            rootOutline.Expanded = true;

            PdfResponse response = pdf.Process();

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/add-bookmarks-csharp-output.pdf", response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }


        }
    }
}
