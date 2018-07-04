using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlWpfParser.Models {
    public class HtmlParser : IHtmlParser {

        public UrlResultData Parse(string htmlText) {

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlText);
            return new UrlResultData {
                Title = GetTitle(document),
                Description = GetDescription(document),
                H1Headers = GetH1Headers(document),
                Hrefs = GetHrefs(document),
                Images = GetImages(document)
            };
        }

        private string GetTitle(HtmlDocument document) {
            var titleNode = document.DocumentNode.SelectSingleNode("//head/title");
            return titleNode?.InnerText ?? "<NO TITLE>";
        }

        private string GetDescription(HtmlDocument document) {
            var descriptionNode = document.DocumentNode.SelectSingleNode("//head/description");
            return descriptionNode?.InnerText ?? "<NO DESCRIPTION>";
        }

        private IEnumerable<string> GetH1Headers(HtmlDocument document) {
            return document.DocumentNode.Descendants("h1")
                .Where(node => !string.IsNullOrEmpty(node.InnerText))
                .Select(node => node.InnerText)
                .ToList();
        }

        private IEnumerable<string> GetHrefs(HtmlDocument document ) {
            return document.DocumentNode.Descendants("a")
                .Where(node => !string.IsNullOrEmpty(node.GetAttributeValue("href", string.Empty)))
                .Select(node => node.GetAttributeValue("href", string.Empty))
                .ToList();
        }

        private IEnumerable<string> GetImages(HtmlDocument document) {
            return document.DocumentNode.Descendants("img")
                .Where(node => !string.IsNullOrEmpty(node.GetAttributeValue("src", string.Empty)))
                .Select(node => node.GetAttributeValue("src", string.Empty))
                .ToList();
        }
    }
}
