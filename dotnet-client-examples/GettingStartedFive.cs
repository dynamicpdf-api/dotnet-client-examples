using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class GettingStartedFive
    {
        public static void Run(String apiKey, String basePath)
        {
            LayoutDataResource layoutDataResource = new LayoutDataResource(@"C:/holding/instructions-examples/getting-started-data.json");
            DlexLayout dlexLayout = new DlexLayout("samples/shared/dlex/getting-started.dlex", layoutDataResource);
            dlexLayout.ApiKey = apiKey;

            PdfResponse pdfResponse = dlexLayout.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(basePath + "/getting-started-output.pdf", pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }
    }
}
