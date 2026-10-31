using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>CRUD sencillo para los tres roles y la configuración de accesos del menú.</summary>
    public class roles : Form
    {
        private readonly NRol negocio = new NRol();
        private readonly DataGridView tabla = new DataGridView();
        private readonly TextBox txtNombre = new TextBox();
        private readonly TextBox txtDescripcion = new TextBox();
        private readonly CheckBox chkActivo = new CheckBox();
        private readonly CheckedListBox listaAccesos = new CheckedListBox();
        private int idRol;

        public roles()
        {
            Text = "Administración de roles";
            Size = new Size(740, 500);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            tabla.Location = new Point(20, 55); tabla.Size = new Size(400, 310);
            tabla.ReadOnly = true; tabla.MultiSelect = false;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.CellClick += Tabla_CellClick;
            Controls.Add(tabla);

            Controls.Add(new Label { Text = "Nombre", Location = new Point(445, 55), AutoSize = true });
            txtNombre.Location = new Point(445, 78); txtNombre.Width = 250; Controls.Add(txtNombre);
            Controls.Add(new Label { Text = "Descripción", Location = new Point(445, 112), AutoSize = true });
            txtDescripcion.Location = new Point(445, 135); txtDescripcion.Width = 250; Controls.Add(txtDescripcion);
            chkActivo.Text = "Activo"; chkActivo.Location = new Point(445, 170); chkActivo.Checked = true; Controls.Add(chkActivo);
            Controls.Add(new Label { Text = "Accesos que puede abrir", Location = new Point(445, 200), AutoSize = true });
            listaAccesos.Location = new Point(445, 225); listaAccesos.Size = new Size(250, 195); Controls.Add(listaAccesos);
            AgregarBoton("Nuevo", 20, 385, (s,e) => Limpiar());
            AgregarBoton("Guardar", 110, 385, Guardar_Click);
            AgregarBoton("Eliminar", 200, 385, Eliminar_Click);
            Load += (s,e) => Consultar();
        }

        private void AgregarBoton(string texto, int x, int y, EventHandler evento)
        {
            Button boton = new Button { Text = texto, Location = new Point(x,y), Size = new Size(80,32) };
            boton.Click += evento; Controls.Add(boton);
        }

        private void Consultar()
        {
            try { tabla.DataSource = negocio.Consultar(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Roles", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                Rol rol = (Rol)tabla.Rows[e.RowIndex].DataBoundItem;
                idRol = rol.IdRol; txtNombre.Text = rol.NombreRol; txtDescripcion.Text = rol.Descripcion;
                chkActivo.Checked = rol.Estado;
                listaAccesos.Items.Clear();
                foreach (Acceso acceso in negocio.ConsultarAccesos(idRol))
                    listaAccesos.Items.Add(acceso, acceso.Permitido);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Roles", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Acceso> accesos = listaAccesos.Items.Cast<Acceso>().ToList();
                for (int i = 0; i < accesos.Count; i++) accesos[i].Permitido = listaAccesos.GetItemChecked(i);
                negocio.Guardar(new Rol { IdRol = idRol, NombreRol = txtNombre.Text, Descripcion = txtDescripcion.Text, Estado = chkActivo.Checked }, accesos);
                Consultar(); Limpiar();
                MessageBox.Show("Rol y accesos guardados.", "Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Roles", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (idRol == 0) { MessageBox.Show("Seleccione un rol."); return; }
            if (MessageBox.Show("¿Eliminar el rol seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { negocio.Eliminar(idRol); Consultar(); Limpiar(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Roles", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Limpiar()
        {
            idRol = 0; txtNombre.Clear(); txtDescripcion.Clear(); chkActivo.Checked = true;
            listaAccesos.Items.Clear();
            try { foreach (Acceso acceso in negocio.ConsultarAccesos(0)) listaAccesos.Items.Add(acceso, false); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Roles", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
