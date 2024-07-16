![](./logo-banner2.png)

# dotnet-client-examples

The C# .NET Client Examples project uses the DynamicPDF API C# client library (`dotnet-client`) to create, merge, split, form fill, stamp, obtain metadata, convert, and secure/encrypt PDF documents. This project contains numerous sample projects for the tutorials and examples on [cloud.dynamicpdf.com](https://cloud.dynamicpdf.com/).

The DynamicPDF API consists of the following endpoints.

- `dlex-layout`
- `image-info`
- `pdf`
- `pdf-info`
- `pdf-text`
- `pdf-xmp`

The C# client library (`dotnet-client`) is available on Github ([dotnet-client](https://github.com/dynamicpdf-api/dotnet-client)). For more information, please visit [DynamicPDF API](https://cloud.dynamicpdf.com/). Support for other languages/platforms (PHP, C#, Node.js) is available on GitHub ([DynamicPDF API at GitHub](https://github.com/dynamicpdf-api)).

## NuGet

* The DynamicPDF.API library is available on NuGet.

```bash
Install-Package DynamicPDF.API
```

## Resources

To obtain the resources for the project, login to [cloud.dynamicpdf.com](https://cloud.dynamicpdf.com/) (assuming you have an account), and go to the **File Manager**. You use the `samples` folder to add the resources for some of the examples from this project. Local resources are in the Resources folder in the DynamicPdfClientLibraryExamples project.

For more information on the tutorials and example code, refer to:

https://dpdf.io/docs/

## Run All At Once

To run all examples at once, go to the DynamicPdfClientLibraryExamples project, and run this project.

To run all the examples at once you must change the flag `runAll` to `true`, otherwise manually run the example you wish to run.

You need the following samples folder in your Cloud Storage space to run all the examples.

* samples/creating-a-page-template-designer/
* samples/report-with-cover-page/
* samples/creating-a-report-template-designer
* samples/creating-a-page-template-designer
* samples/creating-pdf-pdf-endpoint/
* samples/creating-pdf-dlex-layout-endpoint/
* samples/fill-acro-form-pdf-endpoint/
* samples/getting-started/
* samples/merge-pdfs-pdf-endpoint/

The resources folder contains all the local resources and saves all results to DynamicPdfClientLibraryExamples/Output which is created when run.

## **Tutorials**

The following table lists the available tutorials.

| Tutorial Title                                     | Project/File/Class      | Tutorial Location                                            |
| -------------------------------------------------- | ----------------------- | ------------------------------------------------------------ |
| Merging PDFs                                       | MergePdfs               | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/merging-pdfs |
| Completing an AcroForm                             | `CompletingAcroForm`    | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/form-completion |
| Creating a PDF Using a DLEX and the `pdf` Endpoint | `CreatingPdfDlex`       | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-pdf-endpoint |
| Adding Bookmarks to a PDF                          | `AddBookmarks`          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/bookmarks |
| Creating a PDF Using the `dlex-layout` Endpoint    | `CreatingPdfDlexLayout` | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-layout |
| Extracting Image Metadata                          | `GetImageInfo`          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/image-info |
| Extract PDF Metadata                               | `GetPdfInfo`            | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-info |
| Extracting PDF's Text                              | `ExtractingText`        | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-text |
| Extract XMP Metadata                               | `GetXmpMetaData`        | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-xmp |

# Support

The primary source for the DynamicPDF API support is through [Stack Overflow](https://stackoverflow.com/questions/tagged/dynamicpdf-api). Please use the "[dynamicpdf-api](https://stackoverflow.com/questions/tagged/dynamicpdf-api)" tag to ask questions. Our support team actively monitors the tag and responds promptly to any questions.  Also, let us know you asked the question by following up with an email to [support@dynamicpdf.com](mailto:support@dynamicpdf.com). 

## Pro Plan Subscribers[#](https://cloud.dynamicpdf.com/support#pro-plan-subscribers)

Ticket support is available to Pro Plan subscribers. But we still encourage you to help the community by posting on Stack Overflow when possible. You can also email [support@dynamicpdf.com](mailto:support@dynamicpdf.com) if you need to ask something specific to your use case that may not help the DynamicPDF API community.

# License

The `dotnet-client-examples` library is licensed under the [MIT License](./LICENSE).
