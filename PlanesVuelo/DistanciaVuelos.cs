using FlightLib;
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
    public partial class DistanciaVuelos : Form
    {
        public DistanciaVuelos()
        {
            InitializeComponent();
        }

        public void MostrarDistancia(FlightPlan a, FlightPlan b)
        {
            lblDistancia.Text = "Distancia entre " + a.GetId() + " y " + b.GetId() +
                                ": " + a.Distance(b).ToString("F2");
        }

        private void DistanciaVuelos_Load(object sender, EventArgs e)
        {

        }
    }
}
