using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;

namespace Pfinal_labanderia
{
    public partial class logoing : Form
    {
        private readonly NLogin negocioLogin = new NLogin();
        public logoing()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = negocioLogin.IniciarSesion(textUser.Text, textContraseña.Text);
                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o la cuenta está inactiva.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textContraseña.Clear();
                    textContraseña.Focus();
                    return;
                }
                SesionActual.Usuario = usuario;
                SesionActual.Accesos = negocioLogin.ObtenerAccesos(usuario.IdRol.Value);
                precentacion _presentacion = new precentacion();
                _presentacion.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}
