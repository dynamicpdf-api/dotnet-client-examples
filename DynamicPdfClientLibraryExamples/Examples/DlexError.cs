using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class DlexError
    {
		public static void Run(String apiKey, String basePath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;

			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(basePath + "dlex-error-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}
