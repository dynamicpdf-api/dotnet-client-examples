# dotnet-client-examples

The project contains a Visual Studio C# Console App (.NET Core) command-line project. The main class, `Program`, contains examples illustrating using the `pdf-info`, `image-info`, `pdf-text`, `pdf-xmp`, `dlex-layout`, and `pdf` endpoints.  Each endpoint example is in its own respective class. There are also examples illustrating using the instructions schema to create several PDFs using the `pdf`endpoint. These examples are in the `InstructionsExample` class.

### Building

After opening the application in Visual Studio, add following runtime parameters. Also, when creating the path to the resources, be certain to create a sub-folder named `output`.

```c#
args[0] := <api-key> args[1] := <base-path-endpoints> args[2] := <base-path-instructions>
```

### Resources

Add the needed resources from the DynamicPDF Cloud API **Resource Manager**. 



| Tutorial Title                                    | Class                         | Tutorial Location                                            |
| ------------------------------------------------- | ----------------------------- | ------------------------------------------------------------ |
| Getting Started in 5 Minutes                      | `GettingStartedFive.cs`       | https://cloud.dynamicpdf.com/docs/tutorials/getting-started/getting-started-5-min |
| Completing a Form using the pdf Endpoint          | `FormFillExample.cs`          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-form-completion |
| Creating a PDF Using a DLEX and the pdf Endpoint  | `SimpleDlexMergeExample.cs`   | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-dlex-merge |
| Adding an Outline to a PDF                        | `OutlineTutorialExample.cs`   | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-tutorial-outlines |
| Creating a PDF Using the dlex-layout Endpoint     | `DlexLayoutTutorial.cs`       | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-layout/tutorial-dlex-layout |
| Extracting Metadata Using the image-info Endpoint | `ImageInfoExampleTutorial.cs` | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/image-info/tutorial-image-info |
| Extract PDF Metadata Using the pdf-info Endpoint  | `PdfInfoExample.cs`           | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-info/tutorial-pdf-info |
| Extracting Text Using the pdf-text Endpoint       | `PdfTextExample.cs`           | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-text/tutorial-pdf-text |
| Extract XMP Metadata Using the pdf-xmp Endpoint   | `PdfXmlExample.cs`            | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-xmp/tutorial-pdf-xmp |

