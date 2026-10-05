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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesVuelo F2 = new PlanesVuelo();
            F2.ShowDialog();

            FlightPlan plan1;
            FlightPlan plan2;

            plan1 = F2.damePlan1();
            plan2 = F2.damePlan2();
        }

        private void datosDeSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosSimulacion F3 = new DatosSimulacion();
            F3.ShowDialog();

            double distanciaSeguridad;
            double tiempoCiclo;

            distanciaSeguridad = F3.dameDistanciaSeguridad();
            tiempoCiclo = F3.dameTiempoCiclo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
