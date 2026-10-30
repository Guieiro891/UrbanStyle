using System;

namespace UrbanStyle.Domain;

public class ItemPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int VariacaoProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoPago { get; set; }
    public Pedido? Pedido { get; set; }
    public VariacaoProduto? VariacaoProduto { get; set; }
}
