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
    public partial class PlanesVuelo : Form
    {
        FlightPlan plan1;
        FlightPlan plan2;

        public FlightPlan damePlan1()
        {
            return plan1;
        }

        public FlightPlan damePlan2()
        {
            return plan2;
        }

        public PlanesVuelo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            string id1 = identificador1.Text;
            string id2 = identificador2.Text;

        }
    } 
}

