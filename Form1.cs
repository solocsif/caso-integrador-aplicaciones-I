using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace caso_integrado_1
{
    public partial class Form1 : Form
    {

        public TextBox PNombre; // Control Nombre público
        public TextBox PNota1;  // Control Nota1 público
        public TextBox PNota2;  // Control Nota2 público
        public TextBox PNota3;  // Control Nota3 público
        public TextBox PNotaD;  // Control NotaD público

        public Form1()
        {
            InitializeComponent();
            PNombre = this.Controls["Nombre"] as TextBox;
            PNota1 = this.Controls["Nota1"] as TextBox;
            PNota2 = this.Controls["Nota2"] as TextBox;
            PNota3 = this.Controls["Nota3"] as TextBox;
            PNotaD = this.Controls["NotaD"] as TextBox;

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void Calcular_Click(object sender, EventArgs e)
        {
            Controlador controlador = new Controlador();
            String Fnombre = PNombre.Text; // Usar PNombre
            String Fnota1 = PNota1.Text;  // Usar PNota1
            String Fnota2 = PNota2.Text;  // Usar PNota2
            String Fnota3 = PNota3.Text;  // Usar PNota3
            controlador.notas(this,Fnombre, Fnota1, Fnota2, Fnota3); //Llamar al metodo del controlador con sus parametros


        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            Controlador controlador = new Controlador();
            controlador.Limpiar(this);
        }
    }
}
