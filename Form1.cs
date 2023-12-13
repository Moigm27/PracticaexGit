using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Practicaex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                listar = new listarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la lista");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        listarDatos listar;
        int opt;

        private void button1_Click(object sender, EventArgs e)
        {
            opt = comboBox1.SelectedIndex;
            principal = new Thread(new ThreadStart(insertar));
            principal.Start();
        }
        private void insertarMedio(persona p)
        {
            try
            {
                nodo aux = new nodo();
                int contador = 2;
                for (aux = listar.getCabeza(); aux != null; aux = aux.GetSiguiente())
                {
                    if (contador == int.Parse(txt.Text))
                    {
                        listar.insertarMedio(aux, p);
                    }
                    contador++;
                }

            }
            catch
            {

            }
        }
        public void insertar()
        {
            
            CargarDatos cargar = new CargarDatos();
            persona p = new persona();
            string[] split = cargar.ConsultarAPI(int.Parse(cedula_text.Text)).Split(' ');
            p.apellido = split[0] +" "+ split[1];
            p.nombre = split[2] +" "+ split[3];

            
            switch (opt)
            {
                case 0:
                    listar.insertarAlFinal(p);

                    break;

                case 1:
                    listar.insertarCabeza(p);

                    break;

                case 2:

                    insertarMedio(p);
                    break;


                default:
                    break;
            }
            

        }
        public void insertarEngrid()
        {

            try
            {
                dataGridView1.Rows.Clear();
                nodo aux = new nodo();
                aux = listar.getCabeza();

                while (aux != null)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = aux.GetPersona().apellido;
                    row.Cells[1].Value = aux.GetPersona().nombre;
                    dataGridView1.Rows.Add(row);

                    aux = aux.GetSiguiente();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error al cargar el grid");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertarEngrid();
        }

        Thread principal;
    }
   
}
