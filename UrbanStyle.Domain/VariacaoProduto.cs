using System;


namespace UrbanStyle.Domain;

public class VariacaoProduto
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string Cor { get; set; } = string.Empty;
    public string Tamanho { get; set; } = string.Empty;
    public int Estoque { get; set; }
    public Produto? Produto { get; set; }
}
