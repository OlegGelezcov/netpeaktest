using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlWpfParser.Models {
    public class ResponseData {
        public int ResponseCode { get; set; }
        public double ResponseTime { get; set; }
        public string Html { get; set; }

        public override string ToString() {
            return $"Code => {ResponseCode}\nTime => {ResponseTime}\nHtml Length=> {Html.Length}";
        }
    }
}
