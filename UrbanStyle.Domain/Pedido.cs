using System;

namespace UrbanStyle.Domain;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public decimal Frete { get; set; }
    public decimal ValorTotal { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public StatusPagamento StatusPagamento { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public Cliente? Cliente { get; set; }
}
