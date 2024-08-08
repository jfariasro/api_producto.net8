using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Services.Contracts
{
    public interface ICategoriaService
    {
        Task<bool> Registrar(Categoria model);

        Task<bool> Editar(Categoria model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Categoria>> Listar();

        Task<Categoria> Buscar(int id);
    }
}
