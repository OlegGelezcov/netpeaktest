using System;
using System.Linq;
using HtmlWpfParser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlWpfParser.Tests {
    [TestClass]
    public class HtmlParserTests {

        [TestMethod]
        public void Test_Valid_Html() {
            string htmlText = @"<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
     <title>MyTitle</title>
     <description>MyDescription</description>
 </head>
 <body>
     <h1>First header</h1>
        <a href=""http://google.com"">Google</a>    
        <a href=""http://apple.com"">Apple</a>
        <h1>Second header</h1>
        <img src=""test.jpg"" />
        <img src=""test2.jpg""/>
</body>
</html>";

            IHtmlParser parser = new HtmlParser();
            var result = parser.Parse(htmlText);
            Assert.AreEqual("MyTitle", result.Title);
            Assert.AreEqual("MyDescription", result.Description);
            Assert.AreEqual(2, result.Hrefs.Count());
            Assert.AreEqual(2, result.H1Headers.Count());
            Assert.AreEqual(2, result.Images.Count());
        }


    }
}
