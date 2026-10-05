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

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

          double actualX1;

            try
            {
                actualX1 = Convert.ToDouble(actualX.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posicion actual X del plan de vuelo 1");
                return;
            }

            double actualY1;

            try
            {
                actualY1 = Convert.ToDouble(actualY.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición actual Y del plan 1");
                return;
            }

            //Lo mismo para la posición final

            double finalX1;

            try
            {
                finalX1 = Convert.ToDouble(finalX.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición final X del plan 1");
                return;
            }

            double finalY1;

            try
            {
                finalY1 = Convert.ToDouble(finalY.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición final Y del plan 1");
                return;
            }

            //Lo mismo para la velocidad 

            double velocidad1;

            try
            {
                velocidad1 = Convert.ToDouble(velocidad.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la velocidad del plan 1");
                return;
            }

            //pasamos a hacer lo mismo con el segundo flightplan

            double coordenadaActualX2;

            try
            {
                coordenadaActualX2 = Convert.ToDouble(actualX2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición actual X del plan 2");
                return;
            }

            double coordenadaActualY2;

            try
            {
                coordenadaActualY2 = Convert.ToDouble(actualY2.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Error en la posicion actual Y del plan 2");
                return;
            }

            double coordenadaFinalX2;

            try
            {
                coordenadaFinalX2 = Convert.ToDouble(finalX2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición final X del plan 2");
                return;
            }

            double coordenadaFinalY2;

            try
            {
                coordenadaFinalY2 = Convert.ToDouble(finalY2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la posición final Y del plan 2");
                return;
            }

            double valorVelocidad2;

            try
            {
                valorVelocidad2 = Convert.ToDouble(velocidad2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en la velocidad del plan 2");
                return;
            }

            //creamos objetos usando constructor de flightplan 

            plan1 = new FlightPlan(identificador1, actualX1, actualY1, finalX1, finalY1, velocidad1);
            plan2 = new FlightPlan(identificador2, coordenadaActualX2, coordenadaActualY2, coordenadaFinalX2, coordenadaFinalY2, valorVelocidad2);

            //cerramos una vez que ya hemos validado todos los datos
            Close();

        }


    }
}
