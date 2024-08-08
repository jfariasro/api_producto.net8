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
    public class MarcaRepository : IGenericRepository<Marca>
    {
        private readonly DbproductoContext _context;

        public MarcaRepository(DbproductoContext context)
        {
            _context = context;
        }

        public async Task<bool> Editar(Marca model, int id)
        {
            try
            {

                var marca = await _context.Marcas.FindAsync(id);

                if (marca == null)
                    return false;

                _context.Entry(marca).CurrentValues.SetValues(model);

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
                var marca = await _context.Marcas.FindAsync(id);

                if (marca == null)
                    return false;

                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IQueryable<Marca>> Listar()
        {
            return _context.Marcas;
        }

        public async Task<Marca> Buscar(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<bool> Registrar(Marca model)
        {
            try
            {
                await _context.Marcas.AddAsync(model);
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
