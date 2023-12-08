using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class PdfExample
    {

        public static void Run(string apiKey, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PageInput pageInput = pdf.AddPage(1008, 612);
            PageNumberingElement pageNumberingElement = new PageNumberingElement("1", ElementPlacement.TopRight);
            pageNumberingElement.Color = RgbColor.Red;
            pageNumberingElement.Font = Font.Courier;
            pageNumberingElement.FontSize = 24;

            pageInput.Elements.Add(pageNumberingElement);

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "csharp-pdf-example-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
