using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Registrar(TEntityModel model);

        Task<bool> Editar(TEntityModel model, int id);

        Task<bool> Eliminar(int id);

        Task<IQueryable<TEntityModel>> Listar();

        Task<TEntityModel> Buscar(int id);
    }
}
