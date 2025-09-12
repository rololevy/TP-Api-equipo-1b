using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dataManager
{
    public class accesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public accesoDatos()
        {
            conexion = new SqlConnection("server=(local)\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura() {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            
            conexion.Close();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //de tipo no consulta
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void setearParametro(string nombre, object valor)
        {
            //AddWithValue recibe dos parámetros un string y un object
            //objeto porque puede recibir cualquier tipo de valor.
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
