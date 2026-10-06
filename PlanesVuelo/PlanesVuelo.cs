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

    

        private void button1_Click(object sender, EventArgs e)
        {
            string textoid1 = id1.Text;
            double origX1 = Convert.ToDouble(actualX1.Text);
            double origY1 = Convert.ToDouble(actualY1.Text);
            double destX1 = Convert.ToDouble(finalX1.Text);
            double destY1 = Convert.ToDouble(finalY1.Text);
            double vel1 = Convert.ToDouble(velocidad1.Text);

            // 2. Llegir les dades dels TextBox de l'Avió 2
            string textoid2 = id2.Text;
            double origX2 = Convert.ToDouble(coordenadaActualX2.Text);
            double origY2 = Convert.ToDouble(coordenadaActualY2.Text);
            double destX2 = Convert.ToDouble(coordenadaFinalX2.Text);
            double destY2 = Convert.ToDouble(coordenadaFinalY2.Text);
            double vel2 = Convert.ToDouble(valorVelocidad2 .Text);

        }
    } 
}

