using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace PdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.TrJj2UBRFfrxiLYYD9xQryHXnFoSRKVPTBYH0LRpVWWnTZPOmgRO6yX6", "C:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;
            pdf.Author = "John Doe";
            pdf.Title = "My Blank PDF Page";
            PageInput pageInput = pdf.AddPage(1008, 612);
            PageNumberingElement pageNumberingElement = new PageNumberingElement("1", ElementPlacement.TopRight);
            pageNumberingElement.Color = RgbColor.Red;
            pageNumberingElement.Font = Font.Courier;
            pageNumberingElement.FontSize = 24;
            pageInput.Elements.Add(pageNumberingElement);
            PdfResponse pdfResponse = pdf.Process();
            File.WriteAllBytes(basePath + "pdf-page-example-output.pdf", pdfResponse.Content);
        }
    }
}
