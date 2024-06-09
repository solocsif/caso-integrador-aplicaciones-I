using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace caso_integrado_1
{
    internal class Modelo
    {
        private SqlConnection connection; // Almacenamos la conexión como miembro de la clase

        public bool Conectar() // Definimos el  método  'Conectar'
        {
            string server = "localhost\\sqlexpress";
            string database = "notasPolitecnicoInternacional";
            string userId = "Poli";
            string password = "Holitas12";

            string connectionString = $"Server={server};Database={database};User Id={userId};Password={password};"; //Variable de conexion

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open(); //Abrimos conexion hacia base de datos
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void crear_registro(string Fnombre, double Corte1, double Corte2, double Corte3, double definitiva)
        {
            // Verificamos si la conexión está establecida y abierta
            if (connection != null && connection.State == ConnectionState.Open)
            {
                //Variable con el Insert Definido
                string insertQuery = "INSERT INTO tecnologiaDesarrolloSoftware (Nombre_estudiante, CORTE_1, CORTE_2, CORTE_3, DEFINITIVA) VALUES (@Fnombre, @Fnota1, @Fnota2, @Fnota3, @definitiva)";

                using (SqlCommand insertData = new SqlCommand(insertQuery, connection))
                {
                    insertData.Parameters.AddWithValue("@Fnombre", Fnombre);
                    insertData.Parameters.AddWithValue("@Fnota1", Corte1);
                    insertData.Parameters.AddWithValue("@Fnota2", Corte2);
                    insertData.Parameters.AddWithValue("@Fnota3", Corte3);
                    insertData.Parameters.AddWithValue("@definitiva", definitiva);

                    try
                    {
                        int rowsAffected = insertData.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro Guardado exitosamente");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear el registro");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al insertar datos: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: No hay conexión a la base de datos");
            }
        }
    }
}
