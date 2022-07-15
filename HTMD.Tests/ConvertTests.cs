using DeltaDev.HTMD;
using System;
using System.Diagnostics;

namespace DeltaDev.HTMD.Tests
{
    [TestClass]
    public class SingleStatementTests
    {
        [TestMethod]
        public void BlockQuote()
        {
            string htmd = ">Hello, World!";
            string expectedHtml = "<blockquote>Hello, World!</blockquote>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd)); 
        }

        [TestMethod]
        public void Italic()
        {
            string htmd = "*Hello, World!*";
            string expectedHtml = "<i>Hello, World!</i>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }

        [TestMethod]
        public void Bold()
        {
            string htmd = "**Hello, World!**";
            string expectedHtml = "<b>Hello, World!</b>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }

        [TestMethod]
        public void BoldAndItalic()
        {
            string htmd = "***Hello, World!***";
            string expectedHtml = "<i><b>Hello, World!</b></i>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }

        [TestMethod]
        public void Headings()
        {
            string htmd = "# HEADING 1";
                                  
            string expectedHtml = @"<h1>HEADING 1</h1>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }

        [TestMethod]
        public void Code()
        {
            string htmd = "`a code block`";
            string expectedHtml = "<code>a code block</code>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }
    }

    [TestClass]
    public class SingleLineTests
    {
        [TestMethod]
        public void Full()
        {
            string htmd = ">**Hello, World!** unchanged text *hehe* more *unchanged text* and `some code`";
            string expectedHtml = "<blockquote><b>Hello, World!</b> unchanged text <i>hehe</i> more <i>unchanged text</i> and <code>some code</code></blockquote>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void BlockQuote()
        {
            string htmd = ">Hello, World!";
            string expectedHtml = "<blockquote>Hello, World!</blockquote>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void Italic()
        {
            string htmd = "*Hello, World!*";
            string expectedHtml = "<i>Hello, World!</i>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void Bold()
        {
            string htmd = "**Hello, World!**";
            string expectedHtml = "<b>Hello, World!</b>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void BoldAndItalic()
        {
            string htmd = "***Hello, World!***";
            string expectedHtml = "<i><b>Hello, World!</b></i>";

            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void Headings()
        {
            string htmd = "# HEADING 1";

            string expectedHtml = @"<h1>HEADING 1</h1>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [TestMethod]
        public void Code()
        {
            string htmd = "`a code block`";
            string expectedHtml = "<code>a code block</code>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }
    }

    [TestClass]
    public class MultiLineTests
    {
        [TestMethod]
        public void Full()
        {
            string htmd = File.ReadAllText(@"C:\Users\jonat\Downloads\helloworld.htmd");
            string expectedHtml = "<h1>Hello, World!</h1><br/><br/>This file should be valid HTML, after converting.<br/><blockquote>This is a blockquote</blockquote><br/><br/><i>Italic</i> <b>bold</b><br/><br/><ol><li>a</li><br/><li>b</li><br/></ol><br/><ul><li>a</li><br/><li>b</li><br/></ul>";
            Assert.AreEqual(expectedHtml, HTMDConvert.MultiLineToHTML(htmd));
        }
    }

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Console.Write("Do you want to convert a single line or a file? (l/f)");
            while(true)
            {
                Console.Title = "HTMD Converter" + (Debugger.IsAttached ? " in Debug mode" : "");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.L:
                        Console.WriteLine();
                        ConvertLine();
                        break;
                    case ConsoleKey.F:
                        Console.WriteLine();
                        ReadURL();
                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Invalid input. l or f expected.");
                        continue;
                }
                Console.Write("Do you want to convert another line or file (n or q to quit)? (l/f/n)");
            }
        }

        public static void ConvertLine()
        {
            Console.Write("Enter a line of HTMD: ");
            if (Console.ReadLine() is string htmd)
            {
                Console.WriteLine(HTMDConvert.SingleLineToHTML(htmd));
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        
        public static void ReadURL()
        {
            Console.Write("Enter the URL to a local file: ");
            if (Console.ReadLine() is string url)
            {
                try
                {
                    Console.WriteLine(HTMDConvert.MultiLineToHTML(File.ReadAllText(url)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{2}Error:     {0}{2}Help link: {1}", ex.Message, ex.HelpLink, Environment.NewLine);
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}