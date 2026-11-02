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


    public partial class CambiarVelocidades : Form
    {
        FlightPlan plan1;
        FlightPlan plan2;
        public CambiarVelocidades()
        {
            InitializeComponent();
        }

        public void ponPlanes(FlightPlan a, FlightPlan b)
        {
            plan1 = a;
            plan2 = b;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CambiarVelocidades_Load(object sender, EventArgs e)
        {
            // Mostramos los datos actuales
            lblId1.Text = plan1.GetId();
            txtVel1.Text = plan1.GetVelocidad().ToString();
            lblId2.Text = plan2.GetId();
            txtVel2.Text = plan2.GetVelocidad().ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                double vel1 = Convert.ToDouble(txtVel1.Text);
                double vel2 = Convert.ToDouble(txtVel2.Text);

                if (vel1 <= 0 || vel2 <= 0)
                {
                    MessageBox.Show("Las velocidades deben ser mayores que 0.");
                }
                else
                {
                    plan1.SetVelocidad(vel1);
                    plan2.SetVelocidad(vel2);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Las velocidades deben ser números.");
            }
        }
    }
}

