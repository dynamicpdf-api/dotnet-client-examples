using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;


namespace CompletingAnAcroform
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources";

        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {            
            FillAcroForm.Run(apiKey, FileUtility.GetPath(basePath + "/fill-acro-form-pdf-endpoint/"), FileUtility.GetPath(basePath + "/fill-acro-form-pdf-endpoint/"));
        }
    }
}
