using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace ExtractPdfText
{
    class Program
    {

        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/extract-text-pdf-text-endpoint";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            PdfTextExample.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
