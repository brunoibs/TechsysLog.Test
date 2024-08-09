using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Domain.Entity;

namespace TechsysLog.Data.Interface
{
    public interface IPedidosRepository : IRepositorio<Pedidos>
    {
        IEnumerable<Pedidos> ListAllIdUser(int id, int? status);
    }
}
