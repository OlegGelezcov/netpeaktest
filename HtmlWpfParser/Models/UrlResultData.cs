using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlWpfParser.Models {
    public class UrlResultData {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ResponseData ResponseData { get; set; }
        public IEnumerable<string> H1Headers { get; set; }
        public IEnumerable<string> Hrefs { get; set; }
        public IEnumerable<string> Images { get; set; }

        public UrlResultData() {
            Title = string.Empty;
            Description = string.Empty;
            H1Headers = new List<string>();
            Hrefs = new List<string>();
            Images = new List<string>();
        }

        public override string ToString() {
            return $"Title => {Title}\nDescription => {Description}\nResponse => {ResponseData.ToString()}\nH1 count => {H1Headers.Count()}\nHREFS count => {Hrefs.Count()}\nImage count => {Images.Count()}";
        }
    }
}
