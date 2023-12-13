using System;
using System.Windows.Forms;

namespace Practicaex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        listarDatos listar;
        private void button1_Click(object sender, EventArgs e)
        {



        }

        public void insertar()
        {
            
            CargarDatos cargar = new CargarDatos();
            persona p = new persona();
            string[] split = cargar.ConsultarAPI(int.Parse(cedula_text.Text)).Split(' ');
            p.apellido = split[0];
            p.nombre = split[1];

            int opt;
            opt = comboBox1.SelectedIndex;
            switch (opt)
            {
                case 1:
                    listar.insertarCabeza(p);
                    break;

                case 2:
                    listar.insertarAlFinal(p);
                    break;

                case 3:

                    break;


                default:
                    break;
            }

        }
        public void insertarEngrid()
        {


        }
    }
}
