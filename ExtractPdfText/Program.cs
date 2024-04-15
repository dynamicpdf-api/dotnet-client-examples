using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace ExtractPdfText
{
    class Program
    {

        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/extract-text-pdf-text-endpoint";

        private const string apiKey = "DP.aKwxGlX97JUI0CubONSkXSKcebvWkkGmmQfz1994AkFYSZt64EQXjH/S";

        static void Main(string[] args)
        {
            PdfTextExample.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
