
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechsysLog.Domain.Entity
{
    public partial class Pedidos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Valor { get; set; }
        [StringLength(10)]
        public string Cep { get; set; }
        [StringLength(30)]
        public string Rua { get; set; }
        [StringLength(10)]
        public string Numero { get; set; }
        [StringLength(30)]
        public string Bairro { get; set; }
        [StringLength(30)]
        public string Cidade { get; set; }
        [StringLength(30)]
        public string Estado { get; set; }
        public int StatusPedido { get; set; }
        public DateTime DataHoraPedido { get; set; }
        public int IdUserPedido { get; set; }

        [NotMapped] public string StatusPedidoTexto { get; set; }

    }
}