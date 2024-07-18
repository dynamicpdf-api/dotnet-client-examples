using DynamicPDF.Api;
using DynamicPdfClientLibraryExamples.Utility;
using System;
using System.IO;

namespace ImageConversionExample
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources";
        private const string outputPath = "Output";
        private const string apiKey = "DP.KEqlPCWJzlKsqsNlRzhxheXiB4Pm9n0859v9WgWaPSSOT7fYxzARCbtI";

        static void Main(string[] args)
        {
            FileUtility.CreatePath(outputPath);
            DynamicPdfClientLibraryExamples.Examples.ImageConversionExample.Run(apiKey, FileUtility.GetPath(basePath + "/image-conversion/"), FileUtility.GetPath(outputPath));
        }


    }
}
