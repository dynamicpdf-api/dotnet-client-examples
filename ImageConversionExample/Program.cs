using DynamicPDF.Api;
using DynamicPdfClientLibraryExamples.Utility;
using System;
using System.IO;

namespace ImageConversionExample
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources";
        private const string outputPath = "Output";
        private const string apiKey = "DP.UlX+uMEw+TP1A7f97fStg6oxsgZedC92rPC0naP157VFQJloYPO3Aadk";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            Run(apiKey, FileUtility.GetPath(basePath + "/image-conversion/"), FileUtility.GetPath(outputPath));
        }

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            ImageResource imageResource = new ImageResource(basePath + "MultipageTiff.tif");
            ImageInput imageInput = pdf.AddImage(imageResource);
            //ImageInput imageInput = new ImageInput(imageResource);
            //pdf.Inputs.Add(imageInput);

            //ImageInput imageInput = pdf.AddImage("samples/creating-a-page-designer/MultiPageTiff.tif");
            
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
