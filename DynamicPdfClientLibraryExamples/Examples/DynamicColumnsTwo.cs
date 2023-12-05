using System;
using System.Xml;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class DynamicColumnsTwo
    {
        private const string nameSpace = "https://www.dynamicpdf.com";

        // content width is document width 612 - left and right margin

        private const int contentWidth = 512;

        // add some padding between columns

        private const int padding = 5;

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            XmlDocument doc = ModifyDlexDocument(basePath + "report-with-cover-page.dlex");

            Console.WriteLine(Utility.PrettyPrintUtil.PrintXML(doc));
            
            DynamicColumnsOne.RunDlex(apiKey, basePath, basePath + "report-with-cover-page.json", doc, outputPath + "report-with-cover-page-second-output.pdf");
        }

        private static XmlDocument ModifyDlexDocument(string dlexFile)
        {

            // create document and add namespace

            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("dpdf", nameSpace);

            // load original dlex file into document

            doc.Load(dlexFile);

            // Add column elements then elements in the details

            CreateColumnLabels(doc, nsmgr, 0, 100);
            CreateDetails(doc, nsmgr, 0, 100);

            return doc;
        }

        private static void CreateColumnLabels(XmlDocument doc, XmlNamespaceManager nsmgr, int x, int width)
        {

            string[] columnLabelNames = { "productnamelabel", "qtyperunitlabel", "unitpricelabel", "discontinuedlabel", "line1" };
            string[] columnLabelTexts = { "Product Name", "Qty Per Unit", "Unit Price", "Discontinued" };

            // get the header node to append the labels and line

            string xpathExpression = xpathExpression = "//dpdf:header";
            XmlNode headerNode = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);

            // loop through names and add the label id and name

            for (int i = 0; i < 5; i++)
            {
                XmlElement labelElement = null;

                // first 3 labels are productnamelabel, qtyperunitlabel, unitpricelabel, and dicontinuedlabel
                // the else condition is the line1 

                if (i < 4)
                {
                    labelElement = CreateLabel(doc, columnLabelTexts[i], width);

                    if (i < 3)
                    {
                        if (i < 2)
                        {
                            labelElement.SetAttribute("align", "left");
                        }
                        else
                        {
                            labelElement.SetAttribute("align", "right");
                        }

                        labelElement.SetAttribute("x", x.ToString());
                        x += (width + padding);
                    }
                    else
                    {
                        labelElement.SetAttribute("x", (contentWidth - width).ToString());
                        labelElement.SetAttribute("align", "center");
                    }
                }
                else
                {
                    // create a line under the labels

                    labelElement = CreateLine(doc, labelElement);

                }

                // all elements have an id property

                labelElement.SetAttribute("id", columnLabelNames[i]);

                // append the element as a child of header

                headerNode.AppendChild(labelElement);
            }

        }

        private static XmlElement CreateLabel(XmlDocument doc, string labelText, int width)
        {
            XmlElement labelElement = doc.CreateElement("label", nameSpace);
            labelElement.SetAttribute("text", labelText);
            labelElement.SetAttribute("font", "TimesBold");
            labelElement.SetAttribute("fontSize", "11");
            labelElement.SetAttribute("underline", "false");
            labelElement.SetAttribute("height", "14");
            labelElement.SetAttribute("width", width.ToString());
            labelElement.SetAttribute("y", "1");
            return labelElement;
        }

        private static XmlElement CreateLine(XmlDocument doc, XmlElement lineElement)
        {
            lineElement = doc.CreateElement("line", nameSpace);
            lineElement.SetAttribute("x1", "0");
            lineElement.SetAttribute("y1", "15");
            lineElement.SetAttribute("x2", "512");
            lineElement.SetAttribute("y2", "15");
            return lineElement;
        }


        private static void CreateDetails(XmlDocument doc, XmlNamespaceManager nsmgr, int x, int width)
        {
            string[] columnDetaillNames = { "productnamebox", "qtyperunitbox", "unitpricebox", "discontinuedsymbol" };
            string[] columnDetailFieldNames = { "ProductName", "QuantityPerUnit", "UnitPrice", "Discontinued" };

            // get the detail node to append elements

            string xpathExpression = "//dpdf:detail";
            XmlNode detailNode = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);

            // create the rectangle to add every other row color

            XmlElement fieldElement = CreateRectangle(doc, x);
            detailNode.AppendChild(fieldElement);

            // loop through columnDetailFieldNames

            for (int i = 0; i < 4; i++)
            {

                // if productnamebox, qtyperunitbox, unitpricebox otherwise discontinuedsymbol

                if (i < 3)
                {

                    // create new element

                    fieldElement = CreateRecordBox(doc, columnDetailFieldNames[i], x);

                    // if productnamebox or qtyperunitbox otherwise its the unitpricebox

                    if (i < 2)
                    {
                        fieldElement.SetAttribute("align", "left");
                        fieldElement.SetAttribute("expandable", "true");

                    }
                    else
                    {
                        fieldElement.SetAttribute("align", "right");
                        fieldElement.SetAttribute("expandable", "false");
                        fieldElement.SetAttribute("dataFormat", "$0.00##");
                    }

                    // move x by width and padding

                    x += (width + padding);
                }
                else
                {
                    // discontinuedsymbol is a symbol not a recordbox so create a symbol node

                    fieldElement = CreateSymbol(doc, x, width);
                }

                // all elements have an id, height, width and y

                ModifyFieldElement(fieldElement, width, columnDetailFieldNames[i]);

                //append the created node to the detail node

                detailNode.AppendChild(fieldElement);

            }

        }

        private static void ModifyFieldElement(XmlElement fieldElement, int width, string id)
        {
            fieldElement.SetAttribute("id", id);
            fieldElement.SetAttribute("height", "14");
            fieldElement.SetAttribute("width", width.ToString());
            fieldElement.SetAttribute("y", "1");
        }

        private static XmlElement CreateSymbol(XmlDocument doc, int x, int width)
        {
            XmlElement fieldElement = doc.CreateElement("symbol", nameSpace);
            fieldElement.SetAttribute("x", (contentWidth - width).ToString());
            fieldElement.SetAttribute("visibilityCondition", "EQ(Discontinued,1)");
            return fieldElement;
        }

        private static XmlElement CreateRecordBox(XmlDocument doc, string dataName, int x)
        {
            XmlElement fieldElement = doc.CreateElement("recordBox", nameSpace);
            fieldElement.SetAttribute("font", "TimesBold");
            fieldElement.SetAttribute("fontSize", "11");
            fieldElement.SetAttribute("underline", "false");
            fieldElement.SetAttribute("x", x.ToString());
            fieldElement.SetAttribute("autoLeading", "true");
            fieldElement.SetAttribute("splittable", "false");
            fieldElement.SetAttribute("dataName", dataName);
            return fieldElement;
        }


        private static XmlElement CreateRectangle(XmlDocument doc, int x)
        {
            XmlElement fieldElement = doc.CreateElement("rectangle", nameSpace);
            fieldElement.SetAttribute("id", "rectangle1");
            fieldElement.SetAttribute("x", x.ToString());
            fieldElement.SetAttribute("y", "1");
            fieldElement.SetAttribute("width", contentWidth.ToString());
            fieldElement.SetAttribute("height", "15");
            fieldElement.SetAttribute("borderColor", "lightBlue");
            fieldElement.SetAttribute("fillColor", "lightBlue");
            fieldElement.SetAttribute("showAlternateRow", "even");

            return fieldElement;
        }



    }
}
