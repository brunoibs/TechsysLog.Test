using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLog.Domain.Enum
{
    internal class Enumeradores
    {
    }

    public enum PedidoStatus
    {
        Cancelado = 0,
        Recebido = 1,
        EmPreparacao = 2,
        SaiuParaEntrega = 3,
        Entregue = 4
    }

}
