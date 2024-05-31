
using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class PdfDlexExample
    {

		public static void RunLocal(string apiKey, string basePath, string outputPath)
		{
			Pdf pdf = new Pdf();
			pdf.ApiKey = apiKey;
			DlexResource dlexResource = new DlexResource(basePath + "SimpleReportWithCoverPage.dlex");
			LayoutDataResource layout = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
			pdf.AddDlex(dlexResource, layout);
			pdf.AddAdditionalResource(basePath + "Northwind Logo.gif");

			PdfResponse pdfResponse = pdf.Process();

			if (pdfResponse.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/create-pdf-pdf-local-output.pdf", pdfResponse.Content);
			}
			else
			{
				Console.WriteLine(pdfResponse.ErrorJson);
			}

		}

		public static void RunRemote(string apiKey, string basePath, string outputPath)
		{
			Pdf pdf = new Pdf();
			pdf.ApiKey = apiKey;
			LayoutDataResource layout = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
			pdf.AddDlex("samples/creating-pdf-pdf-endpoint/SimpleReportWithCoverPage.dlex", layout);
			
			PdfResponse pdfResponse = pdf.Process();

			if (pdfResponse.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/create-pdf-pdf-remote-output.pdf", pdfResponse.Content);
			}
			else
			{
				Console.WriteLine(pdfResponse.ErrorJson);
			}

		}


	}
}
