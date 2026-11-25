using UrbanStyle.Application.DTOs.Produtos;
using UrbanStyle.Application.Mappers;
using UrbanStyle.Application.Interfaces;

namespace UrbanStyle.Application.Services;

public  class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProdutoDto>> Listar()
    {
        var produtos = await _repository.Listar();
        return produtos.Select(p => ProdutoMapper.ToDto(p)).ToList();
    }

    public async Task<ProdutoDto?> Buscar(int id)
    {
        var produto = await _repository.Buscar(id);
        return produto == null ? null: ProdutoMapper.ToDto(produto);
    }

    public async Task<ProdutoDto> Criar(CriarProdutoDto dto)
    {
        var produto = ProdutoMapper.ToEntity(dto);
        var produtoCriado = await _repository.Criar(produto);
        return ProdutoMapper.ToDto(produtoCriado);
    }

    public async Task Atualizar(int id, AtualizarProdutoDto dto)
    {
        var produto = await _repository.Buscar(id);
        if (produto == null)
            return;
        produto.Nome = dto.Nome;
        produto.Descricao = dto.Descricao;
        produto.Preco = dto.Preco;
        produto.CategoriaId = dto.CategoriaId;

        await _repository.Atualizar(produto);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}