using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace WordExcelExamples
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/users-guide/";
        private const string outputPath = "Output";

        private const string apiKey = "DP.ayD+TI8ncTr/GOLDXMvQzSU9JUvupmbPC2t14/A7nsLYTrsu7Xb/6v0z";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            WordExcelStream.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
        }
    }
}
