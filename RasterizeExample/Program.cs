using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace RasterizeExample
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/pdf-image/";
        private const string outputPath = "Output/";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            PdfImageExample.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
        }
    }
}
