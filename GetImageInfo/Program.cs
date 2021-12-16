using DynamicPDF.Api;
using System;

namespace GetImageInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.NKSoPxiwOgZoypSVYaXyEARo2cO9Kk5BRgY2ZRC0jF/KQq4pDzhfK8yO", "c:/temp/dynamicpdf-api-samples/get-image-info/");
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
