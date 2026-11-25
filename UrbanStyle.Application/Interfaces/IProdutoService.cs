
using UrbanStyle.Application.DTOs.Produtos;


namespace UrbanStyle.Application.Interfaces;

public interface IProdutoService
{
    Task<List<ProdutoDto>> Listar();
    Task<ProdutoDto?> Buscar(int id);
    Task<ProdutoDto> Criar(CriarProdutoDto dto);
    Task Atualizar(int id, AtualizarProdutoDto dto);
    Task Deletar(int id);
}
