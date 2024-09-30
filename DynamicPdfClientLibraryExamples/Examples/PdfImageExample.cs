using DynamicPDF.Api;
using DynamicPDF.Api.Imaging;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class PdfImageExample
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Process(apiKey, basePath + "onepage.pdf", outputPath + "png_single-output_");
            Process(apiKey, basePath + "pdfnumberedinput.pdf", outputPath + "png_multi-output_");

        }

        public static void Process(string apiKey, string basePath, string outputPath)
        {

            PdfResource resource = new PdfResource(basePath);
            PdfImage pdfImage = new PdfImage(resource);

            PngImageFormat pngImageFormat = new PngImageFormat();
            pdfImage.ImageFormat = pngImageFormat;
            pdfImage.ApiKey = apiKey;
            PdfImageResponse response = pdfImage.Process();

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(outputPath + i + ".png", Convert.FromBase64String(response.Images[i].Data));
                }
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
