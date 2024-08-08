using Api.BLL.Services.Contracts;
using Api.Models;
using Api.PL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var responseApi = new ResponseAPI<List<ProductoDTO>>();

            try
            {
                var productoSQL = await _service.Listar();

                List<ProductoDTO> lista = productoSQL.Select(p => new ProductoDTO()
                {
                    Idproducto = p.Idproducto,
                    Idmarca = p.Idmarca,
                    Marca = new MarcaDTO()
                    {
                        Idmarca = p.MarcaNavigation!.Idmarca,
                        Nombre = p.MarcaNavigation!.Nombre,
                        Descripcion = p.MarcaNavigation!.Descripcion
                    },
                    Idcategoria = p.Idcategoria,
                    Categoria = new CategoriaDTO()
                    {
                        Idcategoria = p.CategoriaNavigation!.Idcategoria,
                        Nombre = p.CategoriaNavigation!.Nombre,
                        Descripcion = p.CategoriaNavigation!.Descripcion
                    },
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio
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
            var responseApi = new ResponseAPI<ProductoDTO>();

            try
            {
                var producto = await _service.Buscar(id);

                if (producto != null)
                {
                    var productoDTO = new ProductoDTO
                    {
                        Idproducto = producto.Idproducto,
                        Idmarca = producto.Idmarca,
                        Marca = new MarcaDTO()
                        {
                            Idmarca = producto.MarcaNavigation!.Idmarca,
                            Nombre = producto.MarcaNavigation!.Nombre,
                            Descripcion = producto.MarcaNavigation!.Descripcion
                        },
                        Idcategoria = producto.Idcategoria,
                        Categoria = new CategoriaDTO()
                        {
                            Idcategoria = producto.CategoriaNavigation!.Idcategoria,
                            Nombre = producto.CategoriaNavigation!.Nombre,
                            Descripcion = producto.CategoriaNavigation!.Descripcion
                        },
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Cantidad = producto.Cantidad,
                        Precio = producto.Precio
                    };

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = productoDTO;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto No Encontrado";

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
        public async Task<IActionResult> Registrar([FromBody] ProductoDTO productoDTO)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var producto = new Producto()
                {
                    Nombre = productoDTO.Nombre,
                    Descripcion = productoDTO.Descripcion,
                    Cantidad= productoDTO.Cantidad,
                    Precio = productoDTO.Precio,
                    Idmarca = productoDTO.Idmarca,
                    Idcategoria = productoDTO.Idcategoria
                };

                var respuesta = await _service.Registrar(producto);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = producto.Idproducto;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto No Registrado";

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
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] ProductoDTO productoDTO)
        {
            var responseApi = new ResponseAPI<int>();

            if (id != productoDTO.Idproducto)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Error de coincidencia en los id";

                return BadRequest(responseApi);
            }

            try
            {
                var producto = new Producto()
                {
                    Idproducto = productoDTO.Idproducto,
                    Nombre = productoDTO.Nombre,
                    Descripcion = productoDTO.Descripcion,
                    Cantidad = productoDTO.Cantidad,
                    Precio = productoDTO.Precio,
                    Idmarca = productoDTO.Idmarca,
                    Idcategoria = productoDTO.Idcategoria
                };
                var respuesta = await _service.Editar(producto, id);

                if (respuesta)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = producto.Idproducto;

                    return Ok(responseApi);
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto No Editado";

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
                    responseApi.Mensaje = "Producto No Eliminado";

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
