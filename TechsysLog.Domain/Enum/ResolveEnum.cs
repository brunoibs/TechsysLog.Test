using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Infra;

namespace TechsysLog.Domain.Enum
{
    public static class ResolveEnum
    {
        public static string ObterNomeStatus(int status)
        {
            try
            {
                return ((PedidoStatus)status).ToString().Replace("EmPreparacao", "Em Preparação")
                                                       .Replace("SaiuParaEntrega", "Saiu para Entrega");
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return "Status desconhecido";
            }
        }
    }

}
