using Api.DAL.Context;
using Api.DAL.Repositories.Contracts;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DAL.Repositories.Entities
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly DbproductoContext _context;

        public ProductoRepository(DbproductoContext context)
        {
            _context = context;
        }

        public async Task<Producto> Buscar(int id)
        {
            var producto = await _context.Productos.Include(m => m.MarcaNavigation).Include(c => c.CategoriaNavigation).FirstOrDefaultAsync(p => p.Idproducto == id);
            return producto!;
        }

        public async Task<bool> Editar(Producto model, int id)
        {
            try
            {

                var producto = await _context.Productos.FindAsync(id);

                if (producto == null)
                    return false;

                _context.Entry(producto).CurrentValues.SetValues(model);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);

                if (producto == null)
                    return false;

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IQueryable<Producto>> Listar()
        {
            return _context.Productos.Include(m => m.MarcaNavigation).Include(c => c.CategoriaNavigation);
        }

        public async Task<bool> Registrar(Producto model)
        {
            try
            {
                await _context.Productos.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
