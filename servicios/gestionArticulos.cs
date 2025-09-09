using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataManager;
using System.ComponentModel;

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
                datos.setearConsulta("select id,codigo,nombre,descripcion,precio from ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();
                    aux.idArticulo = (int)(datos.Lector["id"]);
                    aux.codigo = (string)(datos.Lector["codigo"]);
                    aux.nombre = (string)(datos.Lector["nombre"]);
                    aux.descripcion = (string)(datos.Lector["descripcion"]);
                    aux.precio = (decimal)(datos.Lector["precio"]);

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

