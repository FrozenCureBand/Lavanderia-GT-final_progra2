using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pfinal_labanderia
{
    public partial class logoing : Form
    {
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
            string usuario = textUser.Text;
            string contrasena = textContraseña.Text;

            if (usuario == "admin" && contrasena == "123")
            {
                precentacion _presentacion = new  precentacion();
                _presentacion.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }




        }






    }
}
