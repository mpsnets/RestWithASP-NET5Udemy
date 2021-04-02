using Person.Model;
using Person.Model.Context;
using Person.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }
        public List<Model.Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Model.Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Model.Person Create(Model.Person person)
        {
            return _repository.Create(person);
        }

        public Model.Person Update(Model.Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
