using DynamicPDF.Api;
using System;

namespace PdfTextExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx---api-key---xxx", "C:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfText pdfText = new PdfText(resource);
            pdfText.ApiKey = apiKey;
            PdfTextResponse response = pdfText.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
