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
            PlanesVuelo f = new PlanesVuelo();
            f.ShowDialog(); 
            
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

        

        private void iniciarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Comprovem que s'hagin après/introduït les dades
            if (planA == null || planB == null)
            {
                MessageBox.Show("Primer has d'introduir els Planes de Vuelo!");
                return;
            }

            Simulacion f = new Simulacion();
            f.ponPlanA(planA);
            f.ponPlanB(planB);
            f.ponTiempoCiclo(valorTiempoCiclo);
            f.ponDistanciaSeguridad(valorDistanciaSeguridad);   
            f.ShowDialog();

          
            }

        }
    }

