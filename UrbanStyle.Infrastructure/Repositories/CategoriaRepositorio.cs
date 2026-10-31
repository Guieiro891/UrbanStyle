using Microsoft.EntityFrameworkCore;
using UrbanStyle.Application.Interfaces;
using UrbanStyle.Domain;
using UrbanStyle.Infrastructure.Data;

namespace UrbanStyle.Infrastructure.Repositories;

public class CategoriaRepositorio : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> Listar()
    {
        var lista = await _context.Categorias.ToListAsync();
        return lista;
    }

    public async Task<Categoria?> Buscar(int id)
    {
        var busca = await _context.Categorias.FirstOrDefaultAsync(busca => busca.Id == id);
            return busca;

    }

    public async Task<Categoria> Criar(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task Atualizar (Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
        
    }

    public async Task Deletar(int id)
    {
        var buscaDeletar =await _context.Categorias.FirstOrDefaultAsync(busca => busca.Id == id);
        if (buscaDeletar == null)
        {
            return;
        }
        _context.Categorias.Remove(buscaDeletar);
        await _context.SaveChangesAsync();
    }
}