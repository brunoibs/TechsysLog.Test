using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Domain.Entity;

namespace TechsysLog.Data.Interface
{
    public interface IUsuariosRepository : IRepositorio<Usuarios>
    {
        Usuarios ObterPorLogin(Usuarios login);
    }
}

