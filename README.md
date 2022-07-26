# dotnet-client-examples

The C# .NET Client Examples project uses the DynamicPDF Cloud API C# client library to create, merge, split, form fill, stamp, obtain metadata, convert, and secure/encrypt PDF documents. This project contains numerous sample projects for the tutorials and examples on [cloud.dynamicpdf.com](https://github.com/dynamicpdf-api/java-client-examples/blob/main/cloud.dynamicpdf.com).

The DynamicPDF Cloud API consists of the following endpoints.

- `dlex-layout`
- `image-info`
- `pdf`
- `pdf-info`
- `pdf-text`
- `pdf-xmp`

The C# client project is available on Github ([java-client](https://github.com/dynamicpdf-api/-client)). For more information, please visit [DynamicPDF Cloud API](https://cloud.dynamicpdf.com/). Support for other languages/platforms (PHP, C#, Node.js) is available on GitHub ([DynamicPDF Cloud API at GitHub](https://github.com/dynamicpdf-api)).Resources

The DynamicPDF.API library is available on NuGet.

```bash
Install-Package DynamicPDF.API
```

To obtain the resources for the project, login to cloud.dynamicpdf.com (assuming you have an account), and go to the **Resource Manager**. You use the `samples` folder to add the resources for the tutorials and examples from this project.

- [Resource Manager Samples](https://cloud.dynamicpdf.com/docs/usersguide/environment-manager/environment-manager-sample-resources)  

For more information on the tutorials and example code, refer to:

- https://cloud.dynamicpdf.com/docs/tutorials/tutorials-overview
- https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-overview

## **Tutorials**

The following table lists the tutorial project or file name.  In Visual Studio each tutorial is it's own project. In the remaining client libraries each tutorial is its own individual class.

The following table lists the tutorial project or file name.  In Visual Studio each tutorial is it's own project. In the remaining client libraries each tutorial is its own individual class.

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

