using DynamicPDF.Api;
using System;
using System.IO;

// resources available at cloud.dynamicpdf.com Getting Started Samples in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/getting-started

namespace GettingStartedInFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.TrJj2UBRFfrxiLYYD9xQryHXnFoSRKVPTBYH0LRpVWWnTZPOmgRO6yX6", "C:/holding/getting-started/");
        }

        public static void Run(String apiKey, String basePath)
        {
            // Load the Layout Data. This will normally come from a dynamic source, but in this example, it is static
            LayoutDataResource layoutDataResource = new LayoutDataResource(basePath + "getting-started.json"); 

            // Path to the DLEX in the cloud
            DlexLayout dlexLayout = new DlexLayout("samples/getting-started/getting-started.dlex", layoutDataResource);

            // Set the API Key
            dlexLayout.ApiKey = apiKey;
            // Call the dlex-layout endpoint

            PdfResponse pdfResponse = dlexLayout.Process();

            if (pdfResponse.IsSuccessful)
            {
                // Write the PDF to a file
                File.WriteAllBytes(Path.Combine(basePath, "getting-started-output.pdf"), pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
