using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http;
using System.Text.Json;
using TechsysLog.App.IServices;
using TechsysLog.Domain.Agregate;
using TechsysLog.Domain.Entity;
using TechsysLog.Domain.Enum;
using TechsysLog.Infra;

namespace TechsysLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IStatuspedidoService _status;
        private readonly IPedidosService _pedido;
        private readonly HttpClient _httpClient;
        private readonly IEntregaService _entrega;
        public PedidoController(IStatuspedidoService status, HttpClient httpClient, IPedidosService pedido, IEntregaService entrega)
        {
            _status = status;
            _httpClient = httpClient;
            _pedido = pedido;
            _entrega = entrega;
        }
        [Authorize]
        [HttpPost("GetAddressByCep")]
        public async Task<IActionResult> GetAddressByCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var viaCepResponse = JsonSerializer.Deserialize<ViaCepResponse>(responseBody);

                return Ok(viaCepResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPost("RegistrarPedido")]
        public async Task<IActionResult> RegistrarPedido(Pedidos model)
        {
            if (model == null)
            {
                return BadRequest("Pedido vazio ou nulo.");
            }
            model.StatusPedido = 1;
            model.DataHoraPedido = DateTime.Now;
            var result = await _pedido.Insert(model);
            if (result.Valid)
                return Created("Register", model);

            else return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost("RegistrarEngrega")]
        public async Task<IActionResult> RegistrarEngrega(int id)
        {
            if (id < 0)
            {
                return BadRequest("Pedido vazio ou nulo.");
            }
            var result = await _pedido.MarcarEntregue(id);
            var pedido = result.Data as Pedidos;

            if (result.Valid)
                return Created("Register", pedido);

            else return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost("CancelarEntrega")]
        public async Task<IActionResult> CancelarEntrega(int id)
        {
            if (id < 0)
            {
                return BadRequest("Pedido vazio ou nulo.");
            }
            var result = await _pedido.CancelarPedido(id);
            var pedido = result.Data as Pedidos;

            if (result.Valid)
                return Created("Register", pedido);

            else return BadRequest(result.Message);
        }

        [Authorize]
        [HttpGet("ListarPedidos")]
        public async Task<IActionResult> ListarPedidos(int status)
        {
            var lista = _pedido.ListAll();
            return Ok(lista);
        }

        [Authorize]
        [HttpGet("ListarPedidosPeloIdUser")]
        public async Task<IActionResult> ListarPedidosPeloIdUser(int id, int? status)
        {
            var result = _pedido.ListarPedidosPeloIdUser(id, status);
            if (result.Valid)
            {
                var lista = result.Data as List<Pedidos>;
                return Ok(lista);
            }
            else
            {
                return BadRequest($"Erro ao listar pedidos, Detalhe: {result.Message}");
            }
              
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            var lista = _status.ListAll();
            return Ok(lista);
        }
    }
}
