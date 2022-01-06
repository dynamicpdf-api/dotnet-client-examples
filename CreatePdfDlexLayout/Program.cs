using DynamicPDF.Api;
using System;
using System.IO;

// resources available at cloud.dynamicpdf.com Create PDF (dlex-layout Endpoint) in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-layout/tutorial-dlex-layout

namespace CreatingPdfDlexLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "C:/temp/dynamicpdf-api-samples/creating-pdf-dlex-layout-endpoint/");
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
