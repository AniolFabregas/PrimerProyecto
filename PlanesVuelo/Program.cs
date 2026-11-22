using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanesVuelo
{
    internal static class Program
    {
        /// <summary>

        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializar la base de datos de usuarios
            UserDatabase.InitializeDatabase();

            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Si el usuario se autentica correctamente,
                    // iniciar la aplicación principal
                    Application.Run(new Form1());
                }
            }
        }
    }
}
