using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class DlexLayoutTutorial
    {
        public static void DlexLayoutExampleOne(String apiKey, String basePath)
        {
            LayoutDataResource layoutData = new LayoutDataResource(basePath + "getting-started-data.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/shared/dlex/getting-started.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;
            PdfResponse response = dlexEndpoint.Process();
            if (response.ErrorJson == null)
            {
                File.WriteAllBytes(basePath + "dlex-output.pdf", (byte[])response.Content);
            }
            else
            {
                Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
        }
    }
}