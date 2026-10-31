using UrbanStyle.Application.Interfaces;
using UrbanStyle.Domain;

namespace UrbanStyle.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Categoria>> Listar()
    {
        var lista = await _repository.Listar();
        return lista;
    }

    public async Task<Categoria?> Buscar(int id)
    {
        return await _repository.Buscar(id);
    }
    
    public async Task<Categoria> Criar(Categoria categoria)
    {
        return await _repository.Criar(categoria);
    }

    public async Task Atualizar(Categoria categoria)
    {
        await _repository.Atualizar(categoria);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}
