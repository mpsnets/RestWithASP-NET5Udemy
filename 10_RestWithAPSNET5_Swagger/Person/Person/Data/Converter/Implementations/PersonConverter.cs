using Person.Data.Converter.Contract;
using Person.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Model.Person>, IParser<Model.Person, PersonVO>
    {
        public Model.Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Model.Person 
            { 
                Id = origin.Id,
                FirstName = origin.FirstName,
                LasttName = origin.LasttName,
                Address = origin.Address,
                Gender=origin.Gender,
            };
        }

        public PersonVO Parse(Model.Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LasttName = origin.LasttName,
                Address = origin.Address,
                Gender = origin.Gender,
            };
        }

        public List<Model.Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(p => Parse(p)).ToList();
        }
        public List<PersonVO> Parse(List<Model.Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(p => Parse(p)).ToList();
        }
    }
}
