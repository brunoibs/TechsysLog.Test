
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechsysLog.Domain.Entity
{
    public partial class Entrega
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdPedido { get; set; }
    }
}