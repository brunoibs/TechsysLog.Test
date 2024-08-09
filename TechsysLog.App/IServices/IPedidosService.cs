using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Domain.Entity;
using TechsysLog.Domain.ObjectValue;

namespace TechsysLog.App.IServices
{
    public interface IPedidosService : IDisposable
    {
        Task<IContractResult> Delete(int id);
        Task<IContractResult> Delete(Guid id);
        Task<IContractResult> Insert(Pedidos model);
        Task<IContractResult> Update(Pedidos model);
        IContractResult ListAll();
        IContractResult ListarPedidosPeloIdUser(int id, int? status);
        Task<IContractResult> GetById(int id);
        Task<IContractResult> GetById(Guid id);
        Task<IContractResult> CancelarPedido(int id);
        Task<IContractResult> MarcarEntregue(int id);
    }
}