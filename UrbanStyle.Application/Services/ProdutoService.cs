using UrbanStyle.Application.Interfaces;
using UrbanStyle.Domain;

namespace UrbanStyle.Application.Services;

public  class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Produto>> Listar()
    {
        return await _repository.Listar();
    }

    public async Task<Produto> Buscar(int id)
    {
        return await _repository.Buscar(id);
    }

    public async Task<Produto> Criar(Produto produto)
    {
        return await _repository.Criar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        await _repository.Atualizar(produto);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}