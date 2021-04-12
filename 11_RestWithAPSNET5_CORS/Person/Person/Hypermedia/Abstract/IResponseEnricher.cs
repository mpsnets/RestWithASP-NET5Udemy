using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Person.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool canEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
