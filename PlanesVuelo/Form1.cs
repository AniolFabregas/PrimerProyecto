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
        double valorDistanciaSeguridad;
        double valorTiempoCiclo;
        public static FlightPlan planA;
        public static FlightPlan planB;
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
            DatosSimulacion f = new DatosSimulacion();
            f.ShowDialog();
            valorDistanciaSeguridad = f.dameDistanciaSeguridad();
            valorTiempoCiclo = f.dameTiempoCiclo();
            if (valorTiempoCiclo <= 0 || valorDistanciaSeguridad <= 0)
            {
                MessageBox.Show("Primero tienes que introducir los datos de simulación.");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // amb els altres camps de la classe
        FlightPlanList lista = new FlightPlanList();

        private void iniciarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Comprovem que s'hagin introduït les dades
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
            f.ponLista(lista);   // li passem la llista de vols perque la pugui guardar
            f.ShowDialog();


        }

        private void cargarArchivoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // si es cancela no es fa res
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            // llegim a una llista nova, aixi si hi ha error es queda la que ja teniem
            FlightPlanList nueva = new FlightPlanList();
            try
            {
                nueva.LoadFromFile(openFileDialog1.FileName);
            }
            catch (FormatException)
            {
                MessageBox.Show("El archivo tiene algun dato que no es un numero.\nFormato de cada linea: id aerolinea xInicial yInicial xFinal yFinal velocidad");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido leer el archivo: " + ex.Message);
                return;
            }

            lista = nueva;
            MessageBox.Show("Se han cargado " + lista.GetNumber() + " vuelos.");
        }
    }
}

