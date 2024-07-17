
using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    public class Watermark
    {

        /// <summary>
        /// This example does not work as expected, this feature is still being implemented.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="basePath"></param>
        /// <param name="outputPath"></param>

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Template template = new Template("Temp1");
          
            ImageResource imgResource = new ImageResource(basePath + "/dynamicpdfLogo.png");
            ImageElement imageElement = new ImageElement(imgResource);

            imageElement.ScaleX = 1;
            imageElement.ScaleY = 1;

            imageElement.Placement = ElementPlacement.TopCenter;
            imageElement.YOffset = 300;


            template.Elements.Add(imageElement);

            //add pdf inputs

            Pdf pdf = new Pdf();
            pdf.Author = "Test Author";
            pdf.Creator = "Test Creator";

            PdfInput input = pdf.AddPdf(new PdfResource(basePath + "multipage-doc.pdf"));
            input.Template = template;
            

            pdf.ApiKey = apiKey;

            PdfResponse response = pdf.Process();

            //Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));

            if (response.ErrorJson != null)
            {
                Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
            else
            {
                File.WriteAllBytes(outputPath + "/watermark-csharp-pdf-output.pdf", response.Content);
            }
        }
    }
}
