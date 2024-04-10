using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;


namespace CompletingAnAcroform
{
    class Program
    {
        private const string outputPath = "../DynamicPdfClientLibraryExamples/Output/fill-acro-form-pdf-endpoint/";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            FillAcroForm.Run(apiKey, FileUtility.GetPath(outputPath));
        }
    }
}
