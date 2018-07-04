using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlWpfParser.Models {
    public interface IHtmlParser {
        UrlResultData Parse(string htmlText);
    }
}
