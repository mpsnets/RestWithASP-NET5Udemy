using Person.Model;
using System.Collections.Generic;

namespace Person.Business
{
    public interface IPersonBusiness
    {
        Model.Person Create(Model.Person person);
        Model.Person FindById(long id);
        Model.Person Update(Model.Person person);
        List<Model.Person> FindAll();
        void Delete(long id);
    }
}
