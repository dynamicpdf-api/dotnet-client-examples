using DynamicPDF.Api;
using System;
using System.IO;

namespace CreatingPdfDlexLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.7vATWolKJ4xdaefbf/pTgSW7uGWofsZAKctZ1J/hzV9yTrzDvmDI1lwT", "C:/temp/dynamicpdf-api-samples/creating-pdf-dlex-layout-endpoint/");
        }

        public static void Run(String apiKey, String basePath)
        {
            {
                LayoutDataResource layoutData = new LayoutDataResource(basePath + "create-pdf-dlex-layout.json");
                DlexLayout dlexEndpoint = new DlexLayout("samples/creating-pdf-dlex-layout-endpoint/create-pdf-dlex-layout.dlex", layoutData);
                dlexEndpoint.ApiKey = apiKey;
                PdfResponse response = dlexEndpoint.Process();
                if (response.IsSuccessful)
                {
                    File.WriteAllBytes(basePath + "create-pdf-dlex-output.pdf", (byte[])response.Content);
                }
                else
                {
                    Console.WriteLine(response.ErrorJson);
                }
            }
        }
    }
}
