using UrbanStyle.Application.DTOs.Produtos;
using UrbanStyle.Domain;

namespace UrbanStyle.Application.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(Produto produto)
    {
        return new ProdutoDto
            (produto.Id, produto.Nome,
            produto.Descricao, produto.Preco,
            produto.Categoria?.Nome ?? string.Empty);
      
    }

    public static Produto ToEntity(CriarProdutoDto dto)
    {
        return new Produto
        {
            
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            CategoriaId = dto.CategoriaId
        };
    }

    public static Produto ToEntity(AtualizarProdutoDto dto)
    {
        return new Produto
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            CategoriaId = dto.CategoriaId
        };
    }
}
