using DynamicPDF.Api;
using System;


namespace DynamicPdfClientLibraryExamples.Examples
{
    class GetImageInfo
    {
        public static void Run(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "dynamicpdflogo.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.JsonContent);
            }
            else
            {
                Console.WriteLine(response.ErrorJson);
            }
        }
    }
}
