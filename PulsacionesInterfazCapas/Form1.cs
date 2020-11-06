using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace PulsacionesInterfazCapas
{
    public partial class Form1 : Form
    {
        PesonaService personaService;
        public Form1()
        {
            InitializeComponent();
            personaService = new PesonaService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            if(TxtId.Text.Trim() == "")
            {
                MessageBox.Show("Dijite la identificacion.");
            }
            else
            {
                if (TxtNombre.Text.Trim() == "")
                {
                    MessageBox.Show("Dijite el nombre.");
                }
                else
                {
                    if (TxtEdad.Text.Trim() == "")
                    {
                        MessageBox.Show("Dijite la edad.");
                    }
                    else
                    {
                        if (CmbSexo.SelectedIndex == 0)
                        {
                            MessageBox.Show("Seleccione el sexo.");
                        }
                        else
                        {
                            Registrar();
                        }
                    }
                }
            }
        }

        private void Registrar()
        {
            Persona persona = new Persona
            {
                Identificacion = TxtId.Text,
                Edad = int.Parse(TxtEdad.Text),
                Sexo = CmbSexo.SelectedItem.ToString(),
                Nombre = TxtNombre.Text
            };

            if(personaService.BuscarxIdentificacion(persona.Identificacion) == 0)
            {
                personaService.Guardar(persona);
                MessageBox.Show("Persona Registrada.");
            }
            else
            {
                MessageBox.Show("Ya existe una persona registrada con esta identificacion.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DtgTodos.DataSource = personaService.ConsultarTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DtgTodos.DataSource = null;
        }
    }
}
