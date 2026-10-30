using System;

namespace UrbanStyle.Domain;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Produto> Produtos { get; set; } = new List<Produto>();
}
