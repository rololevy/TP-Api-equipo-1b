using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
    }
}