using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace DlexLayoutTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "DP--api-key--";
            string basePath = "../DynamicPdfClientLibraryExamples/Resources/creating-pdf-dlex-layout-endpoint/";
            string outputPath = "Output";

            FileUtility.CreatePath(outputPath);
            DlexLayoutExample.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));

        }
    }
}
