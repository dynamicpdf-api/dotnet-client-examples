using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class ShippingAndReceivingDashboardExample
    {

        public static void ExampleOne(String apiKey, String basePath)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(basePath + "/getting-started.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

        public static void ExampleTwo(String apiKey, String basePath)
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
