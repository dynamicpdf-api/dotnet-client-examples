using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class ImageConversionExample
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            ImageResource imageResource = new ImageResource(basePath + "MultipageTiff.tif");
            ImageInput imageInput = pdf.AddImage(imageResource);

            imageInput.Align = Align.Center;
            imageInput.VAlign = VAlign.Center;
            imageInput.ExpandToFit = false;
            imageInput.PageHeight = 1008;
            imageInput.PageWidth = 612;

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/convert-img-to-pdf-multipage-tiff-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
