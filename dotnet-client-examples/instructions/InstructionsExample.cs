using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPdfCloudApiClientExamples.instructions
{
    class InstructionsExample
    {


		public static Pdf MergeOptions(String basePath)
        {
			String cloudResource = "samples/shared/pdf/documentA.pdf";
			String fileResource = basePath + "/documentB.pdf";

			// add pdf from cloud resources

			Pdf pdf = new Pdf();
			pdf.AddPdf(cloudResource);

			// add pdf from local file path

			PdfResource pdfResource = new PdfResource(fileResource);
			pdf.AddPdf(pdfResource);
			return pdf;
		}

		public static Pdf MergingExample(String basePath)
		{

			String cloudResource = "samples/shared/pdf/documentA.pdf";
			String fileResource = basePath + "/documentB.pdf";

			// add pdf from cloud resources

			Pdf pdf = new Pdf();
			pdf.AddPdf(cloudResource);

			// add pdf from local file path

			PdfResource pdfResource = new PdfResource(fileResource);
			pdf.AddPdf(pdfResource);

			// add blank page to pdf

			PageInput pageInput = pdf.AddPage(1008, 612);

			// add image to pdf from cloud api

			pdf.AddImage("samples/shared/image/Image3.png");

			// add image to pdf from local file system

			ImageResource imageResource = new ImageResource(basePath + "/Image1.jpg");
			pdf.AddImage(imageResource);

			// add dlex to pdf from cloud

			LayoutDataResource layoutData = new LayoutDataResource(basePath + "/getting-started-data.json");
			pdf.AddDlex("samples/getting-started/getting-started.dlex", layoutData);

			// add dlex to pdf from local

			DlexResource dlexResource = new DlexResource(basePath + "/example-two.dlex");
			layoutData = new LayoutDataResource(basePath + "/example-two.json");
			pdf.AddDlex(dlexResource, layoutData);

			return pdf;

		}

		public static Pdf AddOutlinesExistingPdf(String basePath)
		{
			Pdf pdf = new Pdf();
			pdf.Author = "John Doe";
			pdf.Title = "Existing Pdf Example";

			PdfResource resource1 = new PdfResource(basePath + "/DocumentA100.pdf");
			PdfInput input1 = pdf.AddPdf(resource1);
			input1.Id = "document2";

			PdfResource resource2 = new PdfResource(basePath + "/Invoice.pdf");
			PdfInput input2 = pdf.AddPdf(resource2);
			input2.Id = "invoice";

			Outline rootOutline = new Outline("Root Outline");
			rootOutline.Expanded = true;

			Outline outline1 = new Outline("DocumentA 100");
			outline1.Expanded = true;

			GoToAction linkTo2 = new GoToAction(input1);
			linkTo2.PageOffset = 0;
			linkTo2.PageZoom = PageZoom.FitPage;
			outline1.Action = linkTo2;

			Outline outline2 = new Outline("Invoice");
			outline2.Expanded = true;

			GoToAction linkTo = new GoToAction(input2);
			outline2.Action = linkTo;

			rootOutline.Children.Add(outline1);
			rootOutline.Children.Add(outline2);

			pdf.Outlines.Add(rootOutline);
			return pdf;

		}

		public static Pdf AddOutlinesForNewPdf()
		{
			String name = "TextElement";
			Pdf pdf = new Pdf();
			pdf.Author = "John Doe";
			pdf.Title = "Sample Pdf";

			PageInput pageInput = pdf.AddPage();
			pageInput.Id = "page1";
			TextElement element = new TextElement("Hello World 1", ElementPlacement.TopCenter);
			pageInput.Elements.Add(element);

			PageInput pageInput1 = pdf.AddPage();
			pageInput1.Id = "page2";
			TextElement element1 = new TextElement("Hello World 2", ElementPlacement.TopCenter);
			pageInput1.Elements.Add(element1);

			PageInput pageInput2 = pdf.AddPage();
			pageInput2.Id = "page3";
			TextElement element2 = new TextElement("Hello World 3", ElementPlacement.TopCenter);
			pageInput2.Elements.Add(element2);


			Outline rootOutline = new Outline("Root Outline");
			rootOutline.Expanded = true;

			Outline outline = new Outline("Page 1");
			outline.Expanded = true;
			GoToAction linkTo = new GoToAction(pageInput);
			outline.Action = linkTo;

			Outline outline2 = new Outline("Page 2");
			outline2.Expanded = true;
			GoToAction linkTo1 = new GoToAction(pageInput1);
			outline2.Action = linkTo1;

			Outline outline3 = new Outline("Page 3");
			outline3.Expanded = true;
			GoToAction linkTo3 = new GoToAction(pageInput2);
			outline3.Action = linkTo3;

			rootOutline.Children.Add(outline);
			rootOutline.Children.Add(outline2);
			rootOutline.Children.Add(outline3);

			pdf.Outlines.Add(rootOutline);

			return pdf;
		}

		public static void DemoInstructions(String[] args)
		{
			Pdf exampleOne = InstructionsExample.topLevelMetaData();
			InstructionsExample.printOut(exampleOne, args[0], args[2], "c-sharp-top-level-metadata.pdf");
			Pdf exampleTwo = InstructionsExample.SecurityExample(args[2]);
			InstructionsExample.printOut(exampleTwo, args[0], args[2], "c-sharp-security.pdf");
			Pdf exampleThree = InstructionsExample.MergingExample(args[2]);
			InstructionsExample.printOut(exampleThree, args[0], args[2], "c-sharp-merging.pdf");

			Pdf exampleFour = InstructionsExample.FormFieldsExample();
			InstructionsExample.printOut(exampleFour, args[0], args[2], "c-sharp-fonts.pdf");

			Pdf exampleFive = InstructionsExample.MergeOptions(args[2]);
			InstructionsExample.printOut(exampleFive, args[0], args[2], "c-sharp-merge-options.pdf");

			Pdf exampleSix = InstructionsExample.AddOutlinesExistingPdf(args[2]);
			InstructionsExample.printOut(exampleSix, args[0], args[2], "c-sharp-outline-existing.pdf");

			Pdf exampleSeven = InstructionsExample.AddOutlinesForNewPdf();
			InstructionsExample.printOut(exampleSeven, args[0], args[2], "c-sharp-outline-create.pdf");

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

		public static Pdf fontsExample(String basePath)
		{

			// create a blank page

			Pdf pdf = new Pdf();

			PageInput pageInput = pdf.AddPage(1008, 612);
			PageNumberingElement pageNumberingElement =
				new PageNumberingElement("A", ElementPlacement.TopRight);
			pageNumberingElement.Color = RgbColor.Red;
			pageNumberingElement.Font = Font.Helvetica;
			pageNumberingElement.FontSize = 42;

			String cloudResourceName = "samples/shared/Calibri.otf";

			PageNumberingElement pageNumberingElementTwo = new PageNumberingElement("B", ElementPlacement.TopLeft);
			pageNumberingElementTwo.Color = RgbColor.DarkOrange;
			pageNumberingElementTwo.Font = new Font(cloudResourceName);
			pageNumberingElementTwo.FontSize = 32;


			String filePathFont = basePath + "/cnr.otf";
			PageNumberingElement pageNumberingElementThree = new PageNumberingElement("C", ElementPlacement.TopCenter);
			pageNumberingElementThree.Color = RgbColor.Green;
			pageNumberingElementThree.Font = Font.FromFile(filePathFont);
			pageNumberingElementThree.FontSize = 42;

			pageInput.Elements.Add(pageNumberingElement);
			pageInput.Elements.Add(pageNumberingElementTwo);
			pageInput.Elements.Add(pageNumberingElementThree);


			return pdf;
		}

		public static Pdf FormFieldsExample()
		{
			Pdf pdf = new Pdf();
			pdf.AddPdf("samples/shared/simple-form-fill.pdf");


			FormField formField = new FormField("nameField", "DynamicPdf");
			FormField formField2 = new FormField("descriptionField", "RealTime Pdf's. Real FAST!");

			pdf.FormFields.Add(formField);
			pdf.FormFields.Add(formField2);

			return pdf;
		}


		public static Pdf SecurityExample(String basePath)
		{
			String fileResource = basePath + "/documentB.pdf";
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
				Console.WriteLine(PrettyPrintUtil.JsonPrettify(pdf.GetInstructions()));
				Console.WriteLine("==================================================================");
				File.WriteAllBytes(basePath + "/output/" + outputFile, response.Content);
			}
		}

	}
}
