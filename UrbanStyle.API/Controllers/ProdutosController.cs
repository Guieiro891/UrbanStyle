using Microsoft.AspNetCore.Mvc;
using UrbanStyle.Application.Interfaces;
using UrbanStyle.Application.DTOs.Produtos;

namespace UrbanStyle.API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;
    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var produtos = await _service.Listar();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDto>> Buscar(int id)
    {
        var buscarProdutos = await _service.Buscar(id);
        if (buscarProdutos == null)
            return NotFound();
        return Ok(buscarProdutos);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> Criar([FromBody] CriarProdutoDto dto)
    {
        var produtoCriado = await _service.Criar(dto);
        return CreatedAtAction(nameof(Listar), new { id = produtoCriado.Id }, produtoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarProdutoDto dto)
    {
        var produtoAtualizar = await _service.Buscar(id);
        if (produtoAtualizar == null)
            return NotFound();
        

        await _service.Atualizar(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var produtoDeletar = await _service.Buscar(id);
        if (produtoDeletar == null)
            return NotFound();

        await _service.Deletar(id);
        return NoContent();
    }
}