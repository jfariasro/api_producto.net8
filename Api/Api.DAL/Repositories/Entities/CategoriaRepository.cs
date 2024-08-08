using Api.DAL.Context;
using Api.DAL.Repositories.Contracts;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DAL.Repositories.Entities
{
    public class CategoriaRepository : IGenericRepository<Categoria>
    {
        private readonly DbproductoContext _context;

        public CategoriaRepository(DbproductoContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Buscar(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            return categoria!;
        }

        public async Task<bool> Editar(Categoria model, int id)
        {
            try
            {

                var categoria = await _context.Categorias.FindAsync(id);

                if (categoria == null)
                    return false;

                _context.Entry(categoria).CurrentValues.SetValues(model);

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
                var categoria = await _context.Categorias.FindAsync(id);

                if (categoria == null)
                    return false;

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IQueryable<Categoria>> Listar()
        {
            return _context.Categorias;
        }

        public async Task<bool> Registrar(Categoria model)
        {
            try
            {
                await _context.Categorias.AddAsync(model);
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
