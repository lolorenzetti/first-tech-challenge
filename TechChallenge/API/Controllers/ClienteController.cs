using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Controllers.Cliente;
using TechChallenge.Application.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteController _controller;

        public ClienteController(IClienteController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Buscar cliente por CPF
        /// </summary>
        /// <remarks>
        /// Busca um cliente na base de dados a partir do CPF informado.
        /// Exemplo: 12345678910
        /// </remarks>
        /// <param name="cpf"></param>
        /// <returns>Dados do cliente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("{cpf}")]
        public async Task<IActionResult> BuscarPorCpf([FromRoute] string cpf)
        {
            var result = await _controller.ObterPorCPF(cpf);
            return Ok(result);
        }

        /// <summary>
        /// Cadastrar novo cliente
        /// </summary>
        /// <remarks>
        /// Cadastra um novo cliente. Exemplo:
        /// { "nome": "João Ferreira da Silva", "email": "joao.silva@provedor.com", "cpf": "12345678910" }
        /// </remarks>
        /// <param name="criarClienteDTO"></param>
        /// <returns>Retorna os dados do cliente cadastrado</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Erros de validação</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(CriarClienteDTO criarClienteDTO)
        {
            var result = await _controller.Criar(criarClienteDTO);
            if (result is null)
                return NotFound();
            return Created("/clientes", result);
        }
    }
}
