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
            }
            catch (FormatException)
            {
                MessageBox.Show("Se ha producido un error en el formato de la distancia de seguridad");
                return;
            }


            try
            {
                valorTiempoCiclo = Convert.ToDouble(tiempoCiclo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Se ha producido un error en el formato del tiempo de ciclo");
                return;
            }
            Close();
        }

        private void DatosSimulacion_Load(object sender, EventArgs e)
        {

        }
    }
}
