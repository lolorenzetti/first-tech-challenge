﻿using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Controllers.Pedido;
using TechChallenge.Application.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoController _controller;

        public PedidoController(IPedidoController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Criar novo pedido
        /// </summary>
        /// <remarks>
        /// Cria um novo pedido na base de dados. Exemplo:
        /// { "clienteId": null, "itens": [{ "id": 1, "quantidade": 1, "observacao": null }] }
        /// </remarks>
        /// <param name="criarPedidoDTO"></param>
        /// <returns>Retorna os dados do pedido</returns>
        /// <response code="201"></response>
        /// <response code="400">Erro de validação</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        public async Task<IActionResult> CriaPedido(CriarPedidoDTO criarPedidoDTO)
        {
            var id = await _controller.Criar(criarPedidoDTO);
            return Created("api/pedido", id);
        }

        /// <summary>
        /// Listar pedidos
        /// </summary>
        /// <remarks>
        /// Lista todos os pedidos cadastrados
        /// </remarks>
        /// <returns>Listagem dos pedidos</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        public async Task<IActionResult> ListaPedido()
        {
            var list = await _controller.ObterTodos();
            return Ok(list);
        }

        /// <summary>
        /// Faz o checkout do pedido
        /// </summary>
        /// <remarks>
        /// Faz o checkout do pedido, atualizando status para RECEBIDO
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Pedido</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro de validação</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [Route("{id}/checkout")]
        public async Task<IActionResult> CheckoutPedido([FromRoute] int id)
        {
            await _controller.RealizarChecktou(id);
            return Ok();
        }
    }
}
