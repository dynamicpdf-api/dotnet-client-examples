using DynamicPDF.Api;
using System;
using System.IO;

namespace DlexLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
			Run("DP.xxx--api-key--xxx", "C:/temp/dynamicpdf-api-samples/create-pdf-dlex/");
		}

		public static void Run(String apiKey, String basePath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "SimpleReportWithCoverPage.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/dlex-layout/SimpleReportWithCoverPage.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(basePath + "csharp-dlex-layout-example-output.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}

	}
}
