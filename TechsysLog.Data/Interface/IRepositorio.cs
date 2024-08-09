﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLog.Data.Interface
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ListAll();
        T GetById(Guid id);
        T GetById(int id);
        T GetById(long id);
        int Save();
        bool Add(T entidade);
        T AddReturnEntity(T entidade);
        bool AddRange(IEnumerable<T> obj);
        bool RemoveRange(IEnumerable<T> obj);
        bool Update(T entidade);
        bool Delete(int id);
        bool Delete(Guid id);
    }
}