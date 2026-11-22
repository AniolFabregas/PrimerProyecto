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
        bool comprobado = false;

        // cada element guarda les posicions dels dos avions abans d'un cicle
        Stack<List<Position>> historial = new Stack<List<Position>>();

        private FlightPlan avion1;
        private FlightPlan avion2;
        public double distanciaSeguridad;
        FlightPlanList lista;   // la llista de vols (es la mateixa que la de Form1, no una copia)

        public Simulacion()
        {
            InitializeComponent();
        }

        // 2. Mètodes per rebre els plans de vol des de Form1
        public void ponPlanA(FlightPlan plan)
        {
            avion1 = plan;
        }

        public void ponLista(FlightPlanList l)
        {
            lista = l;
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

        // Boto Guardar vuelos: para la simulacio i guarda els vols en un fitxer de text
        // per poder continuar un altre dia des d'aquest mateix punt
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            timer1.Stop();   // parem el timer, si no els avions es seguirien movent mentre triem on guardar

            if (avion1 == null || avion2 == null)
            {
                MessageBox.Show("No hay vuelos para guardar.");
                return;
            }

            // finestra de "Guardar como" de Windows, nomes deixa triar fitxers .txt
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.FileName = "vuelos_guardados.txt";
            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;   // si cancela no fem res i es pot seguir simulant
            }

            // la simulacio treballa amb avion1 i avion2, aixi que guardem aquests dos
            FlightPlanList aGuardar = new FlightPlanList();
            aGuardar.AddFlightPlan(avion1);
            aGuardar.AddFlightPlan(avion2);

            // el fitxer l'escriu la classe, aqui nomes avisem si falla (carpeta sense permis, fitxer obert...)
            try
            {
                aGuardar.SaveToFile(dialogo.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido guardar el archivo: " + ex.Message);
                return;
            }

            // diem on s'ha guardat i com continuar, i preguntem si vol sortir
            DialogResult r = MessageBox.Show("Vuelos guardados en " + dialogo.FileName +
                "\nPara continuar otro día, carga este archivo con Datos > Cargar archivo.\n\n¿Quieres salir del programa?",
                "Simulación guardada", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Application.Exit();   // tanca totes les finestres del programa
            }
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

            btnDeshacer.Enabled = false;   // al principi no hi ha res per desfer
        }

        // Guarda on estan els avions ara, per poder desfer el cicle que ve
        private void GuardarPosiciones()
        {
            if (avion1.HasArrived() && avion2.HasArrived())
            {
                return;   // no es mouran, no cal guardar res
            }

            List<Position> posiciones = new List<Position>();
            Position posicion1 = avion1.GetCurrentPosition();
            Position posicion2 = avion2.GetCurrentPosition();
            posiciones.Add(new Position(posicion1.GetX(), posicion1.GetY()));
            posiciones.Add(new Position(posicion2.GetX(), posicion2.GetY()));
            historial.Push(posiciones);
            btnDeshacer.Enabled = true;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (historial.Count == 0)
            {
                return;
            }

            List<Position> posiciones = historial.Pop();
            avion1.SetCurrentPosition(posiciones[0]);
            avion2.SetCurrentPosition(posiciones[1]);
            ColocarAviones();
            ActualizarAlarma(double.MaxValue);   // MaxValue = no hi ha cap cicle que mirar
            btnDeshacer.Enabled = historial.Count > 0;
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            GuardarPosiciones();   // guardem on estan ara, per poder desfer aquest cicle

            // igual que al timer, ANTES de moure mirem lo més a prop que estaran durant el cicle
            double minimaCiclo = avion1.DistanciaMinima(avion2, tiempoCiclo);

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
            ActualizarAlarma(minimaCiclo);
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
            GuardarPosiciones();   // per poder desfer aquest cicle

            // igual que en el botón Ciclo, ANTES de mover miramos lo más cerca que estarán durante este ciclo
            double minimaCiclo = avion1.DistanciaMinima(avion2, tiempoCiclo);

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

            ActualizarAlarma(minimaCiclo);
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

        private bool HayConflicto()
        {
            bool conflicto = false;

            // Comencem des del principi
            avion1.Restart();
            avion2.Restart();

            // lo que dura el vuelo entero: hasta que llega el último de los dos aviones
            double tiempoTotal = Math.Max(avion1.TiempoParaLlegar(), avion2.TiempoParaLlegar());

            // lo más cerca que van a estar en todo el vuelo (sin saltarse nada entre ciclos)
            double minima = avion1.DistanciaMinima(avion2, tiempoTotal);

            // hay conflicto si en algún momento van a estar más cerca que la distancia de seguridad
            if (minima < distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }

        private void ActualizarAlarma(double minimaCiclo)
        {
            double distanciaAhora = avion1.Distance(avion2);                                           // la distancia ahora mismo
            double derivada = avion1.DerivadaDistancia(avion2);                                        // negativa = se acercan, positiva = se alejan
            double tiempoRestante = Math.Max(avion1.TiempoParaLlegar(), avion2.TiempoParaLlegar());   // lo que les falta de vuelo
            double minimaFutura = avion1.DistanciaMinima(avion2, tiempoRestante);                      // lo más cerca que estarán a partir de ahora

            string aviso;      // el texto que pondremos en la etiqueta
            Color color;       // y el color del texto

            if (distanciaAhora < 2 * distanciaSeguridad)
            {
                aviso = "¡ALERTA! Distancia de\nseguridad vulnerada";
                color = Color.Red;
            }
            else if (minimaCiclo < distanciaSeguridad)
            {
                aviso = "¡ALERTA! Separación perdida\nen el último ciclo (mín.: " + minimaCiclo.ToString("F1") + ")";
                color = Color.Red;
            }
            else if (minimaFutura < distanciaSeguridad)
            {
                aviso = "PRECAUCIÓN: van a perder la\nseparación (mín. prevista: " + minimaFutura.ToString("F1") + ")";
                color = Color.DarkOrange;
            }
            else if (derivada < 0)
            {
                aviso = "Se acercan, sin conflicto\n(mín. prevista: " + minimaFutura.ToString("F1") + ")";
                color = Color.DarkGoldenrod;
            }
            else
            {
                aviso = "Distancia correcta";
                if (derivada > 0)
                    aviso = "Distancia correcta: se alejan";
                color = Color.Green;
            }

            lblAlarma.Text = aviso + "\nDistancia actual: " + distanciaAhora.ToString("F1");
            lblAlarma.ForeColor = color;
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
            {
                DialogResult r = MessageBox.Show(
                    "Los vuelos entrarán en conflicto. ¿Quieres resolverlo?",
                    "Conflicto", MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                    ResolverConflicto();
            }
            else
            {
                MessageBox.Show("Los vuelos no entrarán en conflicto.");
            }

            historial.Clear();   // HayConflicto ha reiniciat els avions, l'historial ja no val
            btnDeshacer.Enabled = false;
            ColocarAviones();
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            avion1.Restart();
            avion2.Restart();
            historial.Clear();
            btnDeshacer.Enabled = false;
            ColocarAviones();
        }
        private void lblInformacion_Click(object sender, EventArgs e)
        {

        }

        private void btnVelocidades_Click(object sender, EventArgs e)
        {
            timer1.Stop();   // paramos la simulación automática si estaba en marcha

            CambiarVelocidades f = new CambiarVelocidades();
            f.ponPlanes(avion1, avion2);

            if (f.ShowDialog() == DialogResult.OK)
            {
                // Reiniciamos la simulación con las nuevas velocidades
                avion1.Restart();
                avion2.Restart();
                historial.Clear();
                btnDeshacer.Enabled = false;
                ColocarAviones();

                comprobado = false;   // para que al iniciar vuelva a comprobar el conflicto
            }
        }
    }
}