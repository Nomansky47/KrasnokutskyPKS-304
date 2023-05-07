using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using System.IO;
namespace WordMoment
{
    internal class Program
    {
        static void Main()
        {
            string path = "C:\\Users\\NikitaPortable\\Desktop\\help.docx";
            using (WordprocessingDocument Doc = WordprocessingDocument.Open(path, true))
            {
                IEnumerable<Paragraph> needthings = Doc.MainDocumentPart.Document.Body.Descendants<Paragraph>();
                using (WordprocessingDocument NewDoc = WordprocessingDocument.Create(Path.Combine(Path.GetDirectoryName(path), "newfile.docx"), WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = NewDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    foreach (var thing in needthings)
                    {
                        Paragraph newthing = new Paragraph();
                        newthing.ParagraphId = thing.ParagraphId;
                        newthing.InnerXml = thing.InnerXml;
                        newthing.RemoveAllChildren<Text>();
                        Text newText = newthing.Descendants<Text>().FirstOrDefault();
                        if (newText != null)
                        {
                            string Name = "Name";
                            string ID="ID";
                            string Class = "Class";
                            Console.WriteLine(newText.Text);
                            if (newText.Text.Contains(Name))
                            {
                                Console.WriteLine("Здесь имя");
                                newText.Text = newText.Text.Replace(Name, Myinformation.Name);
                            }
                            else if (newText.Text.Contains(ID))
                            {
                               Console.WriteLine("Здесь ID");
                                newText.Text = newText.Text.Replace(ID, Myinformation.ID);
                            }
                            else if ( newText.Text.Contains(Class)) 
                            {
                                 Console.WriteLine("Здесь возраст");
                                newText.Text = newText.Text.Replace(Class, Myinformation.Class);
                            }
                            body.AppendChild(newthing);
                        }
                    }
                    NewDoc.Save();
                }
            }
            Console.ReadLine();
        }
    }
}