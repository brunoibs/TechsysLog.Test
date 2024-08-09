
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechsysLog.Domain.Entity
{
    public partial class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nome { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Senha { get; set; }
    }
}