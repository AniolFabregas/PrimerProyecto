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
            //els identificadors no poden estar buits
            if (textBox1.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Falta el identificador de algun plan de vuelo");
                return;   //sortim sense tancar el formulari, aixi l'usuari ho pot arreglar
            }

            double x1, y1, fx1, fy1, v1, x2, y2, fx2, fy2, v2;
            if (!LeerNumero(actualX1, "la posicion actual X del plan 1", out x1)) return;
            if (!LeerNumero(actualY1, "la posicion actual Y del plan 1", out y1)) return;
            if (!LeerNumero(finalX1, "la posicion final X del plan 1", out fx1)) return;
            if (!LeerNumero(finalY1, "la posicion final Y del plan 1", out fy1)) return;
            if (!LeerNumero(velocidad1, "la velocidad del plan 1", out v1)) return;
            if (!LeerNumero(coordenadaActualX2, "la posicion actual X del plan 2", out x2)) return;
            if (!LeerNumero(coordenadaActualY2, "la posicion actual Y del plan 2", out y2)) return;
            if (!LeerNumero(coordenadaFinalX2, "la posicion final X del plan 2", out fx2)) return;
            if (!LeerNumero(coordenadaFinalY2, "la posicion final Y del plan 2", out fy2)) return;
            if (!LeerNumero(valorVelocidad2, "la velocidad del plan 2", out v2)) return;

            // una velocitat de 0 o negativa no te sentit
            if (v1 <= 0 || v2 <= 0)
            {
                MessageBox.Show("La velocidad tiene que ser mayor que 0");
                return;
            }

            //creem els dos plans de vol amb el constructor
            plan1 = new FlightPlan(textBox1.Text, x1, y1, fx1, fy1, v1);
            plan2 = new FlightPlan(textBox7.Text, x2, y2, fx2, fy2, v2);
            Close();   // i tanquem el formulari
        }

        private bool LeerNumero(TextBox caja, string queEs, out double valor)
        {
            try
            {
                valor = Convert.ToDouble(caja.Text);   //intentem passar el text a numero
                return true;                          
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en " + queEs + ": tiene que ser un numero");   // diem quina caixa esta malament
                valor = 0;                             
                return false;                      
            }
        }
    }
}

