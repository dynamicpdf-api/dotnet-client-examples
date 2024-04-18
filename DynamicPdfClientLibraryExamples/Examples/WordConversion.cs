using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class WordConversion
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            pdf.AddWord(new WordResource(basePath + "/Doc1.docx"));
            

            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/word-example-output-csharp.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }
    }
}
