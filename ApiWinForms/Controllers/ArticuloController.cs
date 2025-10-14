using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI;
using ApiWinForms.Areas.HelpPage;
using ApiWinForms.DTOs;
using ApiWinForms.Models;
using dominio;
using servicios;

namespace ApiWinForms.Controllers
{
    public class ArticuloController : ApiController
    {
        private gestionArticulos gestorArticulos;
        private gestionImagenes gestorImagenes;
        private gestionMarcas gestorMarcas;
        private gestionCategoria gestorCategorias;

        public ArticuloController()
        {
            gestorArticulos = new gestionArticulos();
            gestorImagenes = new gestionImagenes();
            gestorMarcas = new gestionMarcas();
            gestorCategorias = new gestionCategoria();
        }

        // GET: api/Articulo - Listar todos los artículos
        public IHttpActionResult Get()
        {
            try
            {
                var articulos = gestorArticulos.listar();
                var lista = new List<Articulo>();

                foreach (var art in articulos)
                {
                    // obtiene todas las imágenes del artículo
                    var imagenes = gestorImagenes.listarPorArticulo(art.idArticulo);

                    var articulo = new Articulo
                    {
                        Id = art.idArticulo,
                        Codigo = art.codigo,
                        Nombre = art.nombre,
                        Descripcion = art.descripcion,
                        Precio = art.precio,
                        IdMarca = art.marca.idMarca,
                        DescripcionMarca = art.marca.descripcion,
                        IdCategoria = art.categoria.idCategoria,
                        DescripcionCategoria = art.categoria.descripcion,
                        Imagenes = imagenes.Select(img => img.Url).ToList()
                    };
                    lista.Add(articulo);
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error: {ex.Message} - InnerException: {ex.InnerException?.Message}"));
            }
        }

        // POST: api/Articulo - Crear nuevo artículo
        public IHttpActionResult Post([FromBody] ArticuloDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos requeridos");

                // valida modelo DTO
                if (!ModelState.IsValid)
                {
                    var errores = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return BadRequest(string.Join(", ", errores));
                }

                // valida marca existe
                var marcas = gestorMarcas.listar();
                if (!marcas.Any(m => m.idMarca == dto.IdMarca))
                    return BadRequest("La marca no existe");

                // valida categoría existe
                var categorias = gestorCategorias.listar();
                if (!categorias.Any(c => c.idCategoria == dto.IdCategoria))
                    return BadRequest("La categoría no existe");

                // mapea DTO a modelo de dominio
                var articulo = new articulos
                {
                    codigo = dto.Codigo,
                    nombre = dto.Nombre,
                    descripcion = dto.Descripcion,
                    precio = dto.Precio,
                    marca = new marcas { idMarca = dto.IdMarca },
                    categoria = new categorias { idCategoria = dto.IdCategoria },
                    imagenUrl = dto.ImagenUrl
                };

                gestorArticulos.agregarArticulo(articulo);
                return Ok(new { mensaje = "Artículo creado exitosamente", codigo = dto.Codigo });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error: {ex.Message}"));
            }
        }
       
        public IHttpActionResult Put(int id, [FromBody] ArticuloDTO dto)
        {
            try
            {
                //validamos si el articulo recibido para modifcar no es null
                if (dto == null)
                    return BadRequest("se requieren datos para realizar una modificacion");
                //validamos el modelo de dto
                if (!ModelState.IsValid)
                {
                    var errores = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return BadRequest(string.Join(", ", errores));
                }

                //validamos que exista el articulo a modificar
                var gestorArticulos = new gestionArticulos();
                var articuloExistente = gestorArticulos.listar().FirstOrDefault(a => a.idArticulo == id);
                if (articuloExistente == null)
                {
                    return NotFound();
                }

                //validamos que la marca exista
                var gestorMarcas = new gestionMarcas();
                var marcas = gestorMarcas.listar();
                if (!marcas.Any(m => m.idMarca == dto.IdMarca))
                    return BadRequest("La marca no existe");

                //validamos que la categoria exista
                var gestorCategorias = new gestionCategoria();
                var categorias = new gestionCategoria().listar();
                if (!categorias.Any(c => c.idCategoria == dto.IdCategoria))
                    return BadRequest("la categoria no existe");
                //copiamos los datos recibidos
                var articulo = new articulos
                {
                    idArticulo = id,
                    codigo = dto.Codigo,
                    nombre = dto.Nombre,
                    descripcion = dto.Descripcion,
                    precio = dto.Precio,
                    marca = new marcas { idMarca = dto.IdMarca },
                    categoria = new categorias { idCategoria = dto.IdCategoria },
                    imagenUrl = dto.ImagenUrl
                };
                gestorArticulos.modificar(articulo);
                return Ok(new { mensaje = "arituclo modificado correctamente", id = id });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("error al modificar el articulo : " + ex.Message));
            }


        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //verificamos que exista el articulo a eliminar
                var gestor = new gestionArticulos();
                var articulo = gestor.listar().FirstOrDefault(a => a.idArticulo == id);
                if (articulo == null)
                    return (NotFound());//devuelve error si no existe
                //si existe lo eliminamos
                gestor.eliminar(id);

                //devolvemos confirmacion
                return Ok(new { mensaje = "articulo eliminado correctamente", id = id });

            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("error al eliminar el articulo :" + ex.Message));
            }

        }
        [HttpPost]
        [Route("api/Articulo/{id}/imagenes")]
        public IHttpActionResult Post(int id, List<string> imagenes)
        {
            try
            {
                if (imagenes == null || !imagenes.Any())
                {
                    return BadRequest("debe enviar al menos una imagen");
                }
                var gestorArticulos = new gestionArticulos();
                var articulo = gestorArticulos.listar().FirstOrDefault(a => a.idArticulo == id);
                if (articulo == null)
                    return NotFound();
                var gestorImagenes = new gestionImagenes();
                gestorImagenes.agregar(id, imagenes);
                return Ok(new { mensaje = "imagenes agregadas correctamente ", id = id , cantidad=imagenes.Count() });
            }
            catch(Exception ex)
            {
                return InternalServerError(new Exception("error al agregar imagenes :" + ex.Message));
            }
        }
    }

}
