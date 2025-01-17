﻿using LojaApi.Models;
using LojaApi.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly CarrinhoRepository _carrinhoRepository;

        public CarrinhoController(CarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }



        [HttpDelete("remover")]
        public async Task<IActionResult> RemoverProdutoCarrinho(int usuarioId, int produtoId)
        {
            await _carrinhoRepository.RemoverProdutoCarrinhoDB(usuarioId, produtoId);

            return Ok(new { mensagem = "Produto removido do carrinho!" });
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarProdutoCarrinho(int usuarioId, int produtoId, int quantidade)
        {
            await _carrinhoRepository.AdicionarCarrinho(usuarioId, produtoId, quantidade);

            return Ok(new { mensagem = "Produto adicionado ao carrinho!" });
        }


        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarCarrinho(int usuarioId)
        {
            var itens = await _carrinhoRepository.ConsultarCarrinhoDB(usuarioId);

            var valorTotal = await _carrinhoRepository.CalcularValorTotalCarrinho(usuarioId);

            return Ok(new { itens, valorTotal });
        }



    }
}
