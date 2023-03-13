using DynamicPDF.Api;
using System;
using System.IO;

namespace CallDlexLayoutUsingTemplateExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Run("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-samples/dlex-layout-template/");			
		}

		public static void Run(String apiKey, String basePath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(basePath + "csharp-dlex-layout-example2-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}

	}
}

