using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.App.IServices;
using TechsysLog.Data.Interface;
using TechsysLog.Domain.Entity;
using TechsysLog.Domain.Enum;
using TechsysLog.Domain.ObjectValue;
using TechsysLog.Infra;

namespace TechsysLog.App.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _repo;
        private readonly IEntregaRepository _repoEntrega;
        public PedidosService(IPedidosRepository repo, IEntregaRepository repoEntrega)
        {
            _repo = repo;
            _repoEntrega = repoEntrega;
        }


        #region Dispose
        private bool disposedValue = false; // Para detectar chamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: descartar estado gerenciado (objetos gerenciados).
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }


        #endregion
        public async Task<IContractResult> Delete(int id)
        {
            var result = new ContractResult();
            try
            {
                var model = _repo.GetById(id);
                result.Valid = _repo.Delete(id);
                result.Message = "Excluido com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> Delete(Guid id)
        {
            var result = new ContractResult();
            try
            {
                var model = _repo.GetById(id);
                result.Valid = _repo.Delete(id);
                result.Message = "Excluido com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> GetById(int id)
        {
            var result = new ContractResult();
            try
            {
                var obj = _repo.GetById(id);
                result.Valid = true;
                result.Message = "Sucesso.";
                result.Data = obj;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> GetById(Guid id)
        {
            var result = new ContractResult();
            try
            {
                var obj = _repo.GetById(id);
                result.Valid = true;
                result.Message = "Sucesso.";
                result.Data = obj;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }


        public async Task<IContractResult> Insert(Pedidos model)
        {
            var result = new ContractResult();
            try
            {
                result.Valid = _repo.Add(model);
                result.Message = "Salvo com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }


        public IContractResult ListAll()
        {
            var result = new ContractResult();
            try
            {
                var list = _repo.ListAll();
                foreach (var item in list)
                    item.StatusPedidoTexto = ResolveEnum.ObterNomeStatus(item.StatusPedido);
                result.Valid = true;
                result.Message = "Sucesso.";
                result.Data = list;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> Update(Pedidos model)
        {
            var result = new ContractResult();
            try
            {
                result.Valid = _repo.Update(model);
                result.Message = "Atualizado com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }


        public IContractResult ListarPedidosPeloIdUser(int id, int? status)
        {
            var result = new ContractResult();
            try
            {
                var list = _repo.ListAllIdUser(id, status);
                foreach (var item in list)
                    item.StatusPedidoTexto = ResolveEnum.ObterNomeStatus(item.StatusPedido);
                result.Valid = true;
                result.Message = "Sucesso.";
                result.Data = list;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }
            return result;
        }

        public async Task<IContractResult> CancelarPedido(int id)
        {
            var result = new ContractResult();
            try
            {
                var pedido = _repo.GetById(id);
                pedido.StatusPedido = (int)PedidoStatus.Cancelado;

                result.Valid = _repo.Update(pedido);
                result.Message = "Atualizado com Sucesso.";
                result.Data = pedido;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> MarcarEntregue(int id)
        {
            var result = new ContractResult();
            try
            {
                var pedido = _repo.GetById(id);
                pedido.StatusPedido = (int)PedidoStatus.Entregue;

                result.Valid = _repo.Update(pedido);
                result.Message = "Atualizado com Sucesso.";
                result.Data = pedido;

                if (result.Valid)
                {
                    var entrega = new Entrega();
                    entrega.DataHora = DateTime.Now;
                    entrega.IdPedido = id;
                    result.Valid = _repoEntrega.Add(entrega);
                }
                else
                {
                    result.Valid = false;
                    result.Message = "Erro ao Registrar Entrega";
                }
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;

        }
    }
}



