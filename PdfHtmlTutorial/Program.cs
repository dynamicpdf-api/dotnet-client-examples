using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace PdfHtmlTutorial
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/converting-html-pdf-endpoint/";
        private const string outputPath = "Output";
        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            PdfHtmlExample.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
        }
    }
}
