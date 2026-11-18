using Microsoft.AspNetCore.Mvc;
using UrbanStyle.Application.Interfaces;
using UrbanStyle.Domain;


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
    public async Task<ActionResult<Produto>> Buscar(int id)
    {
        var buscarProdutos = await _service.Buscar(id);
        if (buscarProdutos == null)
            return NotFound();
        return Ok(buscarProdutos);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Criar([FromBody] Produto produto)
    {
        var produtoCriado = await _service.Criar(produto);
        return CreatedAtAction(nameof(Listar), new { id = produtoCriado.Id }, produtoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
    {
        var produtoAtualizar = await _service.Buscar(id);
        if (produtoAtualizar == null)
            return NotFound();
        
        produtoAtualizar.Nome = produto.Nome;
        produtoAtualizar.Descricao = produto.Descricao;
        produtoAtualizar.Preco = produto.Preco;
        produtoAtualizar.CategoriaId = produto.CategoriaId;

        await _service.Atualizar(produtoAtualizar);
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