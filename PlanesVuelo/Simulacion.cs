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
        bool comprobado = false;


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

            if (avion1.Distance(avion2) < distanciaSeguridad)
            {
                lblAlarma.Text = "¡ALERTA! Distancia de seguridad vulnerada";
                lblAlarma.ForeColor = Color.Red;
            }
            else
            {
                lblAlarma.Text = "Distancia correcta";
                lblAlarma.ForeColor = Color.Green;
            }
        }

        private void Simulacion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Dibuixem les línies de trajectòria dels avions
            g.DrawLine(Pens.Red, convertirAPixeles(avion1.GetInitialPosition()),
                                 convertirAPixeles(avion1.GetFinalPosition()));
            g.DrawLine(Pens.Blue, convertirAPixeles(avion2.GetInitialPosition()),
                                  convertirAPixeles(avion2.GetFinalPosition()));

            // Dibuixem les el·lipses de seguretat al voltant dels avions
            DibujarElipse(g, avion1, Pens.Red);
            DibujarElipse(g, avion2, Pens.Blue);
        }

        private void DibujarElipse(Graphics g, FlightPlan avion, Pen lapiz)
        {
            Point centro = convertirAPixeles(avion.GetCurrentPosition());
            float radio = (float)distanciaSeguridad;
            g.DrawEllipse(lapiz, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
        }




        // Mètode per assignar a cada píxel del panell la posició corresponent a la posició de l'avió en el pla de vol
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

        private void iniciarSimulacion_Click(object sender, EventArgs e)
        {
            if (!comprobado)
            {
                comprobado = true;

                if (HayConflicto())
                {
                    DialogResult r = MessageBox.Show(
                        "Los vuelos entrarán en conflicto. ¿Quieres resolverlo?",
                        "Conflicto", MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes)
                        ResolverConflicto();
                }
                ColocarAviones();
            }
            timer1.Start();
       
            }

        private void ResolverConflicto()
        {
            bool conflicto = HayConflicto();

            while (conflicto && avion2.GetVelocidad() > 1)
            {
                avion2.SetVelocidad(avion2.GetVelocidad() * 0.9);
                conflicto = HayConflicto();
            }

            if (conflicto)
                MessageBox.Show("No se ha podido resolver el conflicto.");
            else
                MessageBox.Show("Conflicto resuelto. Nueva velocidad: " + avion2.GetVelocidad().ToString("F2"));
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

            if (avion1.Distance(avion2) < distanciaSeguridad)
            {
                lblAlarma.Text = "¡ALERTA! Distancia de seguridad vulnerada";
                lblAlarma.ForeColor = Color.Red;
            }
            else
            {
                lblAlarma.Text = "Distancia correcta";
                lblAlarma.ForeColor = Color.Green;
            }
        }

        private void detenerSimulacion_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosVuelos f = new DatosVuelos();
            f.ponPlanes(avion1, avion2);
            f.ShowDialog();
        }

        private void lblInformacion_Click(object sender, EventArgs e)
        {

        }

        private bool HayConflicto()
        {
            bool conflicto = false;

            // Comencem des del principi
            avion1.Restart();
            avion2.Restart();

            
            if (avion1.Conflicto(avion2, distanciaSeguridad))
                conflicto = true;

            // Movem els avions cicle a cicle fins que arribin a la seva destinació
            while (!avion1.HasArrived() || !avion2.HasArrived())
            {
                avion1.Move(tiempoCiclo);
                avion2.Move(tiempoCiclo);

                if (avion1.Conflicto(avion2, distanciaSeguridad))
                    conflicto = true;
            }

            // Deixem els avions un altre cop a l'origen per a que es pugui tornar a simular
            avion1.Restart();
            avion2.Restart();

            return conflicto;
        }

        private void ColocarAviones()
        {
            avionA.Location = posicionAvion(avion1);
            avionB.Location = posicionAvion(avion2);
            miPanel.Invalidate();
        }

        private void btnConflicto_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (HayConflicto())
                MessageBox.Show("Los vuelos entrarán en conflicto.");
            else
                MessageBox.Show("Los vuelos no entrarán en conflicto.");

            ColocarAviones();
        }
    }
    }


