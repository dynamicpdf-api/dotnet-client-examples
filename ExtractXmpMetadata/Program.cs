using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace ExtractXmpMetadata
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/get-xmp-metadata-pdf-xmp-endpoint";

        private const string apiKey = "DP.TakXME1TKtAIpSDgyS1+UxvM2UqQMihEmu9pkxDpUvJcS4UsqPA5ux5c";

        static void Main(string[] args)
        {
            GetXmpMetadata.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
