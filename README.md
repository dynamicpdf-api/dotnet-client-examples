# dotnet-client-examples

The project contains numerous Visual Studio C# Console App (.NET Core) command-line project. Each example is its own project in the `dotnet-client-examples` solution.

## Resources

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

| Tutorial Title                                      | Project/File/Class      | Tutorial Location                                            |
| --------------------------------------------------- | ----------------------- | ------------------------------------------------------------ |
| Getting Started in 5 Minutes                        | `GettingStartedInFive`  | https://cloud.dynamicpdf.com/docs/tutorials/getting-started/getting-started-5-min |
| Completing a Form using the `pdf` Endpoint          | `CompletingAcroForm`    | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-form-completion |
| Creating a PDF Using a DLEX and the `pdf` Endpoint  | `CreatingPdfDlex`       | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-dlex-merge |
| Adding Bookmarks to a PDF                           | `AddBookmarks`          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-outlines |
| Creating a PDF Using the `dlex-layout` Endpoint     | `CreatingPdfDlexLayout` | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-layout/tutorial-dlex-layout |
| Extracting Metadata Using the `image-info` Endpoint | `GetImageInfo`          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/image-info/tutorial-image-info |
| Extract PDF Metadata Using the `pdf-info` Endpoint  | `GetPdfInfo`            | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-info/tutorial-pdf-info |
| Extracting Text Using the `pdf-text` Endpoint       | `ExtractingText`        | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-text/tutorial-pdf-text |
| Extract XMP Metadata Using the `pdf-xmp` Endpoint   | `GetXmpMetaData`        | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-xmp/tutorial-pdf-xmp |

