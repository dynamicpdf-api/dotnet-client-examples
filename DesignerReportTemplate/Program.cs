using System;
using DynamicPDF.Api;
using System.IO;

namespace DesignerReportTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-samples/using-dlex-layout/");
        }

        public static void Run(string apiKey, string basePath)
        {
            LayoutDataResource layoutData = new LayoutDataResource(basePath + "invoice-local.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-report-template-designer/invoice.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;
            PdfResponse response = dlexEndpoint.Process();

            if(response.IsSuccessful)
            {
                File.WriteAllBytes(basePath + "invoice-csharp-output.pdf", response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
