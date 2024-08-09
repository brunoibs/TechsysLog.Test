using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Domain.Entity;

namespace TechsysLog.Test
{
    public class PedidosTests
    {
        [Fact]
        public void Pedido_Deve_Conter_Valores_Iniciais_Padrao()
        {
            // Arrange & Act
            var pedido = new Pedidos();

            // Assert
            Assert.Equal(0, pedido.Id);
            Assert.Null(pedido.Descricao);
            Assert.Null(pedido.Valor);
            Assert.Null(pedido.Cep);
            Assert.Null(pedido.Rua);
            Assert.Null(pedido.Numero);
            Assert.Null(pedido.Bairro);
            Assert.Null(pedido.Cidade);
            Assert.Null(pedido.Estado);
            Assert.Equal(0, pedido.StatusPedido);
            Assert.Equal(default(DateTime), pedido.DataHoraPedido);
            Assert.Equal(0, pedido.IdUserPedido);
            Assert.Null(pedido.StatusPedidoTexto);
        }

        [Fact]
        public void Pedido_Deve_Permitir_Definir_Valores()
        {
            // Arrange
            var pedido = new Pedidos
            {
                Id = 1,
                Descricao = "Pedido de teste Notebook",
                Valor = 3100.50m,
                Cep = "31130-070",
                Rua = "Rua Iça",
                Numero = "123",
                Bairro = "Bairro Renascença",
                Cidade = "Belo Horizonte",
                Estado = "MG",
                StatusPedido = 2,
                DataHoraPedido = DateTime.Now,
                IdUserPedido = 5,
                StatusPedidoTexto = ""
            };

            // Assert
            Assert.Equal(1, pedido.Id);
            Assert.Equal("Pedido de teste Notebook", pedido.Descricao);
            Assert.Equal(3100.50m, pedido.Valor);
            Assert.Equal("31130-070", pedido.Cep);
            Assert.Equal("Rua Iça", pedido.Rua);
            Assert.Equal("123", pedido.Numero);
            Assert.Equal("Bairro Renascença", pedido.Bairro);
            Assert.Equal("Belo Horizonte", pedido.Cidade);
            Assert.Equal("MG", pedido.Estado);
            Assert.Equal(2, pedido.StatusPedido);
            Assert.Equal(5, pedido.IdUserPedido);
            Assert.Equal("", pedido.StatusPedidoTexto);
        }

        [Fact]
        public void Pedido_Nao_Deve_Aceitar_Descricao_Excedendo_Limite()
        {
            // Arrange
            var pedido = new Pedidos();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                pedido.Descricao = new string('A', 101);
            });

            Assert.Contains("maximum length", exception.Message);
        }

        [Fact]
        public void Pedido_Valor_Deve_Ser_Nulo_Ou_Positivo()
        {
            // Arrange
            var pedido = new Pedidos();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                pedido.Valor = -10.00m;
            });

            Assert.Contains("cannot be negative", exception.Message);
        }
    }
}