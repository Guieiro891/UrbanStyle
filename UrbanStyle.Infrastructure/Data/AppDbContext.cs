using Microsoft.EntityFrameworkCore;
using UrbanStyle.Domain;
namespace UrbanStyle.Infrastructure.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<VariacaoProduto> VariacoesProdutos { get; set; }
    public DbSet<ProdutoImagem> ProdutosImagens { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItemPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurando a precisão dos campos de dinheiro
        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Frete)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Pedido>()
            .Property(p => p.ValorTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ItemPedido>()
            .Property(i => i.PrecoPago)
            .HasPrecision(18, 2);
    }
} 
