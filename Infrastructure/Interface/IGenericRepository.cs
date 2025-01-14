﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T model);
        Task<T> GetById(int id);
        Task<T> Update(int id, T model);
        Task<bool> Delete(int id);
    }
}
