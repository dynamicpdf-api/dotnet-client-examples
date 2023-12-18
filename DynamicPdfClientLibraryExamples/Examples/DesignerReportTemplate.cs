using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class DesignerReportTemplate
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            LayoutDataResource layoutData = new LayoutDataResource(basePath + "invoice.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-report-template-designer/invoice.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;
            PdfResponse response = dlexEndpoint.Process();

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/invoice-csharp-output.pdf", response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
