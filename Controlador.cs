using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace caso_integrado_1
{
    internal class Controlador
    {
        public void notas(Form1 formulario, string Fnombre, string Fnota1, string Fnota2, string Fnota3)
        {
            double Corte1 = 0, Corte2 = 0, Corte3 = 0, Definitiva = 0;
            string estudiante = Fnombre;
            string patron = @"^[a-zA-Z]+( [a-zA-Z]+)*$"; //Expresion regular para verificar que el nombre no contenga otros valores que no sean letras

            bool nombreValido = Regex.IsMatch(estudiante, patron);
            bool notasValidas = double.TryParse(Fnota1, out Corte1) && Corte1 >= 0 &&
                               double.TryParse(Fnota2, out Corte2) && Corte2 >= 0 &&
                               double.TryParse(Fnota3, out Corte3) && Corte3 >= 0;

            if (nombreValido)
            {
                //va vacio ya que estamos validando que el nombre no contenga otros valores que no sean letras
            }
            else
            {
                MessageBox.Show("Error: El nombre del estudiante debe contener solo letras y un espacio en medio de cada palabra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formulario.PNombre.Text = "";
                formulario.PNota1.Text = "";
                formulario.PNota2.Text = "";
                formulario.PNota3.Text = "";
            }

            if (notasValidas)
            {
                //Pasamos los valores de las notas a Double para sacar la definitiva y los guardamos en las variables que se definieron al principio
                Corte1 = double.Parse(Fnota1);
                Corte2 = double.Parse(Fnota2);
                Corte3 = double.Parse(Fnota3);
                Definitiva = (Corte1 * 0.35) + (Corte2 * 0.35) + (Corte3 * 0.30);
            }
            else
            {
                MessageBox.Show("Error: Ingresa valores numéricos mayores a cero en los campos de notas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formulario.PNota1.Text = "";
                formulario.PNota2.Text = "";
                formulario.PNota3.Text = "";
            }

            // Verificamos si ambas validaciones fueron exitosas
            if (nombreValido && notasValidas)
            {
                //Llamamos a los metodos del Modelo para insertar los datos ya cuando Ambas validaciones son correctas
                Modelo modelo = new Modelo();
                if (modelo.Conectar())
                {
                    modelo.crear_registro(estudiante, Corte1, Corte2, Corte3, Definitiva);
                }
                //Despues de Registrar los datos mostramos la definitiva al usuario
                formulario.PNotaD.Text = Definitiva.ToString();

            }
        }
        public void Limpiar(Form1 formulario)
        {
            //Funcionalidad del boton Limpiar el cual deja todos los campos en blanco
            formulario.PNota1.Text = "";
            formulario.PNota2.Text = "";
            formulario.PNota3.Text = "";
            formulario.PNombre.Text = "";
            formulario.PNotaD.Text = "";
        }
    }
}
