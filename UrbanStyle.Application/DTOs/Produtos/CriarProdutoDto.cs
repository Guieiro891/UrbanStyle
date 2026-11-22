
using System.ComponentModel.DataAnnotations;

namespace UrbanStyle.Application.DTOs.Produtos;

public class CriarProdutoDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O minimo de Caracteres é entre 2 e 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O minimo de Caracteres é entre 2 e 50 caracteres.")]
    public string Descricao { get; set; } = string.Empty;


    [Range(0.01, 99999.99, ErrorMessage = "O valor minimo é entre 0.1 à 99999.99.")]
    public decimal Preco { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "O ID da categoria deve ser maior que zero")]
    public int CategoriaId { get; set; }
}
