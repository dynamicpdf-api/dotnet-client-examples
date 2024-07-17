using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class FormFieldFlattenAndRemove
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            PdfResource resource = new PdfResource(basePath + "fw9AcroForm_14.pdf");
            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            FormField field = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            field.Flatten = true;
            pdf.FormFields.Add(field);

            FormField field1 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            field1.Remove = true;
            pdf.FormFields.Add(field1);

            FormField field2 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            field2.Flatten = true;
            pdf.FormFields.Add(field2);

            FormField field3 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            field3.Flatten = false;
            pdf.FormFields.Add(field3);

            FormField field4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            field4.Remove = true;
            pdf.FormFields.Add(field4);

            FormField field5 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            field5.Remove = true;
            pdf.FormFields.Add(field5);

            PdfResponse response = pdf.Process();

            //Console.WriteLine(pdf.GetInstructionsJson(true));


            if (response.ErrorJson != null)
            {
                Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.ErrorJson));
            }
            else
            {
                File.WriteAllBytes(outputPath + "/form-field-flatten-output.pdf", response.Content);
            }

        }
    }
}
