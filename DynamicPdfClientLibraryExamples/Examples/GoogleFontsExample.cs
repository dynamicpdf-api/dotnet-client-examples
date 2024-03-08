using DynamicPDF.Api.Elements;
using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class GoogleFontsExample
    {
        public static void Run(String apiKey, String outputPath)
        {        
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PageInput pageInput = pdf.AddPage(1008, 612);
            TextElement text = new TextElement("Hello", ElementPlacement.TopCenter, 150, 250);
            text.Color = RgbColor.BlueViolet;
            text.Font = Font.Google("Anta", 400, false);
           
            text.FontSize = 45;
            pageInput.Elements.Add(text);
            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/csharp-google-font-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
