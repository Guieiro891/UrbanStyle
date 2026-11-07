using System.ComponentModel.DataAnnotations;

namespace UrbanStyle.Application.DTOs.Categorias;

public class AtualizarCategoriaDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 50 caracteres")]
    public string Nome { get; set; } = string.Empty;
}