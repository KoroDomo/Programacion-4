// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DML_SqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            /**/
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("********** BIENVENIDO AL PROGRAMA DE MANIPULACION DE LA BASE DE DATOS (BD) ***************");
            Console.WriteLine("******************************************************************************************");
            var datasource = @"OFLO\SQLEXPRESS";//El nombre del servidor de BD
            var database = "Concesionario"; //El nombre de la base de datos
            var procedure = "sp_InsertaCliente";


            //Cadena de texto que  corresponde a la conexion.
            string str = "Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True;MultipleActiveResultSets=True";

            //Se crea la instancia que crea la BD
            SqlConnection SqlCon = new SqlConnection(str);

            try
            {
                SqlCommand cmd = new SqlCommand(procedure, SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdVehiculo", 6));
                cmd.Parameters.Add(new SqlParameter("@Nombre", "Juan"));
                cmd.Parameters.Add(new SqlParameter("@Apellidos", "De Los Palotes Marrano"));
                cmd.Parameters.Add(new SqlParameter("@Cedula", "00000000000"));
                cmd.Parameters.Add(new SqlParameter("@Direccion", "Av. De las Hortensias"));
                cmd.Parameters.Add(new SqlParameter("@Codigo", "Usado"));

                if(SqlCon.State != ConnectionState.Open)
                {
                    SqlCon.Open();
                }

                int n = cmd.ExecuteNonQuery();

                if(n > 0)
                {
                    Console.WriteLine("Se ha(n) insertado {0} registro(s).", n);
                }
                else
                {
                    Console.WriteLine("Intentalo de nuevo que ha ocurrido un error.");
                }

                Console.WriteLine("");
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("***********************LISTA DE CLIENTE REGISTRADOS*******************");

                // Metoodo de consulta para la tabla vehiculo
                ConsultaCliente(SqlCon);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //ArrayList datos = new ArrayList();

            /*Metodo para registrar Cliente*/
            //RegistraCliente(SqlCon);

            //string[] datos = new string[] { "1", "Dioris", "Arias", "40221162023", "Parabola 42", "Nuevo" };
            //RegistraCliente(SqlCon, datos);

            //datos = new string[] { "2", "Juan", "Santana", "9999999999", "Ave Independencia 5", "Usado" };
            //RegistraCliente(SqlCon, datos);

            //datos = new string[] { "3", "Pedro", "Pelaez", "1234567890", "Ave Sarasota 43", "Nuevo" };
            //RegistraCliente(SqlCon, datos);

            //datos = new string[] { "4", "Miguel", "Sosa", "1472589630", "Ave Charles Sumner 1", "Usado" };
            //RegistraCliente(SqlCon, datos);

            //datos = new string[] { "5", "Jose", "Santos", "3692581477", "Ave 27 de Febrero 49", "Nuevo" };
            //RegistraCliente(SqlCon, datos);

            /*Metodo para actualizar Cliente*/
            //ActualizaCliente(SqlCon);
            //string[] actDatos = new string[] { "Jose", "Ferreiras", "Conde Peatonal 007", "40221162023"};
            //ActualizaCliente(SqlCon, actDatos);

            //actDatos = new string[] { "Melvin", "Quinones", "Ave Ecologica 900", "1472589630" };
            //ActualizaCliente(SqlCon, actDatos);


            /*Metodo de consulta para  la tabla Cliente*/
            //ConsultaCliente(SqlCon);

            /*Metodo para eliminar Cliente*/
            //string elimCedula = "1234567890";
            //EliminaCliente(SqlCon, elimCedula);


            //ConsultaCliente(SqlCon);

            Console.WriteLine("Cerrando conexion ...");

            //Instruccion que cierra la conexion de BD
            if (SqlCon.State != ConnectionState.Closed)
            {
                SqlCon.Close();
            }
            Console.WriteLine("La conexion se ha cerrado exitosamente!");


            //Console.ReadKey();
        }

        #region ConsultaCliente. Metodo que realiza la consulta del Cliente
        private static void ConsultaCliente(SqlConnection SqlCon)
        {
            /*Variable que almacena el script de consulta*/
            string sCon = "SELECT * FROM Cliente";

            /*Permite obtener datos de la base de datos y cargarlos en memoria local*/
            SqlDataReader dt;


            try
            {
                Console.WriteLine("Abriendo conexion ...");

                //Instruccion que abre la conexion de BD
                if (SqlCon.State != ConnectionState.Open)
                {
                    SqlCon.Open();
                }

                Console.WriteLine("Conexion exitosa!");

                /*Se utiliza cuando necesitas ejecutar un tipo de sentencia Sql a la base de datos (los tipos pueden ser: Delete, Update, Insert o Select)*/
                SqlCommand cmd = new SqlCommand(sCon, SqlCon);
                /*Asigna a la variable DataReader el resultado de la ejecucion de la consulta*/
                dt = cmd.ExecuteReader();

                /*Se encarga de leer el contenido de la variable DataReader. Se utiliza el bucle Mientras para recorrer los registros almacenados en la variable*/
                while (dt.Read())
                {
                    /*Imprimimos los resultados obtenidos*/
                    Console.WriteLine("Id Cliente: {0}\t Id Vehiculo: {1}\t Nombre: {2}\t Apellidos: {3}\t Cedula: {4}\t Direccion: {5}\t Codigo: {6}",
                        dt[0].ToString(), dt[1].ToString(), dt[2].ToString(), dt[3].ToString(), dt[4].ToString(), dt[5].ToString(), dt[6].ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        #endregion

        #region EliminaCliente. Se encarga de eliminar el cliente.
        private static void EliminaCliente(SqlConnection SqlCon, string elimCedula)
        {
            int n = 0;

            try
            {
                /*Variable que almacena el script de consulta*/
                string sCon = @"DELETE FROM Cliente WHERE cedula = @cedula";

                //Instruccion que abre la conexion de BD
                if (SqlCon.State != ConnectionState.Open)
                {
                    SqlCon.Open();
                }

                /*Se utiliza cuando necesitas ejecutar un tipo de sentencia Sql a la base de datos (los tipos pueden ser: Delete, Update, Insert o Select)*/
                SqlCommand cmd = new SqlCommand(sCon, SqlCon);
                cmd.Parameters.Add(new SqlParameter("@cedula", elimCedula));
                n = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            if (n > 0)
            {
                Console.WriteLine("Se ha(n) eliminado {0} registro(s).", n);
            }
            else
            {
                Console.WriteLine("Inténtalo de nuevo que ha ocurrido un error.");
            }
        }
        #endregion

        #region ActualizaCliente. Se encarga de actualizar el cliente.
        private static void ActualizaCliente(SqlConnection SqlCon, string[] actDatos)
        {
            int n = 0;

            try
            {
                /*Variable que almacena el script de consulta*/
                string sCon = @"UPDATE Cliente SET nombre = @nombre, apellidos = @apellidos, direccion = @direccion WHERE cedula = @cedula";

                //Instruccion que abre la conexion de BD
                if (SqlCon.State != ConnectionState.Open)
                {
                    SqlCon.Open();
                }

                /*Se utiliza cuando necesitas ejecutar un tipo de sentencia Sql a la base de datos (los tipos pueden ser: Delete, Update, Insert o Select)*/
                SqlCommand cmd = new SqlCommand(sCon, SqlCon);
                cmd.Parameters.Add(new SqlParameter("@nombre", actDatos[0]));
                cmd.Parameters.Add(new SqlParameter("@apellidos", actDatos[1]));
                cmd.Parameters.Add(new SqlParameter("@direccion", actDatos[2]));
                cmd.Parameters.Add(new SqlParameter("@cedula", actDatos[3]));
                n = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            if (n > 0)
            {
                Console.WriteLine("Se ha(n) actualizado {0} registro(s).", n);
            }
            else
            {
                Console.WriteLine("Inténtalo de nuevo que ha ocurrido un error.");
            }
        }
        #endregion

        #region RegistraCliente. Se encarga de registrar el cliente.
        private static void RegistraCliente(SqlConnection SqlCon, string[] datos)
        {
            int n = 0;

            try
            {
                /*Variable que almacena el script de consulta*/
                string sCon = @"INSERT INTO Cliente (IdVehiculo, Nombre, Apellidos, Cedula, Direccion, Codigo)
                            VALUES
                            (@idvehiculo, @nombre, @apellidos, @cedula, @direccion, @codigo)";

                //Instruccion que abre la conexion de BD
                if (SqlCon.State != ConnectionState.Open)
                {
                    SqlCon.Open();
                }

                /*Se utiliza cuando necesitas ejecutar un tipo de sentencia Sql a la base de datos (los tipos pueden ser: Delete, Update, Insert o Select)*/
                SqlCommand cmd = new SqlCommand(sCon, SqlCon);
                cmd.Parameters.Add(new SqlParameter("@idvehiculo", datos[0]));
                cmd.Parameters.Add(new SqlParameter("@nombre", datos[1]));
                cmd.Parameters.Add(new SqlParameter("@apellidos", datos[2]));
                cmd.Parameters.Add(new SqlParameter("@cedula", datos[3]));
                cmd.Parameters.Add(new SqlParameter("@direccion", datos[4]));
                cmd.Parameters.Add(new SqlParameter("@codigo", datos[5]));
                n = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            if (n > 0)
            {
                Console.WriteLine("Se ha(n) insertado {0} registro(s).", n);
            }
            else
            {
                Console.WriteLine("Inténtalo de nuevo que ha ocurrido un error.");
            }
        }
        #endregion

    }
}
