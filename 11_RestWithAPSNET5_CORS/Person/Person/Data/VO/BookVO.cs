using Person.Hypermedia;
using Person.Hypermedia.Abstract;
using System.Collections.Generic;

namespace Person.Data.VO
{
    public class BookVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public System.DateTime LaunchDate { get; set; }
        public double Price { get; set; }
        public List<HyperMediaLink> links { get; set; } = new List<HyperMediaLink>();
    }
}
