using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class PdfBarcode
    {
        public static void Run(string apiKey, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PageInput pageInput = pdf.AddPage(1008, 612);
        
            Code11BarcodeElement code11BarcodeElement = new Code11BarcodeElement("12345678", ElementPlacement.TopCenter, 200, 50, 50);
            code11BarcodeElement.Color = RgbColor.Red;

            pageInput.Elements.Add(code11BarcodeElement);
           // Console.WriteLine(pdf.GetInstructionsJson(true));

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/create-barcode-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}