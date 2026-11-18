
using UrbanStyle.Domain;

namespace UrbanStyle.Application.Interfaces;

public interface IProdutoService
{
    Task<List<Produto>> Listar();
    Task<Produto?> Buscar(int id);
    Task<Produto> Criar(Produto produto);
    Task Atualizar(Produto produto);
    Task Deletar(int id);
}
