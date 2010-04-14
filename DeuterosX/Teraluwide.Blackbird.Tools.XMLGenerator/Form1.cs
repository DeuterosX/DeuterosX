using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Teraluwide.Blackbird.Tools.XMLGenerator
{
    public partial class MainForm : Form
    {
        private XmlDocument myDom;
        private XmlAttribute myAtt;

        public MainForm()
        {
            InitializeComponent();
        }

        private void FolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                PathView.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, ResultView.Text);
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            myDom = new XmlDocument();
            XmlDeclaration myDec = myDom.CreateXmlDeclaration("1.0", "utf-8", null);
            myDom.AppendChild(myDec);

            // Generate the FDRFile node.
            XmlNode fdrNode = myDom.CreateElement("FDRFile");
            myAtt = myDom.CreateAttribute("version");
            myAtt.Value = "0.03";
            fdrNode.Attributes.Append(myAtt);
            myAtt = myDom.CreateAttribute("type");
            myAtt.Value = "textures";
            fdrNode.Attributes.Append(myAtt);

            XmlNode myRoot = myDom.CreateElement("TextureList");
            DirectoryInfo rootDir = new DirectoryInfo(PathView.Text);

            // Build the XML structure for every subdirectory of the chosen folder.
            myRoot = buildXMLTree(myRoot, rootDir);
            // Put the TextureList into the FDRFile node.
            fdrNode.AppendChild(myRoot);
            // Put the FDRFile node into the XML document.
            myDom.AppendChild(fdrNode);
            // Pretty print the final XML and copy it to the resultview.
            ResultView.Text = PrettyPrint(myDom.OuterXml);
        }

        private XmlNode buildXMLTree(XmlNode parent, DirectoryInfo myDir)
        {
            // This isn't very elegant, but it solved some problems I was having.
            XmlNode tmpNode = myDom.CreateElement("placeholder");

            // Traverse all subdirectories and gather the XML generated from them.
            foreach (DirectoryInfo tmpDir in myDir.GetDirectories())
            {
                // There is no reason to look in any of the SVN folders.
                if (tmpDir.Name != ".svn")
                {
                    XmlNode dirNode = myDom.CreateElement(tmpDir.Name.Replace(' ', '_'));
                    XmlNode validate = buildXMLTree(dirNode, tmpDir);
                    // If the subfolder did not (recursively) contain any PNG files, we don't add it.
                    if (validate.ChildNodes.Count > 0)
                    {
                        tmpNode.AppendChild(validate);
                    }
                }
            }

            // Generate the XML for the files in this folder.
            foreach (FileInfo tmpFile in myDir.GetFiles())
            {
                // PNG files only, please.
                if (tmpFile.Extension == ".png")
                {
                    XmlNode tmpNode2 = myDom.CreateElement("Texture");
                    myAtt = myDom.CreateAttribute("id");
                    // The ID is set to the file name without the extension.
                    myAtt.Value = tmpFile.Name.Substring(0, tmpFile.Name.Length - tmpFile.Extension.Length).Replace(' ', '_');
                    tmpNode2.Attributes.Append(myAtt);
                    myAtt = myDom.CreateAttribute("fileName");
                    DirectoryInfo startDir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                    myAtt.Value = startDir.Name + tmpFile.FullName.Substring(folderBrowserDialog1.SelectedPath.Length, tmpFile.FullName.Length - folderBrowserDialog1.SelectedPath.Length);
                    tmpNode2.Attributes.Append(myAtt);
                    tmpNode.AppendChild(tmpNode2);
                }
            }

            // Not too elegant either, but it was the only way I could get this bit to work.
            XmlNodeList myList = tmpNode.ChildNodes;

            // Add all the gathered nodes to the parent node before returning it.
            if (myList.Count != 0)
            {
                foreach (XmlNode branch in myList)
                {
                    parent.AppendChild(branch.Clone());
                }
            }
            return parent;
        }

        // This function is 100% stolen from http://www.personalmicrocosms.com/Pages/dotnettips.aspx?c=14&t=16
        public static String PrettyPrint(String XML)
        {
            String Result = "";

            MemoryStream MS = new MemoryStream();
            XmlTextWriter W = new XmlTextWriter(MS, Encoding.Unicode);
            XmlDocument D = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                D.LoadXml(XML);

                W.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                D.WriteContentTo(W);
                W.Flush();
                MS.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                MS.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader SR = new StreamReader(MS);

                // Extract the text from the StreamReader.
                String FormattedXML = SR.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            MS.Close();
            W.Close();

            return Result;
        }
    }
}
