﻿using Person.Model.Base;
using System.Collections.Generic;

namespace Person.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        List<T> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
