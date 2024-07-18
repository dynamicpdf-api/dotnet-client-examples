using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class CallDlexLayoutUsingTemplateExample
    {
		public static void Run(String apiKey, String basePath, String outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/csharp-dlex-layout-using-template-example-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}
