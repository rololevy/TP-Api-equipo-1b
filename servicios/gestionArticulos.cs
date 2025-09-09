using dataManager;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                datos.setearConsulta("SELECT A.id AS idArticulo, A.codigo, A.nombre, A.descripcion, A.precio, M.id AS idMarca, M.Descripcion AS descMarca, C.id AS idCategoria, C.Descripcion AS descCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.idMarca = M.id INNER JOIN CATEGORIAS C ON A.idCategoria = C.id");
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

