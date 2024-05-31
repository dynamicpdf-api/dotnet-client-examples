using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
	public class DlexLayoutExample
	{

		public static void Run(string apiKey, string basePath, string outputPath)
		{
			RunFromCloud(apiKey, basePath, outputPath);
			RunFromLocal(apiKey, basePath, outputPath);
		}

		public static void RunFromCloud(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "creating-pdf-dlex-layout.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-pdf-dlex-layout-endpoint/creating-pdf-dlex-layout.dlex", layoutData);
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
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "creating-pdf-dlex-layout.json");
			DlexResource dlexResource = new DlexResource(basePath + "creating-pdf-dlex-layout.dlex", "creating-pdf-dlex-layout.dlex");
			DlexLayout dlexEndpoint = new DlexLayout(dlexResource , layoutData);
			dlexEndpoint.AddAdditionalResource(basePath + "creating-pdf-dlex-layout.png", "creating-pdf-dlex-layout.png");
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