using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
	class DlexLayoutExample
	{

		public static void Run(string apiKey, string basePath, string outputPath)
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
	}
}