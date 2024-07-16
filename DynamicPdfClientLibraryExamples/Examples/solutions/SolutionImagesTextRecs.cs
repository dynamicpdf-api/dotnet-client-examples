using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class SolutionImagesTextRecs
    {
        public static void Run(string apiKey, string basePath,  string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PageInput pageInput = pdf.AddPage(1008, 612);
            
            TextElement textElement = new TextElement("Hello PDF", ElementPlacement.TopCenter, 50, 100);
            textElement.Color = RgbColor.Blue;
            textElement.FontSize = 42;
            pageInput.Elements.Add(textElement);
            textElement.XOffset = -50;
            textElement.YOffset = 100;

            LineElement element = new LineElement(ElementPlacement.TopLeft, 900, 150);
            element.Color = RgbColor.Red;
            element.XOffset = 305;
            element.YOffset = 150;

            element.LineStyle = LineStyle.Solid;
            element.Width = 4;
            pageInput.Elements.Add(element);


            RectangleElement recElement = new RectangleElement(ElementPlacement.TopCenter, 100, 500);
            recElement.XOffset = -250;
            recElement.YOffset = -10;
            recElement.CornerRadius = 10;
            recElement.BorderWidth = 5;
            recElement.BorderStyle = LineStyle.Dots;
            recElement.BorderColor = RgbColor.Blue;
            recElement.FillColor = RgbColor.Green;
            pageInput.Elements.Add(recElement);


            ImageResource imgResource = new ImageResource(basePath + "/dynamicpdfLogo.png");
            ImageElement imageElement = new ImageElement(imgResource);
            imageElement.XOffset = 835;
            imageElement.YOffset = 75;
            pageInput.Elements.Add(imageElement);


            Console.WriteLine(pdf.GetInstructionsJson(true));


            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/create-pdf-csharp-img-text-rec-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }

    }
}
