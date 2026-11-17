using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using UrbanStyle.Application.Interfaces;
using UrbanStyle.Domain;
using UrbanStyle.Infrastructure.Data;


namespace UrbanStyle.Infrastructure.Repositories;
//A classe ProdutoRepository  assina o contrato da interface IProdutoRepository
//Ou seja, ela promete implementar todos os 5 métodos do CRUD
public class ProdutoRepository : IProdutoRepository
{
    //O _context é a nossa 'ponte' com o banco de dados
    //Ele é readonly (somente leitura) porque só deve ser definido uma vez, 
    // no Construtor
    private readonly AppDbContext _context;

    //O construtor recebe o AppDbContext via Injeção de Dependência.
    //O ASP.NET Core se encarrega de criar e entrengar esse contexto para a gente.
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    // O método Listar vai buscar todos os produtos cadastrados no banco.
    // Como é uma operação de banco de dados, ele precisa ser assíncrono.
    // Busca todos os produtos cadastrados no banco de dados   
    public async Task<List<Produto>> Listar()
    {
        // Retornar a lista de produtos de forma assíncrona.
        return await _context.Produtos.ToListAsync();
    }

    //O metodo buscar procura o Produto atraves do Id, assim torna a busca mais pratica
    public async Task<Produto?> Buscar(int id)
    {

        return await _context.Produtos.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Produto> Criar(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    //Esse metodo é para atualizar o Produto, fazendo com que ele seja chamado e feito a atualização
    public async Task Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var produtoDelete =await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        if (produtoDelete == null)
            return;

        _context.Produtos.Remove(produtoDelete);
        await _context.SaveChangesAsync();
    }
}