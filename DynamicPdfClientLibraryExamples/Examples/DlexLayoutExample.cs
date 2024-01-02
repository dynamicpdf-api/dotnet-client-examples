using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
	class DlexLayoutExample
	{

		public static void Run(string apiKey, string basePath, string outputPath)
		{
			RunFromCloud(apiKey, basePath, outputPath);
			RunFromLocal(apiKey, basePath, outputPath);
		}

		public static void RunFromCloud(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/dlex-layout/SimpleReportWithCoverPage.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/csharp-dlex-layout-example-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}

		public static void RunFromLocal(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
			DlexResource dlexResource = new DlexResource(basePath + "SimpleReportWithCoverPage.dlex", "SimpleReportWithCoverPage.dlex");
			DlexLayout dlexEndpoint = new DlexLayout(dlexResource , layoutData);
			dlexEndpoint.AddAdditionalResource(basePath + "NorthwindLogo.gif", "NorthwindLogo.gif");
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/csharp-dlex-layout-local-example-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}