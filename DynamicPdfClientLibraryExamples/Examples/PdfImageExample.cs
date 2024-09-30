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
            SinglePage(apiKey, basePath, outputPath);
            MultiPage(apiKey, basePath, outputPath);

        }

        public static void SinglePage(string apiKey, string basePath, string outputPath)
        {

            PdfResource resource = new PdfResource(basePath + "onepage.pdf");
            PdfImage pdfImage = new PdfImage(resource);

            PngImageFormat pngImageFormat = new PngImageFormat();
            pdfImage.ImageFormat = pngImageFormat;
            //pdfImage.ApiKey = apiKey;
            PdfImageResponse response = pdfImage.Process();

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(outputPath + "png_output_" + i + ".png", Convert.FromBase64String(response.Images[i].Data));
                }
            }
            else
            {

                Console.WriteLine(response.ErrorJson);
            }
        }

        public static void MultiPage(string apiKey, string basePath, string outputPath)
        {

            PdfResource resource = new PdfResource(basePath + "pdfnumberedinput.pdf");
            PdfImage pdfImage = new PdfImage(resource);

            PngImageFormat pngImageFormat = new PngImageFormat();
            pdfImage.ImageFormat = pngImageFormat;
            pdfImage.ApiKey = apiKey;
            PdfImageResponse response = pdfImage.Process();

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(outputPath + "png_multi-output_" + i + ".png", Convert.FromBase64String(response.Images[i].Data));
                }
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
