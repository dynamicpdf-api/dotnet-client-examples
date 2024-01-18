using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples.Solutions
{
    class OutlinesSolution
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {

			Pdf pdf = new Pdf();
			pdf.ApiKey = apiKey;

			PageInput pageInput = pdf.AddPage();
			TextElement element = new TextElement("Hello World 1", ElementPlacement.TopCenter);
			pageInput.Elements.Add(element);

			PageInput pageInput1 = pdf.AddPage();
			TextElement element1 = new TextElement("Hello World 2", ElementPlacement.TopCenter);
			pageInput1.Elements.Add(element1);

			PageInput pageInput2 = pdf.AddPage();
			TextElement element2 = new TextElement("Hello World 3", ElementPlacement.TopCenter);
			pageInput2.Elements.Add(element2);


			var inputA = pdf.AddPdf(new PdfResource(basePath + "PdfOutlineInput.pdf"));
			inputA.Id = "pdfoutlineinput";



			Outline rootOutline = pdf.Outlines.Add("Root Outline");

			rootOutline.Children.Add("Page 1", pageInput);
			rootOutline.Children.Add("Page 2", pageInput1);
			rootOutline.Children.Add("Page 3", pageInput2);
			rootOutline.Children.AddPdfOutlines(inputA);


			Console.WriteLine(pdf.GetInstructionsJson(true));


			PdfResponse pdfResponse = pdf.Process();

			if (pdfResponse.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/outlines-output.pdf", pdfResponse.Content);
			}
			else
			{
				Console.WriteLine(pdfResponse.ErrorJson);
			}



		}


    }
}
