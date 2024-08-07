﻿using DlexLayoutObjectExample.Examples.ReportClasses;
using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;


namespace DynamicPdfClientLibraryExamples.Examples
{
    class DlexLayoutObjectExample
    {

		public static void Run(string apiKey, string outputPath)
		{
			Pdf pdf = DeserializeJsonDlexExample();
			PrintOut(pdf, apiKey, outputPath, "/dlex-layout-object-csharp-output.pdf");
		}

		private static Pdf DeserializeJsonDlexExample()
		{
			Product p1 = new Product();
			p1.ProductID = 17;
			p1.ProductName = "Alice Mutton";
			p1.QuantityPerUnit = "20 - 1 kg tins";
			p1.UnitPrice = 39;
			p1.Discontinued = true;

			Product p2 = new Product();
			p2.ProductID = 3;
			p2.ProductName = "Aniseed Syrup";
			p2.QuantityPerUnit = "12 - 550 ml bottles";
			p2.UnitPrice = 10;
			p2.Discontinued = false;



			SimpleReport simpleReport = new SimpleReport();
			simpleReport.Products = new List<Product>();
			simpleReport.Products.Add(p1);
			simpleReport.Products.Add(p2);


			Pdf pdf = new Pdf();
			LayoutDataResource layout = new LayoutDataResource(simpleReport);
			pdf.AddDlex("samples/creating-pdf-pdf-endpoint/SimpleReportWithCoverPage.dlex", layout);

			return pdf;

		}


		private static void PrintOut(Pdf pdf, String apiKey, String outputPath, String outputFile)
		{
			pdf.ApiKey = apiKey;
			PdfResponse response = pdf.Process();

			if (response.ErrorJson != null)
			{
				Console.WriteLine(response.ErrorJson);
			}
			else
			{
				File.WriteAllBytes(outputPath + outputFile, response.Content);
			}
		}
	}
}
