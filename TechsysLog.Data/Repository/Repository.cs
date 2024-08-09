using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Data.Interface;

namespace TechsysLog.Data.Repository
{
    public abstract class Repository<T> : IRepositorio<T> where T : class
    {
        protected Contexto Db;
        protected DbSet<T> Dbset;

        public Repository(Contexto contexto)
        {
            Db = contexto;
            Dbset = Db.Set<T>();
        }

        public virtual IEnumerable<T> ListAll()
        {
            return Dbset.ToList();
        }

        public T GetById(Guid id)
        {
            return Dbset.Find(id);
        }

        public T GetById(int id)
        {
            return Dbset.Find(id);
        }

        public T GetById(long id)
        {
            return Dbset.Find(id);
        }

        public int Save()
        {
            return Db.SaveChanges();
        }

        public T AddReturnEntity(T entidade)
        {
            Dbset.Add(entidade);
            Db.SaveChanges();
            return entidade;
        }

        public bool Add(T entidade)
        {
            Dbset.Add(entidade);
            return Save() > 0;
        }
        public bool AddRange(IEnumerable<T> obj)
        {
            Dbset.AddRange(obj);
            return Save() > 0;
        }

        public bool RemoveRange(IEnumerable<T> obj)
        {
            Dbset.RemoveRange(obj);
            return Save() > 0;
        }

        public bool Update(T entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            Dbset.Remove(Dbset.Find(id));
            return Save() > 0;
        }

        public bool Delete(Guid id)
        {
            Dbset.Remove(Dbset.Find(id));
            return Save() > 0;
        }

        public void Dispose()
        {
            Db.Dispose();
        }


    }
}