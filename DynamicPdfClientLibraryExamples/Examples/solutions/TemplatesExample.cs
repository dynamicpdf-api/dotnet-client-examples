using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;


namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class TemplatesExample
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            CreatePdf(apiKey, basePath, outputPath);
        }

        static void CreatePdf(string apiKey, string basePath, string outputPath)
        {
            Template template = new Template("Temp1");
            TextElement textElement = new TextElement("Hello PDF", ElementPlacement.TopCenter);
            textElement.Color = RgbColor.Blue;
            textElement.FontSize = 42;
            textElement.XOffset = -50;
            textElement.YOffset = 100;

            template.Elements.Add(textElement);

            RectangleElement recElement = new RectangleElement(ElementPlacement.TopCenter, 100, 300);
            recElement.XOffset = 150;
            recElement.YOffset = 100;
            recElement.CornerRadius = 10;
            recElement.BorderColor = RgbColor.Blue;
            recElement.FillColor = RgbColor.Green;
            recElement.BorderWidth = 5;
            recElement.BorderStyle = LineStyle.Dots;

            template.Elements.Add(recElement);

            LineElement element = new LineElement(ElementPlacement.TopLeft, 500, 150);
            element.Color = RgbColor.Red;
            element.XOffset = 105;
            element.YOffset = 50;
            element.LineStyle = LineStyle.Solid;
            element.Width = 4;


            template.Elements.Add(element);

            ImageResource imgResource = new ImageResource(basePath + "/dynamicpdfLogo.png");
            ImageElement imageElement = new ImageElement(imgResource);

            imageElement.ScaleX = 1;
            imageElement.ScaleY = 1;

            imageElement.Placement = ElementPlacement.TopCenter;

            template.Elements.Add(imageElement); 

            //add pdf inputs

            Pdf pdf = new Pdf();
            pdf.Author = "Test Author";
            pdf.Creator = "Test Creator";

            PdfInput input = pdf.AddPdf(new PdfResource(basePath + "multipage-doc.pdf"));
            input.Template = template;


            ImageResource ir = new ImageResource(basePath + "testimage.png");
            ImageInput imageInput = new ImageInput(ir);
            imageInput.Template = template;

            pdf.Inputs.Add(imageInput);

            // output combined pdf

            pdf.ApiKey = apiKey;
            

            PdfResponse response = pdf.Process();

            Console.WriteLine("===================== JSON Instructions Document ======================");
            Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));
            Console.WriteLine("=========================================================================");

            if (response.ErrorJson != null)
            {
                Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
            else
            {
                File.WriteAllBytes(outputPath + "/combined-template-csharp-pdf-output.pdf", response.Content);
            }
        }
    }
}