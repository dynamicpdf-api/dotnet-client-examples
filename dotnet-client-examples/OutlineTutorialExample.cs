using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class OutlineTutorialExample
    {


        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.Author = "John Doe";
            pdf.Title = "Existing Pdf Example";
            PdfResource resource = new PdfResource(basePath + "AllPageElements.pdf");
            PdfInput input = pdf.AddPdf(resource);
            input.Id = "AllPageElements";
            pdf.Inputs.Add(input);
            PdfResource resource1 = new PdfResource(basePath + "outline-existing.pdf");
            PdfInput input1 = pdf.AddPdf(resource1);
            input1.Id = "outlineDoc1";
            pdf.Inputs.Add(input1);
            Outline rootOutline = pdf.Outlines.Add("Imported Outline");
            rootOutline.Expanded = true;
            rootOutline.Children.AddPdfOutlines(input);
            rootOutline.Children.AddPdfOutlines(input1);
            pdf.ApiKey = apiKey;
            PdfResponse response = pdf.Process();
            File.WriteAllBytes(basePath + "outline-tutorial-output.pdf", response.Content);
        }
    }
}
