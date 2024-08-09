
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
    /// Repositorio da entidade <Pedidos>.
    /// </summary>
    public class PedidosRepository : Repository<Pedidos>, IPedidosRepository
    {
        protected Contexto Db;
        protected DbSet<Pedidos> Dbset;

        public PedidosRepository(Contexto context) : base(context)
        {
            Db = context;
            Dbset = Db.Set<Pedidos>();
        }

        public IEnumerable<Pedidos> ListAllIdUser(int id, int? status)
        {
            var result = Dbset.Where(x => x.IdUserPedido == id);
            if (status.HasValue)
                result = result.Where(x => x.StatusPedido == status);
            var lista = result.ToList();

            if (lista == null) { return new List<Pedidos>(); }
            return lista;
        }
    }
}

