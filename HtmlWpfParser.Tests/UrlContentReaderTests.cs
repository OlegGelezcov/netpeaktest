using System;
using System.Net;
using HtmlWpfParser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlWpfParser.Tests {
    [TestClass]
    public class UrlContentReaderUrlContentReader {

        [TestMethod]
        public void Test_When_Valid_Url() {
            IUrlContentReader reader = new UrlContentReader();
            var result = reader.Read("http://google.com");
            Assert.AreEqual(200, result.ResponseCode);
            Assert.IsTrue(result.ResponseTime > 0.0);
            Assert.IsTrue(result.Html.Length > 0);          
        }


        [TestMethod]
        public void Test_When_Non_Existent_Url() {
            IUrlContentReader reader = new UrlContentReader();
            Assert.ThrowsException<WebException>(() => {
                var result = reader.Read("http://googlenotexists123.com");
            });
        }

        [TestMethod]
        public void Test_When_Invalid_Url() {
            IUrlContentReader reader = new UrlContentReader();
            Assert.ThrowsException<UriFormatException>(() => {
                var result = reader.Read("helloworld");
            });
        }
    }
}
