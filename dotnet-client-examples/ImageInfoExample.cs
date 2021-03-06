using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class ImageInfoExample
    {
        // simple example from Getting Started - image-info for 
        public static void ImageInfoExampleOne(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "/getting-started.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

        // simple multi-page tiff example from Users Guide - image-info
        public static void ImageInfoExampleTwo(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "/multipage.tiff");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

    }
}
