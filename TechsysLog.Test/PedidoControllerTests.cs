using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechsysLog.App.IServices;
using TechsysLog.Domain.Agregate;
using TechsysLog.Domain.Entity;
using TechsysLog.Api.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using TechsysLog.Domain.ObjectValue;

namespace TechsysLog.Test
{
    public class PedidoControllerTests
    {
        private readonly PedidoController _controller;
        private readonly Mock<IStatuspedidoService> _mockStatusService;
        private readonly Mock<IPedidosService> _mockPedidoService;
        private readonly Mock<IEntregaService> _mockEntregaService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;

        public PedidoControllerTests()
        {
            _mockStatusService = new Mock<IStatuspedidoService>();
            _mockPedidoService = new Mock<IPedidosService>();
            _mockEntregaService = new Mock<IEntregaService>();
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            _controller = new PedidoController(
                _mockStatusService.Object,
                _httpClient,
                _mockPedidoService.Object,
                _mockEntregaService.Object
            );
        }

        [Fact]
        public async Task RegistrarPedido_Retorna_Created_Quando_Valido()
        {
            // Arrange
            var horaTexto = DateTime.Now.ToString("HH:mm:sss");
            var pedido = new Pedidos { Descricao = $"Teste Pedido - {horaTexto}", IdUserPedido = 1 };
            var retorno = new ContractResult().Valido();
            retorno.Data = pedido;
            _mockPedidoService.Setup(s => s.Insert(It.IsAny<Pedidos>())).ReturnsAsync(retorno);

            // Act
            var result = await _controller.RegistrarPedido(pedido);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("Register", createdResult.Location);
            Assert.Equal(pedido, createdResult.Value);
        }

        [Fact]
        public async Task RegistrarPedido_Retorna_BadRequest_Quando_InValido()
        {
            // Arrange
            _controller.ModelState.AddModelError("Descricao", "Required");
            var pedido = new Pedidos();

            // Act
            var result = await _controller.RegistrarPedido(pedido);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Pedido vazio ou nulo.", badRequestResult.Value);
        }

        [Fact]
        public async Task RegistrarEngrega_Retorna_Created_Quando_Successo()
        {
            // Arrange
            var id = 1;
            var pedido = new Pedidos { Id = id, StatusPedido = 1 };
            var retorno = new ContractResult().Valido();
            retorno.Data = pedido;
            _mockPedidoService.Setup(s => s.MarcarEntregue(id)).ReturnsAsync(retorno);

            // Act
            var result = await _controller.RegistrarEngrega(id);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("Register", createdResult.Location);
            Assert.Equal(pedido, createdResult.Value);
        }

        [Fact]
        public async Task CancelarEntrega_Retorna_Created_Quando_Successo()
        {
            // Arrange
            var id = 2;
            var pedido = new Pedidos { Id = id, StatusPedido = 0 }; // Assume status 0 como "cancelado"
            var retorno = new ContractResult().Valido();
            retorno.Data = pedido;
            _mockPedidoService.Setup(s => s.CancelarPedido(id)).ReturnsAsync(retorno);

            // Act
            var result = await _controller.CancelarEntrega(id);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("Register", createdResult.Location);
            Assert.Equal(pedido, createdResult.Value);
        }

        [Fact]
        public async Task ListarPedidosPeloIdUser_Retorna_Ok_Lista()
        {
            // Arrange
            var idUser = 5;
            var pedidos = new List<Pedidos>();
            pedidos.Add(new Pedidos { Id = 1, Descricao = "Pedido 1" });
            pedidos.Add(new Pedidos { Id = 2, Descricao = "Pedido 2" });
            pedidos.Add(new Pedidos { Id = 3, Descricao = "Pedido 3" });
            var retorno = new ContractResult().Valido();
            retorno.Data = pedidos;
            _mockPedidoService.Setup(s => s.ListarPedidosPeloIdUser(idUser, null)).Returns(retorno);

            // Act
            var result = await _controller.ListarPedidosPeloIdUser(idUser, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(pedidos, okResult.Value);
        }
    }
}