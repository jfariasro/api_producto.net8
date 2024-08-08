using Api.BLL.Services.Contracts;
using Api.Models;
using Api.PL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var responseApi = new ResponseAPI<List<CategoriaDTO>>();

            try
            {
                var categoriaSQL = await _service.Listar();

                List<CategoriaDTO> lista = categoriaSQL.Select(m => new CategoriaDTO()
                {
                    Idcategoria = m.Idcategoria,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion
                }).ToList();

                responseApi.EsCorrecto = true;
                responseApi.Valor = lista;

                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

                return BadRequest(responseApi);
            }

        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<CategoriaDTO>();

            try
            {
                Categoria categoria = await _service.Buscar(id);

                if (categoria != null)
                {
                    var categoriaDTO = new CategoriaDTO
                    {
                        Idcategoria = categoria.Idcategoria,
                        Nombre = categoria.Nombre,
                        Descripcion = categoria.Descripcion,
                    };

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = categoriaDTO;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Categoria No Encontrada";

                    return NotFound(responseApi);
                }

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

                return BadRequest(responseApi);
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CategoriaDTO categoriaDTO)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var categoria = new Categoria()
                {
                    Nombre = categoriaDTO.Nombre,
                    Descripcion = categoriaDTO.Descripcion
                };

                var respuesta = await _service.Registrar(categoria);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = categoria.Idcategoria;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Categoria No Registrada";

                    return BadRequest(responseApi);
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

                return BadRequest(responseApi);
            }
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            var responseApi = new ResponseAPI<int>();

            if (id != categoriaDTO.Idcategoria)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Error de coincidencia en los id";

                return BadRequest(responseApi);
            }

            try
            {
                var categoria = new Categoria()
                {
                    Idcategoria = categoriaDTO.Idcategoria,
                    Nombre = categoriaDTO.Nombre,
                    Descripcion = categoriaDTO.Descripcion
                };
                var respuesta = await _service.Editar(categoria, id);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = id;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Categoria No Editada";

                    return BadRequest(responseApi);
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

                return BadRequest(responseApi);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var respuesta = await _service.Eliminar(id);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = id;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Categoria No Eliminada";

                    return BadRequest(responseApi);

                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

                return BadRequest(responseApi);
            }
        }

    }
}
