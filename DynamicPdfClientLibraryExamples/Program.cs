using System;

namespace DynamicPdfClientLibraryExamples
{
    class Program
    {
        private const string basePath = "c:/temp/dynamicpdf-api-samples/";
        private const string usersGuideResourcePath = "c:/temp/dynamicpdf-api-samples/users-guide-resources/";
        private const string outputPath = "c:/temp/dynamicpdf-api-samples/";

        private const string apiKey = "DP.Tai26vtanTPXDVJz6Y1u0wOYAP6Mv3U/yOUU4wg1+2DtTJuCnCXz7NB1";

        static void Main(string[] args)
        {
            Console.WriteLine("ALL RESOURCES NEEDED LOCALLY MUST BE DOWNLOADED FROM SAMPLE PROJECT IN RESOURCE MANAGER.");

            Examples.DynamicColumnsOne.Run(apiKey, basePath + "columns/", outputPath + "columns/");
            Examples.DynamicColumnsTwo.Run(apiKey, basePath + "columns-two/", outputPath + "columns-two/");
  
            Examples.InstructionsExample.DemoInstructions(apiKey, usersGuideResourcePath, outputPath);
        }

    }
}
