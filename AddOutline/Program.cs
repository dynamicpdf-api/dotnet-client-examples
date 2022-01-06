using DynamicPDF.Api;
using System;
using System.IO;

// resources available at cloud.dynamicpdf.com Adding Bookmarksin the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-bookmarks

namespace AddBookmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "C:/temp/dynamicpdf-api-samples/add-bookmarks/");
        }

        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            //add three PDF documents as PdfInputs

            PdfResource resource = new PdfResource(basePath + "DocumentA.pdf");
            PdfInput inputA = pdf.AddPdf(resource);
            inputA.Id = "documentA";

            PdfResource resourceB = new PdfResource(basePath + "DocumentB.pdf");
            PdfInput inputB = pdf.AddPdf(resourceB);
            inputB.Id = "documentB";

            PdfResource resourceC = new PdfResource(basePath + "DocumentC.pdf");
            PdfInput inputC = pdf.AddPdf(resourceC);
            inputC.Id = "documentC";

            //create a root outline and then add the three documents as children Outline instances

            Outline rootOutline = pdf.Outlines.Add("Three Bookmarks");
            Outline outlineA = rootOutline.Children.Add("DocumentA", inputA);
            Outline outlineB = rootOutline.Children.Add("DocumentB", inputB, 2);
            rootOutline.Children.Add("DocumentC", inputC).Color = RgbColor.Purple;

            //add some color to the outline elements

            rootOutline.Color = RgbColor.Red;
            rootOutline.Style = OutlineStyle.BoldItalic;
            outlineA.Color = RgbColor.Orange;
            outlineB.Color = RgbColor.Green;

            //add an outline element that links to a URL

            Outline outlineD = rootOutline.Children.Add("DynamicPDF Cloud API");
            outlineD.Color = RgbColor.Blue;
            outlineD.Action = new UrlAction("https://cloud.dynamicpdf.com/");

            rootOutline.Expanded = true;

            PdfResponse response = pdf.Process();
            
            if(response.IsSuccessful)
            {
                Console.WriteLine(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));
                 File.WriteAllBytes(basePath + "add-bookmarks-output.pdf", response.Content);
            } else
            {
                Console.WriteLine(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));
                Console.WriteLine(response.ErrorJson);
            }
        }

    }
}
