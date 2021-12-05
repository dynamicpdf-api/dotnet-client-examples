using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class FormFillExample
    {
        public static void FormFill(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            PdfResource pdfResource = new PdfResource(basePath + "fw9AcroForm_18.pdf");
            pdf.AddPdf(pdfResource);

            FormField formField = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            FormField formField2 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            FormField formField3 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            FormField formField4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            FormField formField5 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            FormField formField6 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            FormField formField7 = new FormField("topmostSubform[0].Page1[0].f1_10[0]", "17288825617");
            FormField formField8 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]", "1234567");
            FormField formField9 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]", "1234567");
            pdf.FormFields.Add(formField);
            pdf.FormFields.Add(formField2);
            pdf.FormFields.Add(formField3);
            pdf.FormFields.Add(formField4);
            pdf.FormFields.Add(formField5);
            pdf.FormFields.Add(formField6);
            pdf.FormFields.Add(formField7);
            pdf.FormFields.Add(formField8);
            pdf.FormFields.Add(formField9);
            pdf.ApiKey = apiKey;
            PdfResponse response = pdf.Process();

            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorJson);
            }
            else
            {
                File.WriteAllBytes(basePath + "taxcompleted.pdf", response.Content);
            }
        }
    }
}
