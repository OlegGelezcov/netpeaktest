using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlWpfParser.Models {
    public class UrlContentReader : IUrlContentReader {


        public ResponseData Read(string url) {
            DateTime beforeTime = DateTime.UtcNow;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            int statusCode = (int)response.StatusCode;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();

            DateTime afterTime = DateTime.UtcNow;
            

            return new ResponseData {
                Html = result,
                ResponseCode = statusCode,
                ResponseTime = (afterTime - beforeTime).TotalSeconds
            };
        }
    }
}
