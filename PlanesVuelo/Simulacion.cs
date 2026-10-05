using FlightLib;
using System;
using System.Collections;
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
    public partial class Simulacion : Form
    {
        FlightPlan planA;
        FlightPlan planB;
        double tiempoCiclo;

        FlightPlanList miLista;
        private FlightPlan avion1;
        private FlightPlan avion2;
        public double distanciaSeguridad;



        public Simulacion()
        {
            InitializeComponent();
        }

        public void ponPlanA(FlightPlan plan)
        {
            avion1 = plan;
        }

        public void ponPlanB(FlightPlan plan)
        {
            avion2 = plan;
        }

       

        private void Simulacion_MouseClick(object sender, MouseEventArgs e)
        {
            


            if (avion2 != null)
            {
                double x2 = avion2.GetCurrentPosition().GetX();
                double y2 = avion2.GetCurrentPosition().GetY();



                if (avion1 != null)
                {
                    double x1 = avion1.GetCurrentPosition().GetX();
                    double y1 = avion1.GetCurrentPosition().GetY();
                }
            }
        }

        private void Simulacion_Load(object sender, EventArgs e)
        {
            
            if (avion1 != null && avion2 != null)
            {
                avionA.Location = convertirAPixeles(avion1.GetInitialPosition());   //l'avio A on surt el pla 1
                avionB.Location = convertirAPixeles(avion2.GetInitialPosition());   //l'avio B on surt el pla 2
            }
        }



        private void ShowFlightInfo(object sender, EventArgs e)
        {
            ShowFlightInfo f = new ShowFlightInfo();
            f.MostrarDatos(avion1);
            f.MostrarDatos(avion2);
            f.ShowDialog();
        }
        public void ponTiempoCiclo(double tiempo)
        {
            tiempoCiclo = tiempo;
        }

        private Point convertirAPixeles(Position posicion)
        {
            int x = Convert.ToInt32(posicion.GetX());
            int y = Convert.ToInt32(posicion.GetY());

            return new Point(x, y);
        }
        private void avionA_BackColorChanged(object sender, EventArgs e)
        {
        }

        //FASE 4: MOURE ELS AVIONS UN CICLE

        private void btnMover_Click(object sender, EventArgs e)
        {
            //si encara no tenim els dos plans de vol no podem moure res
            if (avion1 == null || avion2 == null)
            {
                MessageBox.Show("Primero hay que introducir los datos de los dos vuelos");
                return;                         
            }

            avion1.Move(tiempoCiclo);          
            avion2.Move(tiempoCiclo);          

            
            avionA.Location = convertirAPixeles(avion1.GetCurrentPosition());
            avionB.Location = convertirAPixeles(avion2.GetCurrentPosition());

            miPanel.Invalidate();               

            
            if (avion1.HasArrived() && avion2.HasArrived())
            {
                btnMover.Enabled = false;       // apaguem el boto perque no es pugui clicar mes
                MessageBox.Show("Los dos aviones han llegado a su destino");   
            }
        }

        private void FormSimulacion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Dibujar la distancia de seguridad del Avión 1
            if (avion1 != null)
            {
                DibujarDistanciaSeguridad(g, avion1, distanciaSeguridad, Pens.Red);
            }

            // Dibujar la distancia de seguridad del Avión 2
            if (avion2 != null)
            {
                DibujarDistanciaSeguridad(g, avion2, distanciaSeguridad, Pens.Blue);
            }
        }

        private void DibujarDistanciaSeguridad(Graphics g, FlightPlan avion, double radioSeguridad, Pen colorLina)
        {
            // 1. Obtener la posición actual del avión (en píxeles)
            float avionX = (float)avion.GetCurrentPosition().GetX();
            float avionY = (float)avion.GetCurrentPosition().GetY();

            // Tamaño del gráfico/icono del avión (asumiendo 20x20 px)
            float tamanoAvion = 20f;

            // 2. Calcular el centro exacto del avión
            float centroX = avionX + (tamanoAvion / 2f);
            float centroY = avionY + (tamanoAvion / 2f);

            // 3. Calcular la esquina superior izquierda de la elipse
            float diametro = (float)radioSeguridad * 2f;
            float elipseX = centroX - (float)radioSeguridad;
            float elipseY = centroY - (float)radioSeguridad;

            // 4. Dibujar la elipse alrededor del avión
            g.DrawEllipse(colorLina, elipseX, elipseY, diametro, diametro);
        }

        private void Simulacion_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (avion2 != null)
            {
                
                float origenX2 = (float)avion2.GetInitialPosition().GetX();
                float origenY2 = (float)avion2.GetInitialPosition().GetY();

               
                float destiX2 = (float)avion2.GetFinalPosition().GetX();
                float destiY2 = (float)avion2.GetFinalPosition().GetY();

                
                g.DrawLine(Pens.Blue, origenX2, origenY2, destiX2, destiY2);
            }

            //dibuixar trajectoria avio 1
            if (avion1 != null)
            {
               
                float origenX1 = (float)avion1.GetInitialPosition().GetX();
                float origenY1 = (float)avion1.GetInitialPosition().GetY();

              
                float destiX1 = (float)avion1.GetFinalPosition().GetX();
                float destiY1 = (float)avion1.GetFinalPosition().GetY();

               
                g.DrawLine(Pens.Blue, origenX1, origenY1, destiX1, destiY1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

