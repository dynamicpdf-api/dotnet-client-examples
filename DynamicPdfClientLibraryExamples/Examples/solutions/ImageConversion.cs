using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class ImageConversion
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            ImageResource imageResource = new ImageResource(basePath + "testimage.tif");
            ImageInput imageInput = pdf.AddImage(imageResource);
            imageInput.Align = Align.Center;
            imageInput.VAlign = VAlign.Center;
            imageInput.ExpandToFit = false;
            imageInput.PageHeight = 1008;
            imageInput.PageWidth = 612;
            

            ImageResource imageResourceTwo = new ImageResource(basePath + "dynamicpdfLogo.png");
            ImageInput imageInputTwo = pdf.AddImage(imageResourceTwo);

            imageInputTwo.Align = Align.Center;
            imageInputTwo.VAlign = VAlign.Center;
            imageInputTwo.ExpandToFit = true;
            imageInputTwo.PageHeight = 612;
            imageInputTwo.PageWidth = 1008;

            //Console.WriteLine(pdf.GetInstructionsJson(true));


            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/convert-img-to-pdf-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
