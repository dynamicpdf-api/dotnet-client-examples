using DynamicPDF.Api;
using System;
using System.IO;

namespace DlexError
{
    class Program
    {
		static void Main(string[] args)
		{
			//Run("DP.xxx-api-key-xxx", "c:/temp/dlexerror/");
			DlexResourceExample();
		}

		public static void Run(String apiKey, String basePath)
		{
			LayoutDataResource layoutData = new LayoutDataResource(basePath + "consent-form.json");
			DlexLayout dlexEndpoint = new DlexLayout("samples/creating-a-page-template-designer/consent-form.dlex", layoutData);
			dlexEndpoint.ApiKey = apiKey;
			
			PdfResponse response = dlexEndpoint.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes(basePath + "outputA.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}
		}


		public static void DlexResourceExample()
		{
			Pdf pdf = new Pdf();
			pdf.ApiKey = "DP.+pFFWi0szG/OW8fdYBESOhtbtUpwkMULfodXuuA52sPIQpjYP3djUw1Z";
			DlexResource dlexResource = new DlexResource("c:/temp/dlexerror/consent-formB.dlex");
			LayoutDataResource layout = new LayoutDataResource("c:/temp/dlexerror/consent-formB.json");
			pdf.AddDlex(dlexResource, layout);
			pdf.AddAdditionalResource("c:/temp/dlexerror/consent-form.pdf");

			PdfResponse response = pdf.Process();

			if (response.IsSuccessful)
			{
				File.WriteAllBytes("c:/temp/dlexerror/outputA.pdf", response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorJson);
			}

		}
	}
}
