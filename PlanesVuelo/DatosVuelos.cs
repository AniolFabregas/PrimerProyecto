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
    public partial class DatosVuelos : Form
    {
        FlightPlan plan1;
        FlightPlan plan2;
        public DatosVuelos()
        {
            InitializeComponent();
        }

        public void ponPlanes(FlightPlan a, FlightPlan b)
        {
            plan1 = a;
            plan2 = b;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // si es fa click a dalt de la taula, no es fa res

            DistanciaVuelos f = new DistanciaVuelos();
            if (e.RowIndex == 0)
                f.MostrarDistancia(plan1, plan2);
            else
                f.MostrarDistancia(plan2, plan1);
            f.ShowDialog();
        }

        private void DatosVuelos_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id", "Identificador");
            dataGridView1.Columns.Add("vel", "Velocidad");
            dataGridView1.Columns.Add("xAct", "X actual");
            dataGridView1.Columns.Add("yAct", "Y actual");
            dataGridView1.Columns.Add("xFin", "X destino");
            dataGridView1.Columns.Add("yFin", "Y destino");

            // Una fila per vol
            dataGridView1.Rows.Add(plan1.GetId(), plan1.GetVelocidad(),
                plan1.GetCurrentPosition().GetX(), plan1.GetCurrentPosition().GetY(),
                plan1.GetFinalPosition().GetX(), plan1.GetFinalPosition().GetY());

            dataGridView1.Rows.Add(plan2.GetId(), plan2.GetVelocidad(),
                plan2.GetCurrentPosition().GetX(), plan2.GetCurrentPosition().GetY(),
                plan2.GetFinalPosition().GetX(), plan2.GetFinalPosition().GetY());
        }
    }
}
