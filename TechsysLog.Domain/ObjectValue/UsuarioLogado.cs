using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLog.Domain.ObjectValue
{
    public class UsuarioLogado
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nome { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Token { get; set; }
    }
}
