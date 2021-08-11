using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class DlexLayoutExample
    {

        public static void DlexLayoutExampleOne(String apiKey, String basePath)
        {
            LayoutDataResource layoutData = new LayoutDataResource(basePath + "/AllReportElementsData.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/getting-started/AllReportElements.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;
            PdfResponse response = dlexEndpoint.Process();
            if (response.ErrorJson == null)
            {
                File.WriteAllBytes(basePath + "/dlex-output.pdf", (byte[])response.Content);
            } else
            {
                Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
        }
    }
}
