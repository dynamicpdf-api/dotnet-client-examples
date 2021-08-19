using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples.instructions
{
    class InstructionsExample
    {
		public static void DemoInstructions(String[] args)
		{
			Pdf exampleOne = InstructionsExample.topLevelMetaData();
			InstructionsExample.printOut(exampleOne, args[0], args[1], "c-sharp-top-level-metadata.pdf");
		}

		public static Pdf topLevelMetaData()
		{

			// create a blank page

			Pdf pdf = new Pdf();
			pdf.AddPage(1008, 612);

			// top level pdf document metadata

			pdf.Author = "John Doe";
			pdf.Keywords ="dynamicpdf api example pdf java instructions";
			pdf.Creator = "John Creator";
			pdf.Subject = "topLevel document metadata";
			pdf.Title = "Sample PDF";

			return pdf;
		}


		public static void printOut(Pdf pdf, String apiKey, String basePath, String outputFile)
		{
			pdf.ApiKey = apiKey;
			PdfResponse response = pdf.Process();

			if (response.ErrorJson != null)
			{
				Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.ErrorJson));
			}
			else
			{
				File.WriteAllBytes(basePath + "/" + outputFile, response.Content);
			}
		}

	}
}
