using DynamicPDF.Api;
using DynamicPdfClientLibraryExamples.Utility;
using System;
using System.IO;

namespace DlexLayoutRemoteTemplateExample
{
    class Program
    {
		private const string basePath = "Resources/";
		private const string outputPath = "Output/";
		private const string apiKey = "DP--api-key--";

		static void Main(string[] args)
        {
			FileUtility.CreatePath(outputPath);
			RunFromLocal(apiKey, basePath, outputPath);
        }

		public static void RunFromLocal(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(FileUtility.GetPath(basePath + "ExampleTemplate.json"));
			DlexResource dlexResource = new DlexResource(FileUtility.GetPath(basePath + "ExampleTemplate.dlex"), "ExampleTemplate.dlex");
			DlexLayout dlexEndpoint = new DlexLayout(dlexResource, layoutData);
			dlexEndpoint.AddAdditionalResource(FileUtility.GetPath(basePath + "template_example.pdf"), "template_example.pdf");
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(FileUtility.GetPath(outputPath + "local-example-output.pdf"), response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}
