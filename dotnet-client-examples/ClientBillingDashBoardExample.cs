using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class ClientBillingDashBoardExample
    {

        public static void ExampleOne(String apiKey, String basePath)
        {
            LayoutDataResource layoutData = new LayoutDataResource(basePath + "/getting-started-data.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/shared/dlex/getting-started.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;
            PdfResponse response = dlexEndpoint.Process();
            if (response.ErrorJson == null)
            {
                File.WriteAllBytes(basePath + "/client-billing-example1.pdf", (byte[])response.Content);
            }
            else
            {
                Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
        }

        public static void ExampleTwo(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.AddPdf("samples/shared/pdf/simple-form-fill.pdf");

            FormField formField = new FormField("nameField", "DynamicPDF");
            FormField formField2 = new FormField("descriptionField", "DynamicPDF CloudAPI. RealTime PDFs, Real FAST!");

            pdf.FormFields.Add(formField);
            pdf.FormFields.Add(formField2);
            pdf.ApiKey = apiKey;
            PdfResponse response = pdf.Process();

            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorJson);
            }
            else
            {
                File.WriteAllBytes(basePath + "/client-billing-example2.pdf", response.Content);
            }
        }
    }
}
