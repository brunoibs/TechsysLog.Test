
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechsysLog.Domain.Entity
{
    public partial class StatusPedido
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Descricao { get; set; }
    }
}