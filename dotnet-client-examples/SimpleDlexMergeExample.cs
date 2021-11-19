using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class SimpleDlexMergeExample
    {
        public static void PdfMerge(String apiKey, String basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;
            LayoutDataResource layoutDataResource = new LayoutDataResource(@"c:/dynamicpdf/getting-started-examples/SimpleReportData.json");
            pdf.AddDlex("samples/shared/dlex/SimpleReportWithCoverPage.dlex", layoutDataResource);

            PdfResource pdfResource = new PdfResource(@"c:/dynamicpdf/getting-started-examples/DocumentA100.pdf");
            pdf.AddPdf(pdfResource);


            PdfResponse response = pdf.Process();

            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorJson);
            }
            else
            {
                File.WriteAllBytes(@"c:/dynamicpdf/getting-started-examples/simple-report-data.pdf", response.Content);
            }
        }
    }
}
