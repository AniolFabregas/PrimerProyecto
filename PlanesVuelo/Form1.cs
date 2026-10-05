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
        FlightPlan plan1;           
        FlightPlan plan2;              
        double distanciaSeguridad; 
        double tiempoCiclo;         

        public Form1()
        {
            InitializeComponent();
        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesVuelo F2 = new PlanesVuelo();   
            F2.ShowDialog();                      

            plan1 = F2.damePlan1();   
            plan2 = F2.damePlan2();   
        }

        private void datosDeSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosSimulacion F3 = new DatosSimulacion();   
            F3.ShowDialog();                              

            distanciaSeguridad = F3.dameDistanciaSeguridad();  
            tiempoCiclo = F3.dameTiempoCiclo();                
        }

        private void iniciarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (plan1 == null || plan2 == null)
            {
                MessageBox.Show("Primero introduce los planes de vuelo (Datos > Planes de Vuelo)");
                return;  
            }

            
            if (tiempoCiclo <= 0)
            {
                MessageBox.Show("Primero introduce los datos de simulacion (Datos > Datos de Simulacion)");
                return;
            }

            plan1.Restart();   
            plan2.Restart();

            Simulacion F4 = new Simulacion();            
            F4.ponPlanA(plan1);                         
            F4.ponPlanB(plan2);                         
            F4.ponTiempoCiclo(tiempoCiclo);               
            F4.distanciaSeguridad = distanciaSeguridad;    
            F4.ShowDialog();                            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}