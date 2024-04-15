using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class ExcelConversion
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            pdf.AddExcel(new ExcelResource(basePath + "/sample-data.xlsx"));
            

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/excel-example-output-csharp.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
