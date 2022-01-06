using DynamicPDF.Api;
using System;

namespace PdfInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "C:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void Run(String key, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/DocumentA.pdf");
            PdfInfo pdfInfo = new PdfInfo(resource);
            pdfInfo.ApiKey = key;
            PdfInfoResponse response = pdfInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
