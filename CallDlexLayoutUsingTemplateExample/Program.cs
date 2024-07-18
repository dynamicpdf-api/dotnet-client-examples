

using DynamicPdfClientLibraryExamples.Utility;

namespace CallDlexLayoutUsingTemplateExample
{
	class Program
	{
		private const string basePath = "../DynamicPdfClientLibraryExamples/Resources//creating-a-page-template-designer/";
		private const string outputPath = "Output";

		private const string apiKey = "DP--api-key--";
		
		static void Main(string[] args)
		{
			FileUtility.CreatePath(outputPath);
			DynamicPdfClientLibraryExamples.Examples.CallDlexLayoutUsingTemplateExample.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
					
		}



	}
}

