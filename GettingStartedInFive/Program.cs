﻿using DynamicPDF.Api;
using System;
using System.IO;

namespace GettingStartedInFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.jNFADSRTMGk60fv4+QY1qID9bzpp+mrkC8IU8wcWtl2wSYcQFV1S3Mww", "C:/temp/dynamicpdf-api-samples/");
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
                // Something went wrong
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}