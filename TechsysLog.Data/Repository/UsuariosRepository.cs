namespace TechsysLog.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TechsysLog.Data.Interface;
    using TechsysLog.Domain.Entity;

    /// <summary>
    /// Repositorio da entidade <Usuarios>.
    /// </summary>
    public class UsuariosRepository : Repository<Usuarios>, IUsuariosRepository
    {
        protected Contexto Db;
        protected DbSet<Usuarios> Dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="<UsuariosRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto</param>
        public UsuariosRepository(Contexto context) : base(context)
        {
            Db = context;
            Dbset = Db.Set<Usuarios>();
        }

        public Usuarios ObterPorLogin(Usuarios login)
        {
            var result = Dbset.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            if (result == null) { return new Usuarios(); }
            return result;
        }
    }
}
