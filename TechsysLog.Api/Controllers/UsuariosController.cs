using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechsysLog.App.IServices;
using TechsysLog.Domain.Entity;
using TechsysLog.Domain.ObjectValue;
using TechsysLog.Infra;

namespace TechsysLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usu;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuariosService usu, IConfiguration configuration)
        {
            _usu = usu;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuario vazio ou nulo.");
            }
            usuario.Senha = Utils.Base64Criptografar(usuario.Senha);

            var result = await _usu.Insert(usuario);
            if(result.Valid)
                return Created("Register", usuario);
            else return BadRequest(result.Message);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuarios login)
        {
            login.Senha = Utils.Base64Criptografar(login.Senha);
            var result = _usu.ObterPorLogin(login).Result;
            if (login == null)
            {
                return Unauthorized();
            }
            if (!result.Valid)
                return BadRequest(result.Message);

            var user = result.Data as Usuarios;

            if (string.IsNullOrWhiteSpace(user.Senha))
                return BadRequest("Usuario Invalido.");

            var tokenString = GenerateJwtToken(user.Id.ToString(), user.Email);

            UsuarioLogado userLog = new UsuarioLogado();
            userLog.Email = user.Email;
            userLog.Nome    = user.Nome;
            userLog.Id = user.Id;
            userLog.Token = tokenString;
            return Ok(userLog);
        }

        private string GenerateJwtToken(string userId, string email)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKeyJson = jwtSettings["Secret"];
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKeyJson));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}