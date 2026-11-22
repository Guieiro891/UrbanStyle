using System.ComponentModel.DataAnnotations;

namespace UrbanStyle.Application.DTOs.Produtos;

public class AtualizarProdutoDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 e 50 Caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 e 50 Caracteres")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, 99999.99, ErrorMessage = "O Preço não pode ser menor que 0.01 e maior que 99999.99")]
    public decimal Preco { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser maior que zero")]
    public int CategoriaId { get; set; }
}
