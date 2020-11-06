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

            if(personaService.ValidarExiste(persona.Identificacion) == 0)
            {
                GuardarPersonaResponse personaRegistrada = personaService.Guardar(persona);
                MessageBox.Show("Persona Registrada. Su pulsacion es: "+personaRegistrada.Persona.Pulsacion.ToString());
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ValidarModificar();
        }

        private void ValidarModificar()
        {
            if(CmbModificar.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el campo a modificar.");
            }
            else
            {
                if(TxtCampo.Text.Trim() == "")
                {
                    MessageBox.Show("Dijite el campo a modificar.");
                }
                else
                {
                    Modificar();
                }
            }
        }


        private void Modificar()
        {
            Persona persona = personaService.ConsultarPersona(LbnlIdentificacion.Text);
            switch (CmbModificar.SelectedItem)
            {
                case "Nombre":
                    persona.Nombre = TxtCampo.Text.Trim();
                    break;
                case "Edad":
                    persona.Edad = int.Parse(TxtCampo.Text.Trim());
                    break;
            }
            personaService.Modificar(persona);
            LblEdad.Text = persona.Edad.ToString();
            LblNombres.Text = persona.Nombre;
            LblPulsacion.Text = persona.Pulsacion.ToString();
            LblSexo.Text = persona.Sexo;
            LbnlIdentificacion.Text = persona.Identificacion;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void ValidarBuscar()
        {
            if(TextBuscar.Text.Trim() == "")
            {
                MessageBox.Show("Dijite la identificacion de la persona a buscar.");
            }
            else
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            Persona personaEncontrada = personaService.ConsultarPersona(TextBuscar.Text);
            if(personaEncontrada == null)
            {
                MessageBox.Show("No existe una persona registrada con esta identificacion.");
            }
            else
            {

                LblEdad.Text = personaEncontrada.Edad.ToString();
                LblNombres.Text = personaEncontrada.Nombre;
                LblPulsacion.Text = personaEncontrada.Pulsacion.ToString();
                LblSexo.Text = personaEncontrada.Sexo;
                LbnlIdentificacion.Text = personaEncontrada.Identificacion;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Persona personaEncontrada = personaService.ConsultarPersona(TextBuscar.Text);
            if (personaEncontrada == null)
            {
                MessageBox.Show("No existe una persona registrada con esta identificacion.");
            }
            else
            {
                personaService.EliminarPersona(TextBuscar.Text);
                MessageBox.Show("Persona eliminada.");
                LblEdad.Text = "";
                LblNombres.Text = "";
                LblPulsacion.Text = "";
                LblSexo.Text = "";
                LbnlIdentificacion.Text = "";
            }
        }

        private void DvgConsultar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
