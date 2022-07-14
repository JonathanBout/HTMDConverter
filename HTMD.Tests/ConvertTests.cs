using DeltaDev.HTMD;
using System;

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
        public void OrderedList()
        {
            string htmd = "1. Item 1";
            string expectedHtml = "<li>Item 1</li>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleStatementToHTML(htmd));
        }

        [TestMethod]
        public void UnorderedList()
        {
            string htmd = "- Item 1";
            string expectedHtml = "<li>Item 1</li>";
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
            string htmd = ">**Hello, World!** unchanged text *hehe* more unchanged text `some code`";
            string expectedHtml = "<blockquote><b>Hello, World!</b> unchanged text <i>hehe</i> more unchanged text <code>some code</code></blockquote>";
            Assert.AreEqual(expectedHtml, HTMDConvert.SingleLineToHTML(htmd));
        }

        [STAThread]
        public static void Main()
        {
            while(true)
            {
                Console.WriteLine("Enter a line of HTMD:");
                if (Console.ReadLine() is string htmd)
                {
                    Console.WriteLine(HTMDConvert.SingleLineToHTML(htmd));        
                }else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}