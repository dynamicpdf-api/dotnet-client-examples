using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class GettingStartedInFive
    {
        public static void Run(String apiKey, String basePath, string outputPath)
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
                File.WriteAllBytes(outputPath + "/getting-started-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
