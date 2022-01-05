using DynamicPDF.Api;
using System;

// resources available at cloud.dynamicpdf.com Get Image Information (image-info Endpoint) in the Resource Manager
// tutorial: https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/image-info/tutorial-image-info


namespace GetImageInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx--api-key--xxx", "c:/temp/dynamicpdf-api-samples/get-image-info/");
        }

        public static void Run(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "dynamicpdflogo.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();

            if(response.IsSuccessful)
            {
                Console.WriteLine(response.JsonContent);
            } else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }

    }
}
