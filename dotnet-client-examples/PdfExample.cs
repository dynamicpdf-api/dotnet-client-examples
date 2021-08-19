using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class PdfExample
    {
        public static void PdfExampleOne(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;
            pdf.Author = "John Doe";
            pdf.Title = "My Blank PDF Page";
            PageInput pageInput = pdf.AddPage(1008, 612);
            PageNumberingElement pageNumberingElement = 
                new PageNumberingElement("1", ElementPlacement.TopRight);
            pageNumberingElement.Color = RgbColor.Red;
            pageNumberingElement.Font = Font.Courier;
            pageNumberingElement.FontSize = 24;
            pageInput.Elements.Add(pageNumberingElement);
            PdfResponse pdfResponse = pdf.Process();
            File.WriteAllBytes(basePath + "/pageExample.pdf", pdfResponse.Content);
        }
    }
}
