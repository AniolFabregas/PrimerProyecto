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

        public void ponTiempoCiclo(double tiempo)
        {
            tiempoCiclo = tiempo;
        }

        public void ponDistanciaSeguridad(double distancia)
        {
            distanciaSeguridad = distancia;
        }

        // 3. Al carregar la finestra, posicionem els PictureBox (avionA i avionB)
        private void Simulacion_Load(object sender, EventArgs e)
        {
            avionA.BackColor = Color.Red;
            avionB.BackColor = Color.Blue;

            avion1.Restart();
            avion2.Restart();

            avionA.Location = posicionAvion(avion1);
            avionB.Location = posicionAvion(avion2);
        }

        // 4. Moure els avions quan es clica el botó
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

            miPanel.Invalidate();   
        }

        // 5. UNIFICACIÓ DEL PAINT (Fase 6 i Fase 7)
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
            ShowFlightInfo f = new ShowFlightInfo();
            if (avion1 != null) f.MostrarDatos(avion1);
            if (avion2 != null) f.MostrarDatos(avion2);
            f.ShowDialog();
        }

        private void avionA_Click(object sender, EventArgs e)
        {
            ShowFlightInfo f = new ShowFlightInfo();
            f.MostrarDatos(avion1);
            f.ShowDialog();
        }



        private void avionB_Click(object sender, EventArgs e)
        {
            ShowFlightInfo f = new ShowFlightInfo();
            f.MostrarDatos(avion2);
            f.ShowDialog();
        }


    }
}

