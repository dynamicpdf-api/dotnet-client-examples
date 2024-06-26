﻿using DynamicPDF.Api;
using System;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class ImageInfoExample
    {
        public static void Run(string apiKey, string basePath)
        {
            RunImageInfoOne(apiKey, basePath);
            RunImageInfoTwo(apiKey, basePath);
        }


        private static void RunImageInfoOne(String key, String basePath)
        {
            ImageResource imageResource = null;
            imageResource = new ImageResource(basePath + "getting-started.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

        private static void RunImageInfoTwo(String apiKey, String basePath)
        {
            ImageResource imageResource = new ImageResource(basePath + "multipage.tiff");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = apiKey;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(Utility.PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }
    }
}
