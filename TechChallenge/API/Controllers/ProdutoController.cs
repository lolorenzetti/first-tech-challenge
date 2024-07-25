using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTO;
using TechChallenge.Application.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obter um produto
        /// </summary>
        /// <remarks>
        /// Obtém o produto do id informado
        /// </remarks>
        /// <param name="id">Id do produto a ser buscado</param>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou inexistente</response>
        /// <response code="500">Erro no servidor</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var result = await _service.ObterPorId(id);
            return Ok(result);
        }

        /// <summary>
        /// Obter todos os produtos de uma categoria
        /// </summary>
        /// <remarks>
        /// Categorias:  [0 "LANCHE", 1 "ACOMPANHAMENTO", 2 "BEBIDA", 3 "SOBREMESA"]
        /// </remarks>
        /// <param name="id">Categoria em formato int</param>
        /// <example>/api/produto/categoria/1</example>
        /// <returns>Todos os produtos da categoria informada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="500">Erro no servidor</response>
        [HttpGet]
        [Route("categoria/{id}")]
        public async Task<IActionResult> ObterPorCategoria([FromRoute] int id)
        {
            var result = await _service.ObterPorCategoria(id);
            return Ok(result);
        }

        /// <summary>
        /// Adicionar um produto
        /// </summary>
        /// <remarks>Adiciona um novo produto. Exemplo:
        ///   {
        ///     "nome": "X-Tudo",
        ///     "descricao": "Tudo o que tiver na cozinha",
        ///     "categoria": 0,
        ///     "preco": 27.50
        ///    }  
        /// </remarks>
        /// <param name="produtoDTO"></param>
        /// <response code="201">Cadastrado com sucesso</response>
        /// <response code="400">Erros de validação</response>
        /// <response code="500">Erro no servidor</response>
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CriarProdutoDTO produtoDTO)
        {
            var produto = await _service.Criar(produtoDTO);
            return Created($"api/produtos/{produto.Id}", produto.Id);
        }

        /// <summary>
        /// Deletar um produto 
        /// </summary>
        /// <remarks>Deleta o produto com o id informado na rota</remarks>
        /// <param name="id">id do produto a ser deletado</param>
        /// <response code="204">Sucesso</response>
        /// <response code="500">Erro no servidor</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            await _service.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Atualizar um produto
        /// </summary>
        /// <remarks>Atualiza um produto existente</remarks>
        /// <param name="editarProdutoDTO">dados do produto atualizado</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Erro de validação</response>
        /// <response code="500">Erro no servidor</response>
        [HttpPut]
        public async Task<IActionResult> Atualizar(EditarProdutoDTO editarProdutoDTO)
        {
            await _service.Editar(editarProdutoDTO);
            return NoContent();
        }
    }
}
