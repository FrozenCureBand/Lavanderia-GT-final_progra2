using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Pfinal_labanderia
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string mensaje;
            bool conectado = NConexion.ProbarConexion(out mensaje);
            MessageBox.Show(mensaje,
                conectado ? "Prueba de conexión" : "Error de conexión",
                MessageBoxButtons.OK,
                conectado ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            Application.Run(new logoing());
        }
    }
}
