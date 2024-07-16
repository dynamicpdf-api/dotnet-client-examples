

using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    public class MergeSolution
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            var inputA = pdf.AddPdf(new PdfResource(basePath + "/merge-pdfs-pdf-endpoint/DocumentA.pdf"));

            pdf.AddPdf(new PdfResource(basePath + "/merge-pdfs-pdf-endpoint/DocumentB.pdf"));

            pdf.AddWord(new WordResource(basePath + "/users-guide/Doc1.docx"));

            ImageInput input = pdf.AddImage(new ImageResource(basePath + "/image-conversion/testimage.tif"));
            input.ScaleX = (float)0.5;
            input.ScaleY = (float)0.5;

            LayoutDataResource layoutData = new LayoutDataResource(basePath + "/creating-pdf-dlex-layout-endpoint/creating-pdf-dlex-layout.json");
            pdf.AddDlex("samples/creating-pdf-dlex-layout-endpoint/creating-pdf-dlex-layout.dlex", layoutData);

            HtmlResource resource = new HtmlResource(System.IO.File.ReadAllText(basePath + "/users-guide/products.html"));
            pdf.AddHtml(resource);

            Console.WriteLine(pdf.GetInstructionsJson(true));


            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/merge-pdfs-solution-output-csharp.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
