using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using System.IO;
namespace WordPractic
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь до файла:");
            string path = Console.ReadLine();
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
                            Console.WriteLine("Введите фамилию для замены:");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите имя для замены:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите отчество для замены:");
                            string patronymic = Console.ReadLine();
                            Myinformation Myinformation = new Myinformation(name,surname,patronymic);
                            if (newText.Text.Contains("Name"))
                            {
                                newText.Text = newText.Text.Replace("Name", Myinformation.Name);
                            }
                            else if (newText.Text.Contains("Surname"))
                            {
                                newText.Text = newText.Text.Replace("Surname", Myinformation.SurName);
                            }
                            else if ( newText.Text.Contains("Patronymic")) 
                            {
                                newText.Text = newText.Text.Replace("Patronymic", Myinformation.Patronymic);
                            }
                            body.AppendChild(newthing);
                        }
                    }
                    NewDoc.Save();
                    Console.WriteLine("Успешно!");
                }
            }
            Console.ReadLine();
        }
    }
}