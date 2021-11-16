using DynamicPDF.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPdfCloudApiClientExamples
{
    class ImageInfoExampleTutorial
    {
        // simple example from Getting Started - image-info for 
        public static void ImageInfoExampleOne(String apiKey)
        {
            String key = apiKey;
            ImageResource imageResource = new ImageResource(@"c:/dynamicpdf/getting-started-examples/dynamicpdflogo.png");
            ImageInfo imageInfo = new ImageInfo(imageResource);
            imageInfo.ApiKey = key;
            ImageResponse response = imageInfo.Process();
            Console.WriteLine(PrettyPrintUtil.JsonPrettify(response.JsonContent));
        }

    }
}
