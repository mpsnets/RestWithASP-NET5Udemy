using Person.Hypermedia;
using Person.Hypermedia.Abstract;
using System.Collections.Generic;

namespace Person.Data.VO
{
    public class PersonVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public List<HyperMediaLink> links { get; set; } = new List<HyperMediaLink>();
    }
}
