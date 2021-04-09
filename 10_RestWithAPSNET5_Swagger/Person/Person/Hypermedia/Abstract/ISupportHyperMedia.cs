using System.Collections.Generic;

namespace Person.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> links { get; set; }
    }
}
