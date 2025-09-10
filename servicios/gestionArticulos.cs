using dataManager;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace servicios
{
    public class gestionArticulos
    {
        public List<articulos> listar()
        {
            List<articulos> lista = new List<articulos>();
            accesoDatos datos = new accesoDatos();
            try
            {
                //datos.setearConsulta("SELECT A.id AS idArticulo, A.codigo, A.nombre, A.descripcion, A.precio, M.id AS idMarca, M.Descripcion AS descMarca, C.id AS idCategoria, C.Descripcion AS descCategoria, I.ImagenUrl FROM ARTICULOS A INNER JOIN MARCAS M ON A.idMarca = M.id INNER JOIN CATEGORIAS C ON A.idCategoria = C.id LEFT JOIN IMAGENES I ON I.IdArticulo = A.id;");
                datos.setearConsulta(@"
                SELECT A.Id AS idArticulo, A.Codigo, A.Nombre, A.Descripcion, A.Precio,
                        M.Id AS idMarca, M.Descripcion AS descMarca,
                        C.Id AS idCategoria, C.Descripcion AS descCategoria,
                        I.ImagenUrl AS imagenUrl
                FROM ARTICULOS A
                INNER JOIN MARCAS M ON A.IdMarca = M.Id
                INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                LEFT JOIN IMAGENES I 
                    ON I.IdArticulo = A.Id 
                    AND I.Id = (SELECT MIN(Id) FROM IMAGENES WHERE IdArticulo = A.Id)
                ORDER BY A.Nombre;");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();
                    aux.idArticulo = (int)(datos.Lector["idArticulo"]);
                    aux.codigo = (string)(datos.Lector["codigo"]);
                    aux.nombre = (string)(datos.Lector["nombre"]);
                    aux.descripcion = (string)(datos.Lector["descripcion"]);
                    aux.precio = (decimal)(datos.Lector["precio"]);
                    aux.categoria = new categorias();
                    aux.categoria.idCategoria = (int)(datos.Lector["idCategoria"]);
                    aux.categoria.descripcion = (string)(datos.Lector["descCategoria"]);
                    aux.marca = new marcas();
                    aux.marca.idMarca = (int)(datos.Lector["idMarca"]);
                    aux.marca.descripcion = (string)(datos.Lector["descMarca"]);
                    if (datos.Lector["imagenUrl"] is DBNull)
                    {
                        aux.imagenUrl = null;
                    }
                    else
                    {
                        aux.imagenUrl = (string)datos.Lector["imagenUrl"];
                       
                    }
                        lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

