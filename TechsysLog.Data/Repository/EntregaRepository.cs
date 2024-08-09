
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
    /// Repositorio da entidade <Entrega>.
    /// </summary>
    public class EntregaRepository : Repository<Entrega>, IEntregaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="<EntregaRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto</param>
        public EntregaRepository(Contexto context) : base(context)
        {
        }
    }
}