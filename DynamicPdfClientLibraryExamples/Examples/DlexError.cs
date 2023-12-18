using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class DlexError
    {
		public static void Run(string apiKey, string basePath, string outputPath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;

			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(outputPath + "/dlex-error-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}
	}
}
