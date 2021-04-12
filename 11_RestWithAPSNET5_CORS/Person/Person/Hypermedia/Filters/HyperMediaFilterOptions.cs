using Person.Hypermedia.Abstract;
using System.Collections.Generic;

namespace Person.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseenricherList { get; set; } = new List<IResponseEnricher>();
    }
}
