using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace GetPdfInfoExample
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/get-pdf-info-pdf-info-endpoint/";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            GetPdfInfo.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
