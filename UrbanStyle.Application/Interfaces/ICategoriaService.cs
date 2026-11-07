using UrbanStyle.Application.DTOs.Categorias;

namespace UrbanStyle.Application.Interfaces;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> Listar();
    Task<CategoriaDto?> Buscar(int id);
    Task<CategoriaDto> Criar(CriarCategoriaDto dto);
    Task Atualizar(int id,  AtualizarCategoriaDto dto);
    Task Deletar(int id);
}