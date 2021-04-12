using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Hypermedia
{
    public class HyperMediaLink
    {
        private string href;
        public string Rel { get; set; }
        public string Href {
            get {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
