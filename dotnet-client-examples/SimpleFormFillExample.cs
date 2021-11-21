using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class SimpleFormFillExample
    {
        public static void FormFill(String apiKey, String basePath)
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
                File.WriteAllBytes(basePath + "simple-form-fill-output.pdf", response.Content);
            }
        }
    }
}
