using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace ImageInfo
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/image-info/";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            ImageInfoExample.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
