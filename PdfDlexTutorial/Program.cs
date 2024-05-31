using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace PdfDlexTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "DP.dASL7G5Gz8VJgEwjUly9+ooHTbSSO7pOhGrt36dHXllYQK4E1wURRI+x";
            string basePath = "../DynamicPdfClientLibraryExamples/Resources/creating-pdf-pdf-endpoint/";
            string outputPath = "Output";

            FileUtility.CreatePath(outputPath);
            PdfDlexExample.RunLocal(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));

            PdfDlexExample.RunRemote(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));

        }
    }
}
