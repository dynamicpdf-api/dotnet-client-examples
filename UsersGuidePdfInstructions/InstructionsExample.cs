using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UsersGuidePdfInstructions
{
    class InstructionsExample
    {
		public static void DemoInstructions(String apiKey, String basePath)
		{

			/*
				Pdf exampleOne = InstructionsExample.TopLevelMetaData();
				InstructionsExample.printOut(exampleOne, apiKey, basePath, "c-sharp-top-level-metadata-output.pdf");

				Pdf exampleTwo = InstructionsExample.FontsExample(basePath);
				InstructionsExample.printOut(exampleTwo, apiKey, basePath, "c-sharp-font-output.pdf");

				Pdf exampleThree = InstructionsExample.SecurityExample(basePath);
				InstructionsExample.printOut(exampleThree, apiKey, basePath, "c-sharp-security-output.pdf");

				Pdf exampleFour = InstructionsExample.MergeExample(basePath);
				InstructionsExample.printOut(exampleFour, apiKey, basePath, "c-sharp-merge-output.pdf");

				Pdf exampleFive = InstructionsExample.FormFieldsExample(basePath);
				InstructionsExample.printOut(exampleFive, apiKey, basePath, "c-sharp-form-fields-output.pdf");

				Pdf exampleSix = InstructionsExample.AddOutlinesNewPdf();
				InstructionsExample.printOut(exampleSix, apiKey, basePath, "c-sharp-new-outline-output.pdf");

				Pdf exampleSeven = InstructionsExample.AddOutlinesExistingPdf(basePath);
				InstructionsExample.printOut(exampleSeven, apiKey, basePath, "c-sharp-outline-existing-output.pdf");

				Pdf exampleEight = InstructionsExample.TemplateExample(basePath);
				InstructionsExample.printOut(exampleEight, apiKey, basePath, "c-sharp-template-output.pdf");

				Pdf exampleNine = InstructionsExample.BarcodeExample(basePath);
				InstructionsExample.printOut(exampleNine, apiKey, basePath, "c-sharp-barcode-output.pdf");

				Pdf exampleTen = InstructionsExample.imageExample();
				InstructionsExample.printOut(exampleTen, apiKey, basePath, "image-output.pdf");


				Pdf exampleEleven = InstructionsExample.dlexResourceExample();
				InstructionsExample.printOut(exampleEleven, apiKey, basePath, "dlex-resource-output.pdf");

			*/

			Pdf exampleTwelve = InstructionsExample.GoogleFontsExample();
			InstructionsExample.printOut(exampleTwelve, apiKey, basePath, "google-fonts-c-sharp-output.pdf");
				

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
				Console.WriteLine(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));
				Console.WriteLine("==================================================================");
				File.WriteAllBytes(basePath + outputFile, response.Content);
			}
		}


		public static Pdf GoogleFontsExample()
		{

			Pdf pdf = new Pdf();

			PageInput pageInput = pdf.AddPage(1008, 612);
			PageNumberingElement pageNumberingElement = new PageNumberingElement("A", ElementPlacement.TopRight);
			pageNumberingElement.Color = RgbColor.Red;
			pageNumberingElement.Font = Font.Helvetica;
			pageNumberingElement.FontSize = 12;

			
			PageNumberingElement pageNumberingElementTwo = new PageNumberingElement("Test", ElementPlacement.TopLeft);
			pageNumberingElementTwo.Color = RgbColor.DarkOrange;
			pageNumberingElementTwo.Font =  Font.Google("Borel", false, false);
			pageNumberingElementTwo.FontSize = 42;


			pageInput.Elements.Add(pageNumberingElement);
			pageInput.Elements.Add(pageNumberingElementTwo);

			return pdf;
		}


		public static Pdf dlexResourceExample()
        {
			Pdf pdf = new Pdf();
			DlexResource dlex = new DlexResource("c:/temp/dlex-resource/SimpleReportWithCoverPage.dlex");
			LayoutDataResource layout = new LayoutDataResource("c:/temp/dlex-resource/SimpleReportWithCoverPage.json");


			pdf.AddDlex(dlex, layout);

			return pdf;

        }

		public static Pdf imageExample()
        {
			Pdf pdf = new Pdf();
			ImageResource ir = new ImageResource("C:/temp/dynamicpdf-api-samples/image-info/getting-started.png", "getting-started.png");
			pdf.AddImage(ir);
			return pdf;
        }

		public static Pdf TopLevelMetaData()
		{

			// create a blank page

			Pdf pdf = new Pdf();
			pdf.AddPage(1008, 612);

            // top level pdf document metadata

			pdf.Author = "John Doe";
			pdf.Keywords = "dynamicpdf api example pdf java instructions";
			pdf.Creator = "Alex Doe";
			pdf.Subject = "topLevel document metadata";
			pdf.Title = "Sample PDF";

			return pdf;
		}

		public static Pdf FontsExample(String basePath)
		{
				
			Pdf pdf = new Pdf();

			PageInput pageInput = pdf.AddPage(1008, 612);
			PageNumberingElement pageNumberingElement =
				new PageNumberingElement("A", ElementPlacement.TopRight);
			pageNumberingElement.Color = RgbColor.Red;
			pageNumberingElement.Font = Font.Helvetica;
			pageNumberingElement.FontSize = 42;

			String cloudResourceName = "old_samples/shared/font/Calibri.otf";

			PageNumberingElement pageNumberingElementTwo = new PageNumberingElement("B", ElementPlacement.TopLeft);
			pageNumberingElementTwo.Color = RgbColor.DarkOrange;
			pageNumberingElementTwo.Font = new Font(cloudResourceName);
			pageNumberingElementTwo.FontSize = 32;


			String filePathFont = basePath + "cnr.otf";
			PageNumberingElement pageNumberingElementThree = new PageNumberingElement("C", ElementPlacement.TopCenter);
			pageNumberingElementThree.Color = RgbColor.Green;
			pageNumberingElementThree.Font = Font.FromFile(filePathFont);
			pageNumberingElementThree.FontSize = 42;

			pageInput.Elements.Add(pageNumberingElement);
			pageInput.Elements.Add(pageNumberingElementTwo);
			pageInput.Elements.Add(pageNumberingElementThree);

			return pdf;
		}

		public static Pdf SecurityExample(String basePath)
		{
			String fileResource = basePath + "DocumentA.pdf";
			String userName = "myuser";
			String passWord = "mypassword";
			Pdf pdf = new Pdf();
			PdfResource pdfResource = new PdfResource(fileResource);
			pdf.AddPdf(pdfResource);
			Aes256Security sec = new Aes256Security(userName, passWord);
			sec.AllowCopy = false;
			sec.AllowPrint = false;
			pdf.Security = sec;
			return pdf;
		}

		public static Pdf MergeExample(String basePath)
		{
			Pdf pdf = new Pdf();
			PdfResource resourceA = new PdfResource(basePath + "DocumentA.pdf");
			ImageResource imageResource = new ImageResource(basePath + "dynamicpdfLogo.png");
			PdfResource resourceB = new PdfResource(basePath + "DocumentB.pdf");
			pdf.AddPdf(resourceA);
			pdf.AddImage(imageResource);
			pdf.AddPdf(resourceB);
			return pdf;
		}

		public static Pdf FormFieldsExample(String basePath)
		{
			Pdf pdf = new Pdf();
			pdf.AddPdf(new PdfResource(basePath + "simple-form-fill.pdf"));
			FormField formField = new FormField("nameField", "DynamicPdf");
			FormField formField2 = new FormField("descriptionField", "RealTime Pdf's. Real FAST!");
			pdf.FormFields.Add(formField);
			pdf.FormFields.Add(formField2);
			return pdf;
		}

		public static Pdf AddOutlinesNewPdf()
		{
			Pdf pdf = new Pdf();

			PageInput pageInput = pdf.AddPage();
			TextElement element = new TextElement("Hello World 1", ElementPlacement.TopCenter);
			pageInput.Elements.Add(element);

			PageInput pageInput1 = pdf.AddPage();
			TextElement element1 = new TextElement("Hello World 2", ElementPlacement.TopCenter);
			pageInput1.Elements.Add(element1);

			PageInput pageInput2 = pdf.AddPage();
			TextElement element2 = new TextElement("Hello World 3", ElementPlacement.TopCenter);
			pageInput2.Elements.Add(element2);

			Outline rootOutline = pdf.Outlines.Add("Root Outline");

			rootOutline.Children.Add("Page 1", pageInput);
			rootOutline.Children.Add("Page 2", pageInput1);
			rootOutline.Children.Add("Page 3", pageInput2);

			return pdf;
		}

		public static Pdf AddOutlinesExistingPdf(String basePath)
		{
			Pdf pdf = new Pdf();
			pdf.Author = "John Doe";
			pdf.Title = "Existing Pdf Example";

			PdfResource resource = new PdfResource(basePath + "AllPageElements.pdf");
			PdfInput input = pdf.AddPdf(resource);
			input.Id = "AllPageElements";
			pdf.Inputs.Add(input);

			PdfResource resource1 = new PdfResource(basePath + "OutlineExisting.pdf");
			PdfInput input1 = pdf.AddPdf(resource1);
			input1.Id = "outlineDoc1";
			pdf.Inputs.Add(input1);

			Outline rootOutline = pdf.Outlines.Add("Imported Outline");
			rootOutline.Expanded = true;

			rootOutline.Children.AddPdfOutlines(input);
			rootOutline.Children.AddPdfOutlines(input1);

			return pdf;

		}

		public static Pdf TemplateExample(String basePath)
		{
			Pdf pdf = new Pdf();
			pdf.Author = "John User";
			pdf.Title = "Template Example One";
			PdfResource resource = new PdfResource(basePath + "/DocumentA.pdf");
			PdfInput input = new PdfInput(resource);
			pdf.Inputs.Add(input);

			Template template = new Template("Temp1");
			TextElement element = new TextElement("Hello World", ElementPlacement.TopCenter);
			template.Elements.Add(element);
			input.Template = template;
			return pdf;
		}

		public static Pdf BarcodeExample(String basePath)
		{
			Pdf pdf = new Pdf();
			PdfResource resource = new PdfResource(basePath + "/DocumentA.pdf");
			PdfInput input = new PdfInput(resource);
			pdf.Inputs.Add(input);

			Template template = new Template("Temp1");

			AztecBarcodeElement element = new AztecBarcodeElement("Hello Barcode", ElementPlacement.TopCenter, 0, 500);
			template.Elements.Add(element);
			input.Template = template;
			return pdf;
		}
	}
}
