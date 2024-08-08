using Api.BLL.Services.Contracts;
using Api.Models;
using Api.PL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _service;

        public MarcaController(IMarcaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var responseApi = new ResponseAPI<List<MarcaDTO>>();

            try
            {
                var marcaSQL = await _service.Listar();

                List<MarcaDTO> lista = marcaSQL.Select(m => new MarcaDTO()
                {
                    Idmarca = m.Idmarca,
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
            var responseApi = new ResponseAPI<MarcaDTO>();

            try
            {
                var marca = await _service.Buscar(id);

                if (marca != null)
                {
                    var marcaDTO = new MarcaDTO
                    {
                        Idmarca = marca.Idmarca,
                        Nombre = marca.Nombre,
                        Descripcion = marca.Descripcion,
                    };

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = marcaDTO;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Marca No Encontrada";

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
        public async Task<IActionResult> Registrar([FromBody] MarcaDTO marcaDTO)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                Marca marca = new Marca()
                {
                    Nombre = marcaDTO.Nombre,
                    Descripcion = marcaDTO.Descripcion
                };

                var respuesta = await _service.Registrar(marca);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = marca.Idmarca;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Marca No Registrada";

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
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] MarcaDTO marcaDTO)
        {
            var responseApi = new ResponseAPI<int>();

            if (id != marcaDTO.Idmarca)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Error de coincidencia en los id";

                return BadRequest(responseApi);
            }

            try
            {
                Marca marca = new Marca()
                {
                    Idmarca = marcaDTO.Idmarca,
                    Nombre = marcaDTO.Nombre,
                    Descripcion = marcaDTO.Descripcion
                };
                var respuesta = await _service.Editar(marca, id);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = id;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Marca No Editada";

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
                    responseApi.Mensaje = "Marca No Eliminada";

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
