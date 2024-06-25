using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;
using System;

namespace AddBookmarksTutorial
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/add-bookmarks/";
        private const string outputPath = "Output";
        private const string apiKey = "DP--api-key--";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            AddBookmarks.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
        }
    }
}
