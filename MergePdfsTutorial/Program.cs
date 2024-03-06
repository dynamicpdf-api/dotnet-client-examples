using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;


// This is the from the Merge PDFs Tutorial and uses the MergePdfs.cs class in the 
// DynamicPdfClientLibraryExamples

namespace MergePdfsTutorial
{
    class Program
    {

        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources";
        private const string outputPath = "Output";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            MergePdfs.Run(apiKey, FileUtility.GetPath(basePath + "/merge-pdfs-pdf-endpoint/"), FileUtility.GetPath(outputPath));
        }
    }
}
