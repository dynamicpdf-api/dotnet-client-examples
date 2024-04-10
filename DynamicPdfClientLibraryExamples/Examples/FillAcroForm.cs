using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class FillAcroForm
    {
        public static void Run(string apiKey, String outputPath)
        {
            // create new pdf instance and set api key
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            //add the uncompleted form as a resource from Resource Manager
            pdf.AddPdf("samples/fill-acro-form-pdf-endpoint/fw9AcroForm_18.pdf");

            //fill out the form fields
            FormField formField = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            FormField formField2 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            FormField formField3 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            FormField formField4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            FormField formField5 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            FormField formField6 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            FormField formField7 = new FormField("topmostSubform[0].Page1[0].f1_10[0]", "17288825617");
            FormField formField8 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]", "52");
            FormField formField9 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]", "1234567");

            //add the form fields to the pdf's FormFields array
            pdf.FormFields.Add(formField);
            pdf.FormFields.Add(formField2);
            pdf.FormFields.Add(formField3);
            pdf.FormFields.Add(formField4);
            pdf.FormFields.Add(formField5);
            pdf.FormFields.Add(formField6);
            pdf.FormFields.Add(formField7);
            pdf.FormFields.Add(formField8);
            pdf.FormFields.Add(formField9);

            //call the pdf endpoint and get response
            PdfResponse response = pdf.Process();

            //if response is successful then save PDF as file
            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorJson);
            }
            else
            {
                File.WriteAllBytes(outputPath + "/form-fill-output-csharp.pdf", response.Content);
            }

        }
    }
}
