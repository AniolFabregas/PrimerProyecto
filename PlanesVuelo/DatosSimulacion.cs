using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanesVuelo
{
    public partial class DatosSimulacion : Form
    {
        double valorDistanciaSeguridad;
        double valorTiempoCiclo;

        public DatosSimulacion()
        {
            InitializeComponent();
        }

        public double dameDistanciaSeguridad()
        {
            return valorDistanciaSeguridad;
        }

        public double dameTiempoCiclo()
        {
            return valorTiempoCiclo;
        }
        private void aceptar_Click(object sender, EventArgs e)
        {
            //asignamos el valor a las variables y comprobamos que el formato del textbox sea valido
            try
            {
                valorDistanciaSeguridad = Convert.ToDouble(distanciaSeguridad.Text);

                valorTiempoCiclo = Convert.ToDouble(tiempoCiclo.Text);

                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Se ha producido un error en los formatos de texto");
                return;
            }
            Close();
        }

        private void DatosSimulacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //asignamos el valor a las variables y comprobamos que el formato del textbox sea valido
            try
            {
                valorDistanciaSeguridad = Convert.ToDouble(distanciaSeguridad.Text);

                valorTiempoCiclo = Convert.ToDouble(tiempoCiclo.Text);

                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Se ha producido un error en los formatos de texto");
                return;
            }
            Close();
        }

        private void distanciaSeguridad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tiempoCiclo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
