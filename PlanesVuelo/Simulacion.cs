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
       
        double tiempoCiclo;
        double tiempo;


        private FlightPlan avion1;
        private FlightPlan avion2;
        public double distanciaSeguridad;



        public Simulacion()
        {
            InitializeComponent();
        }

        // 2. Mètodes per rebre els plans de vol des de Form1
        public void ponPlanA(FlightPlan plan)
        {
            avion1 = plan;
        }

        public void ponPlanB(FlightPlan plan)
        {
            avion2 = plan;
        }

        //private void nuevoPuntoToolStripMenuItem_Click(object sender, EventArgs e)

        private void Simulacion_MouseClick(object sender, MouseEventArgs e)
        {
            // Mida aproximada de la icona de l'avió per fer clic sobre ell (p. ex., un quadrat de 20x20 o marge de 15px)


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

        // 3. Al carregar la finestra, posicionem els PictureBox (avionA i avionB)
        private void Simulacion_Load(object sender, EventArgs e)
        {
         

        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (!avion1.HasArrived())
            {
                avion1.Move(tiempoCiclo);
                avionA.Location = posicionAvion(avion1);
            }

            if (!avion2.HasArrived())
            {
                avion2.Move(tiempoCiclo);
                avionB.Location = posicionAvion(avion2);
            }

        private void btnMover_Click(object sender, EventArgs e)
        {
            double tiempoCiclo = 1.0; // El tiempo configurado en la Fase 2

            // Mover los aviones
            avion1.Move(tiempoCiclo);
            avion2.Move(tiempoCiclo);

            // Forzar al formulario a repintarse (vuelve a llamar al evento Paint)
            this.Invalidate();
        }

        private void Simulacion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Trayectorias
            g.DrawLine(Pens.Red, convertirAPixeles(avion1.GetInitialPosition()),
                                 convertirAPixeles(avion1.GetFinalPosition()));
            g.DrawLine(Pens.Blue, convertirAPixeles(avion2.GetInitialPosition()),
                                  convertirAPixeles(avion2.GetFinalPosition()));

            // Elipses de seguridad
            DibujarElipse(g, avion1, Pens.Red);
            DibujarElipse(g, avion2, Pens.Blue);
        }

        private void DibujarElipse(Graphics g, FlightPlan avion, Pen lapiz)
        {
            Point centro = convertirAPixeles(avion.GetCurrentPosition());
            float radio = (float)distanciaSeguridad;
            g.DrawEllipse(lapiz, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
        }

            private void DibujarDistanciaSeguridad(Graphics g, FlightPlan avion, double radioSeguridad, Pen colorLina)
        {
            // 1. Obtener la posición actual del avión (en píxeles)
            float avionX = (float)avion.GetCurrentPosition().GetX();
            float avionY = (float)avion.GetCurrentPosition().GetY();

         

        // Mètode auxiliar de conversió a píxels
        private Point convertirAPixeles(Position posicion)
        {
            int x = Convert.ToInt32(posicion.GetX());
            int y = Convert.ToInt32(posicion.GetY());

            return new Point(x, y);
        }
        private Point posicionAvion(FlightPlan plan)
         {
            Point p = convertirAPixeles(plan.GetCurrentPosition());
             return new Point(p.X - avionA.Width / 2, p.Y - avionA.Height / 2);
          }

// Mostrar informació dels avions al fer clic a sobre
private void ShowFlightInfo(object sender, EventArgs e)
        {
          
            Graphics g = e.Graphics;

            if (avion2 != null)
            {
                // Obtenim X i Y del punt d'origen
                float origenX2 = (float)avion2.GetInitialPosition().GetX();
                float origenY2 = (float)avion2.GetInitialPosition().GetY();

                // Obtenim X i Y del punt de destí
                float destiX2 = (float)avion2.GetFinalPosition().GetX();
                float destiY2 = (float)avion2.GetFinalPosition().GetY();

                // Dibuixem la línia entre origen i destí (color Blau)
                g.DrawLine(Pens.Blue, origenX2, origenY2, destiX2, destiY2);
            }

            // Dibuixar trajectòria de l'Avió 1
            if (avion1 != null)
            {
                // Obtenim X i Y del punt d'origen
                float origenX1 = (float)avion1.GetInitialPosition().GetX();
                float origenY1 = (float)avion1.GetInitialPosition().GetY();

                // Obtenim X i Y del punt de destí
                float destiX1 = (float)avion1.GetFinalPosition().GetX();
                float destiY1 = (float)avion1.GetFinalPosition().GetY();

                // Dibuixem la línia entre origen i destí (color Blau)
                g.DrawLine(Pens.Blue, origenX1, origenY1, destiX1, destiY1);
            }
        }

        private void iniciarSimulacion_Click(object sender, EventArgs e)
        {
            timer1.Start();
       
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!avion1.HasArrived())
            {
                avion1.Move(tiempoCiclo);
                avionA.Location = posicionAvion(avion1);
            }

            if (!avion2.HasArrived())
            {
                avion2.Move(tiempoCiclo);
                avionB.Location = posicionAvion(avion2);
            }

            miPanel.Invalidate();

            if (avion1.HasArrived() && avion2.HasArrived())
            {
                timer1.Stop();
            }
        }

        private void detenerSimulacion_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
    }


