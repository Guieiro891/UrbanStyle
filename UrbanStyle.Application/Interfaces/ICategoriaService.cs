using UrbanStyle.Domain;

namespace UrbanStyle.Application.Interfaces;

public interface ICategoriaService
{
    Task<List<Categoria>> Listar();
    Task<Categoria?> Buscar(int id);
    Task<Categoria> Criar(Categoria categoria);
    Task Atualizar(Categoria categoria);
    Task Deletar(int id);
}