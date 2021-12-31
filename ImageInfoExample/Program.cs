using DynamicPDF.Api;
using System;

namespace ImageInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunOne("DP.TrJj2UBRFfrxiLYYD9xQryHXnFoSRKVPTBYH0LRpVWWnTZPOmgRO6yX6", "C:/temp/dynamicpdf-api-usersguide-examples/");
            RunTwo("DP.TrJj2UBRFfrxiLYYD9xQryHXnFoSRKVPTBYH0LRpVWWnTZPOmgRO6yX6", "C:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void RunOne(String key, String basePath)
        {
            ImageResource imageResource = null;
            imageResource = new ImageResource(basePath + "getting-started.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

        public static void RunTwo(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "multipage.tiff");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = apiKey;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

    }
}
