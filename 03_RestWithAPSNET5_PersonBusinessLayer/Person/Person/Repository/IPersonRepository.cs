using Person.Model;
using System.Collections.Generic;

namespace Person.Repository
{
    public interface IPersonRepository
    {
        Model.Person Create(Model.Person person);
        Model.Person FindById(long id);
        Model.Person Update(Model.Person person);
        List<Model.Person> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
