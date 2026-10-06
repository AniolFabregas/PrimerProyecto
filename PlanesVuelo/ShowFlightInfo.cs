using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace PlanesVuelo
{
    public partial class ShowFlightInfo : Form
    {
        FlightPlan myFlight;
        public ShowFlightInfo()
        {
            InitializeComponent();
        }
        public void MostrarDatos(FlightPlan avion)
        {
            if (avion != null)
            {
                lblInformacion.Text = "Identificador: " + avion.GetId() + "\n" +
                                      "Velocitat: " + avion.GetVelocidad() + "\n" +
                                      "Posició actual: (" + avion.GetCurrentPosition().GetX().ToString("F2") +
                                      ", " + avion.GetCurrentPosition().GetY().ToString("F2") + ")";
            }
        }

      
        public void SetFlight(FlightPlan f)
        {
            this.myFlight = f;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
