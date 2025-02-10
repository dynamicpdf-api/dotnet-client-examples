using DynamicPDF.Api;
using DynamicPdfClientLibraryExamples.Utility;
using System;
using System.IO;
using System.Net;

namespace DlexLayoutRemoteTemplateExample
{
    class Program
    {
		private const string basePath = "Resources/";
		private const string outputPath = "Output/";
		private const string apiKey = "DP--api-key--";

		private const string static_template = "https://github.com/dynamicpdf-api/dotnet-client-examples/blob/main/DlexLayoutRemoteTemplateExample/Resources/template_example.pdf";

		static void Main(string[] args)
        {
			FileUtility.CreatePath(outputPath);
			RunFromLocalWithRemoteTemplate(apiKey, basePath, outputPath);
        }

		public static void RunFromLocalWithRemoteTemplate(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(FileUtility.GetPath(basePath + "ExampleTemplate.json"));
			DlexResource dlexResource = new DlexResource(FileUtility.GetPath(basePath + "ExampleTemplate.dlex"), "ExampleTemplate.dlex");
			DlexLayout dlexEndpoint = new DlexLayout(dlexResource, layoutData);
			WebClient myWebClient = new WebClient();
			byte[] myDataBuffer = myWebClient.DownloadData(static_template);

			dlexEndpoint.AddAdditionalResource(myDataBuffer, AdditionalResourceType.Pdf, "template_example.pdf");
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(FileUtility.GetPath(outputPath + "local-remote-template-example-output.pdf"), response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}
