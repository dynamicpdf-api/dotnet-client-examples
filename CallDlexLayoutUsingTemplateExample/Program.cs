using DynamicPDF.Api;
using System;
using System.IO;

namespace CallDlexLayoutUsingTemplateExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Run("", "C:/temp/dynamicpdf-api-samples/dlex-layout-template/", "csharp-dlex-layout-example2-output.pdf");


		}

		public static void Run(String apiKey, String basePath, String outputFile)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(basePath + outputFile, response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}

	}
}

