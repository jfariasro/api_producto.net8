using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Services.Contracts
{
    public interface IMarcaService
    {
        Task<bool> Registrar(Marca model);

        Task<bool> Editar(Marca model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Marca>> Listar();

        Task<Marca> Buscar(int id);
    }
}
