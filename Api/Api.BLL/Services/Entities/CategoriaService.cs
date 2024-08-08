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
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _repository;

        public CategoriaService(IGenericRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<Categoria> Buscar(int id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<bool> Editar(Categoria model, int id)
        {
            return await _repository.Editar(model, id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public Task<IQueryable<Categoria>> Listar()
        {
            return _repository.Listar();
        }

        public Task<bool> Registrar(Categoria model)
        {
            return _repository.Registrar(model);
        }

    }
}
