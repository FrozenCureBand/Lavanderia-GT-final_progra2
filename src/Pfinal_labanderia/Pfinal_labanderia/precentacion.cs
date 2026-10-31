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
    public partial class precentacion : Form
    {
        // Guarda el formulario que se muestra en este momento dentro de panelPrincipal.
        // Sirve para cerrarlo antes de abrir otro y no acumular formularios en memoria.
        private Form formularioActivo = null;

        public precentacion()
        {
            InitializeComponent();
            SesionActual.MostrarEn(panelPrincipal);
            ConfigurarAccesos();

            // Al abrir el menú principal (después del login) se muestra la pantalla de Inicio.
            this.Load += MenuPrincipal_Load;

            // Módulos integrados del proyecto LavanderiasMultinegocio.
            // Se conectan aquí para no modificar precentacion.Designer.cs.
            iconButton3.Click += btnEntregas_Click;      // "Entregas"
            iconButton5.Click += btnProcesos_Click;      // "Procesos"
            iconButton9.Click += btnTiposPrenda_Click;   // "TiposPrenda"
            iconButton12.Click += btnServicios_Click;    // "Servicios"
            iconButton2.Click += btnDetalleRecepciones_Click; // "Detalle recepciones"
            iconButton11.Click += btnSucursales_Click;        // "Sucursales"
            Button botonRoles = new Button { Name = "btnRoles", Text = "Roles y accesos", ForeColor = Color.White, BackColor = Color.FromArgb(14, 33, 74), FlatStyle = FlatStyle.Flat, Size = new Size(215, 36), Location = new Point(9, 706) };
            panelBotones.AutoScroll = true;
            panelBotones.AutoScrollMinSize = new Size(225, 748);
            botonRoles.Click += (s, e) => AbrirFormularioEnPanel(new roles());
            panelBotones.Controls.Add(botonRoles);
            botonRoles.Visible = SesionActual.Accesos.Contains("roles");
        }

        private void ConfigurarAccesos()
        {
            string[,] mapa = { { "inicio", "bnt_inicio" }, { "clientes", "btn_clientes" }, { "recepciones", "bnt_recepcion" },
                { "tarifas", "btn_tarifas" }, { "usuarios", "bnt_usuarios" }, { "entregas", "iconButton3" },
                { "procesos", "iconButton5" }, { "tiposprenda", "iconButton9" }, { "servicios", "iconButton12" },
                { "detalleRecepciones", "iconButton2" }, { "estadosProceso", "iconButton4" }, { "sucursales", "iconButton11" } };
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                bool permitido = SesionActual.Accesos.Contains(mapa[i, 0]);
                foreach (Control control in Controls.Find(mapa[i, 1], true)) control.Visible = permitido;
            }
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (SesionActual.Accesos.Contains("inicio"))
            {
                AbrirFormularioEnPanel(new inicio());
                return;
            }

            // Si el rol no tiene Inicio, se abre la primera opción permitida para esa cuenta.
            string[] orden = { "clientes", "recepciones", "tarifas", "usuarios", "entregas", "procesos", "tiposprenda", "servicios", "detalleRecepciones", "estadosProceso", "sucursales", "roles" };
            foreach (string acceso in orden)
            {
                if (!SesionActual.Accesos.Contains(acceso)) continue;
                if (acceso == "clientes") AbrirFormularioEnPanel(new clientes());
                else if (acceso == "recepciones" || acceso == "detalleRecepciones") AbrirFormularioEnPanel(new Recepciones());
                else if (acceso == "tarifas") AbrirFormularioEnPanel(new Tarifas());
                else if (acceso == "usuarios") AbrirFormularioEnPanel(new usuarios());
                else if (acceso == "entregas") AbrirFormularioEnPanel(new Entregas());
                else if (acceso == "procesos" || acceso == "estadosProceso") AbrirFormularioEnPanel(new Procesos());
                else if (acceso == "tiposprenda") AbrirFormularioEnPanel(new TiposPrenda());
                else if (acceso == "servicios") AbrirFormularioEnPanel(new Servicios());
                else if (acceso == "sucursales") AbrirFormularioEnPanel(new inicio());
                else if (acceso == "roles") AbrirFormularioEnPanel(new roles());
                return;
            }
            MessageBox.Show("Su rol no tiene accesos configurados. Solicite ayuda a un administrador.", "Sin accesos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Muestra un formulario DENTRO de panelPrincipal, como si fuera un control más.
        /// Se puede reutilizar para todos los botones del menú.
        /// </summary>
        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            try
            {
                // Si ya está abierto este formulario, conserva la instancia actual.
                // Se libera la instancia recién creada y se evita mostrar una copia.
                if (formularioActivo != null && formularioActivo.GetType() == formularioHijo.GetType())
                {
                    formularioHijo.Dispose();
                    formularioActivo.BringToFront();
                    return;
                }

                // 1. El formulario que se mostraba antes desaparece del panel.
                CerrarFormularioActivo();
                formularioActivo = formularioHijo;

                // 2. TopLevel = false permite colocar un Form dentro de otro control.
                formularioHijo.TopLevel = false;

                // 3. Sin bordes ni barra de título, para que se vea integrado al panel.
                formularioHijo.FormBorderStyle = FormBorderStyle.None;

                // 4. Ocupa todo el espacio disponible del panel.
                formularioHijo.Dock = DockStyle.Fill;

                // 5. Se agrega al panel, se coloca al frente y se muestra.
                SesionActual.MostrarEn(formularioHijo);
                panelPrincipal.Controls.Add(formularioHijo);
                formularioHijo.BringToFront();
                formularioHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el formulario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Quita del panel el formulario que se estaba mostrando y lo libera de memoria.
        /// Así, al pulsar otro botón, el anterior desaparece antes de que aparezca el nuevo.
        /// </summary>
        private void CerrarFormularioActivo()
        {
            if (formularioActivo == null)
            {
                return; // Todavía no se ha abierto ningún formulario.
            }

            panelPrincipal.Controls.Remove(formularioActivo); // a) deja de verse en el panel
            formularioActivo.Close();                          // b) se cierra (FormClosing / FormClosed)
            formularioActivo.Dispose();                        // c) libera la memoria que usaba
            formularioActivo = null;
        }

        // ---------------------------------------------------------------
        // Botones del menú lateral.
        // Cada evento Click indica qué formulario existente se abre en panelPrincipal.
        // ---------------------------------------------------------------

        /// <summary>Botón "Inicio" (bnt_inicio): vuelve a mostrar la pantalla de Inicio con datos actualizados.</summary>
        private void bnt_inicio_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new inicio());
        }

        /// <summary>Botón "Clientes" (btn_clientes): abre el formulario clientes.</summary>
        private void btn_clientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new clientes());
        }

        /// <summary>Botón "Recepciones" (bnt_recepcion): abre el formulario Recepciones.</summary>
        private void bnt_recepcion_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Recepciones());
        }

        /// <summary>Botón "Tarifas" (btn_tarifas): abre el formulario Tarifas.</summary>
        private void btn_tarifas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Tarifas());
        }

        /// <summary>Botón "Usuarios" (bnt_usuarios): abre el formulario usuarios.</summary>
        private void bnt_usuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new usuarios());
        }

        /// <summary>Botón "Entregas" (iconButton3): abre el formulario Entregas.</summary>
        private void btnEntregas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Entregas());
        }

        /// <summary>Botón "Procesos" (iconButton5): abre el formulario Procesos.</summary>
        private void btnProcesos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Procesos());
        }

        /// <summary>Botón "TiposPrenda" (iconButton9): abre el formulario TiposPrenda.</summary>
        private void btnTiposPrenda_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new TiposPrenda());
        }

        /// <summary>Botón "Servicios" (iconButton12): abre el formulario Servicios.</summary>
        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Servicios());
        }

        /// <summary>Abre el listado existente de Recepciones para consultar sus registros.</summary>
        private void btnDetalleRecepciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Recepciones());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Procesos());
        }

        /// <summary>Abre Inicio, donde se muestran indicadores y una gráfica por sucursal.</summary>
        private void btnSucursales_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new inicio());
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
