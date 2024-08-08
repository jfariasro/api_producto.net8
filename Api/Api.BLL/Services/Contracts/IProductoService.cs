using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Services.Contracts
{
    public interface IProductoService
    {
        Task<bool> Registrar(Producto model);

        Task<bool> Editar(Producto model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Producto>> Listar();

        Task<Producto> Buscar(int id);
    }
}
