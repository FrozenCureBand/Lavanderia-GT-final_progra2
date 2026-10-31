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
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new inicio());
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
