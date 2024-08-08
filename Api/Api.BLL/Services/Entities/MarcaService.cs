﻿using Api.BLL.Services.Contracts;
using Api.DAL.Repositories.Contracts;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Services.Entities
{
    public class MarcaService : IMarcaService
    {
        private readonly IGenericRepository<Marca> _repository;

        public MarcaService(IGenericRepository<Marca> repository)
        {
            _repository = repository;
        }

        public async Task<Marca> Buscar(int id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<bool> Editar(Marca model, int id)
        {
            return await _repository.Editar(model, id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public Task<IQueryable<Marca>> Listar()
        {
            return _repository.Listar();
        }

        public Task<bool> Registrar(Marca model)
        {
            return _repository.Registrar(model);
        }
    }
}
