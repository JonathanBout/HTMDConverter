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
            string expectedHtml = 
@"This file should be valid HTML, after converting.
<blockquote>
This is a blockquote
</blockquote>
<em>Italic</em> <strong>bold</strong>
<ol>
<li>a</li>
<li>b</li>
</ol>
<ul>
<li>a</li>
<li>b</li>
</ul>";
            Assert.AreEqual(expectedHtml, HTMDConvert.MultiLineToHTML(htmd));
        }
    }

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            while(true)
            {
                Console.Write("Enter a line of HTMD: ");
                if (Console.ReadLine() is string htmd)
                {
                    Console.WriteLine(HTMDConvert.SingleLineToHTML(htmd));
                    Console.Title = "HTMD Converter" + (Debugger.IsAttached ? " in Debug mode": "");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }      
    }
}