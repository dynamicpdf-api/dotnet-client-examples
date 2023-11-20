using DynamicPDF.Api;
using System;
using System.IO;
using System.Text;

namespace PdfHtmlCssWorkaroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
			Run("DP.xxx-api-key-xxx", "c:/temp/users-guide-resources/", "c:/temp/dynamicpdf-api-usersguide-examples/csharp-output/", "html-css-workaround.pdf");
        }

        static void Run(String apiKey, string basePath, string outputPath, string outputFile)
        {
			{
				Pdf pdf = new Pdf();
				pdf.ApiKey = apiKey;

				// add html from a path on local drive
				String tempHtml = null;
				String tempCss = null;

				tempHtml = File.ReadAllText(basePath + "example.html");
				tempCss = File.ReadAllText(basePath + "example.css");
	
				StringBuilder sb = new StringBuilder();
				sb.Append(tempHtml.Substring(0, tempHtml.IndexOf("<link")));
				sb.Append("<style>" + tempCss + "</style>");

				
				tempHtml = tempHtml.Substring(tempHtml.IndexOf("<link"));
				sb.Append(tempHtml.Substring(tempHtml.IndexOf("/>") + 2));

				Console.WriteLine(sb.ToString());

				HtmlResource resource = new HtmlResource(sb.ToString());
				pdf.AddHtml(resource, null, PageSize.Letter, PageOrientation.Portrait, 1F);

				PdfResponse pdfResponse = pdf.Process();

				if (pdfResponse.ErrorJson != null)
				{
					Console.WriteLine(pdfResponse.ErrorJson);
				}
				else
				{
					File.WriteAllBytes(outputPath + outputFile, pdfResponse.Content);
				}


			}
		}


    }
}
