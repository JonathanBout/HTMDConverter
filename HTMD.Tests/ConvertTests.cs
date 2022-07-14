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
}