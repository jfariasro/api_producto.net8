using Api.BLL.Services.Contracts;
using Api.DAL.Repositories.Contracts;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Services.Entities
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _repository;

        public ProductoService(IGenericRepository<Producto> repository)
        {
            _repository = repository;
        }

        public async Task<Producto> Buscar(int id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<bool> Editar(Producto model, int id)
        {
            return await _repository.Editar(model, id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<IQueryable<Producto>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<bool> Registrar(Producto model)
        {
            return await _repository.Registrar(model);
        }
    }
}
