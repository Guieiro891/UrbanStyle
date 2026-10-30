using System;

namespace UrbanStyle.Domain;

public class ProdutoImagem
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string Url { get; set; } = string.Empty;
    public Produto? Produto { get; set; }
}
