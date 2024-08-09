
namespace TechsysLog.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TechsysLog.Data.Interface;
    using TechsysLog.Domain.Entity;

    /// <summary>
    /// Repositorio da entidade <Statuspedido>.
    /// </summary>
    public class StatuspedidoRepository : Repository<StatusPedido>, IStatuspedidoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="<StatuspedidoRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto</param>
        public StatuspedidoRepository(Contexto context) : base(context)
        {
        }
    }
}

