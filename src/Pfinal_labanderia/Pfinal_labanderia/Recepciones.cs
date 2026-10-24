using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    public partial class Recepciones : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NRecepcion negocioRecepciones = new NRecepcion();

        // ---------------------------------------------------------------
        // PAGINACIÓN (solo en la capa Presentación)
        // ---------------------------------------------------------------
        private const int RegistrosPorPagina = 10;
        private List<Recepcion> listaRecepciones = new List<Recepcion>();   // TODAS las recepciones consultadas
        private int paginaActual = 1;

        // Controles de paginación: se crean por código para no modificar Recepciones.Designer.cs.
        private IconButton btnPaginaAnterior;
        private IconButton btnPaginaSiguiente;
        private Label labelPagina;

        // ---------------------------------------------------------------
        // SELECCIÓN (chkSeleccionar): columna de casillas en la tabla.
        // Al marcar la casilla de una fila, esa recepción se carga en "Gestionar".
        // ---------------------------------------------------------------
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código de la recepción cargada (0 = ninguna)

        // Correspondencia entre los controles de "Gestionar" y las columnas de dbo.Tbl_Recepciones
        // (los TextBox conservan el nombre que traían del diseño original; la tabla se llama dataGridViewUsuarios):
        //   textCodigoCliente   -> IdRecepcion          (solo lectura)
        //   textServicio        -> IdCliente
        //   textBox1            -> IdSucursal
        //   textRecargoServicio -> FechaRecepcion       (dd/MM/aaaa HH:mm; vacía = ahora)
        //   textTotalServios    -> FechaEntregaEstimada (dd/MM/aaaa HH:mm)
        //   textDescripcion     -> Observaciones
        //   textBox2            -> Total
        //   radioActivo / radioInactivo: desactivados (el Estado de la recepción es automático)

        public Recepciones()
        {
            InitializeComponent();

            // Los eventos se conectan aquí (y no en el Designer.cs, que no se modifica).
            this.Load += FormularioRecepciones_Load;
            btnNuevo_recepcion.Click += BotonNuevo_Click;
            btnCancelar_recepcion.Click += BotonCancelar_Click;
            btnGuardar_recepcion.Click += BotonGuardar_Click;
            btnEditar_recepcion.Click += BotonEditar_Click;
            btnEliminar_recepcion.Click += BotonEliminar_Click;
            chkSeleccionar.CheckedChanged += Seleccionar_CheckedChanged;
            btnBuscar_recepcion.Click += BotonBuscar_Click;
            btnLimpiar_recepcion.Click += BotonLimpiarBusqueda_Click;
            textBuascar_recepcion.KeyDown += TextoBuscar_KeyDown;
            dataGridViewUsuarios.CellContentClick += Tabla_CellContentClick;
            CrearControlesPaginacion();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void FormularioRecepciones_Load(object sender, EventArgs e)
        {
            UbicarControlesPaginacion();
            ConfigurarTabla();
            ConfigurarCampos();
            ConsultarRecepciones();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.AllowUserToAddRows = false;      // Sin la fila vacía del final.
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.MultiSelect = false;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>Campos de solo lectura, largos máximos y estado automático.</summary>
        private void ConfigurarCampos()
        {
            textCodigoCliente.ReadOnly = true;
            textServicio.MaxLength = 9;
            textBox1.MaxLength = 9;
            textRecargoServicio.MaxLength = 16;
            textTotalServios.MaxLength = 16;
            textDescripcion.MaxLength = 500;
            textBox2.MaxLength = 14;
            textBuascar_recepcion.MaxLength = 100;

            // El Estado de una recepción ('Recibido', 'En proceso', ...) no es Activo/Inactivo:
            // una recepción nueva queda 'Recibido' y al editar se conserva. Por eso se desactivan.
            radioActivo.Enabled = false;
            radioInactivo.Enabled = false;
        }

        // ===============================================================
        // CONSULTAR
        // ===============================================================

        /// <summary>CONSULTAR: pide las recepciones a Negocio, muestra el total y la primera página.</summary>
        private void ConsultarRecepciones()
        {
            try
            {
                listaRecepciones = negocioRecepciones.Consultar();
            }
            catch (Exception ex)
            {
                listaRecepciones = new List<Recepcion>();
                MessageBox.Show(ex.Message, "Error al consultar recepciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();
        }

        /// <summary>Total de TODAS las recepciones; cambiar de página NO lo modifica.</summary>
        private void MostrarTotales()
        {
            labelRegistros.Text = "Registros: " + listaRecepciones.Count;
        }

        // ===============================================================
        // PAGINACIÓN
        // ===============================================================

        private int TotalPaginas()
        {
            int total = (listaRecepciones.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
            if (total < 1)
            {
                total = 1;
            }
            return total;
        }

        /// <summary>Muestra en la tabla solo los registros de la página actual.</summary>
        private void MostrarPagina()
        {
            int inicio = (paginaActual - 1) * RegistrosPorPagina;
            int cantidad = Math.Min(RegistrosPorPagina, listaRecepciones.Count - inicio);

            List<Recepcion> pagina = new List<Recepcion>();
            if (cantidad > 0)
            {
                pagina = listaRecepciones.GetRange(inicio, cantidad);
            }

            dataGridViewUsuarios.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados y formatos; los códigos de cliente y sucursal se ocultan (se ven sus nombres).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewUsuarios.Columns;
            if (!columnas.Contains("IdRecepcion"))
            {
                return;
            }

            columnas["IdRecepcion"].HeaderText = "Código";
            columnas["IdCliente"].Visible = false;
            columnas["NombreCliente"].HeaderText = "Cliente";
            columnas["IdSucursal"].Visible = false;
            columnas["NombreSucursal"].HeaderText = "Sucursal";
            columnas["FechaRecepcion"].HeaderText = "Recepción";
            columnas["FechaRecepcion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            columnas["FechaEntregaEstimada"].HeaderText = "Entrega estimada";
            columnas["FechaEntregaEstimada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            columnas["Total"].HeaderText = "Total";
            columnas["Total"].DefaultCellStyle.Format = "'Q' #,0.00";
            columnas["Estado"].HeaderText = "Estado";
            columnas["Observaciones"].HeaderText = "Observaciones";
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < TotalPaginas())
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        // ===============================================================
        // BUSCAR (caja "Nombre" de la pestaña de consulta)
        // ===============================================================

        /// <summary>
        /// BUSCAR: pide a Negocio las recepciones cuyo cliente o sucursal contienen el texto escrito.
        /// La búsqueda se hace en la base de datos. El resultado usa la misma paginación
        /// y la etiqueta de totales cuenta los registros encontrados.
        /// </summary>
        private void BuscarRecepciones(bool avisarSiNoHay)
        {
            try
            {
                listaRecepciones = negocioRecepciones.Buscar(textBuascar_recepcion.Text);
            }
            catch (Exception ex)
            {
                listaRecepciones = new List<Recepcion>();
                MessageBox.Show(ex.Message, "Error al buscar recepciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();

            if (avisarSiNoHay && listaRecepciones.Count == 0)
            {
                MessageBox.Show("No se encontraron recepciones con \"" + textBuascar_recepcion.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            BuscarRecepciones(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void TextoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                BuscarRecepciones(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todas las recepciones.</summary>
        private void BotonLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            textBuascar_recepcion.Clear();
            ConsultarRecepciones();
        }

        /// <summary>
        /// Después de guardar, editar o eliminar: si hay una búsqueda escrita se repite;
        /// si no, se vuelven a consultar todas las recepciones.
        /// </summary>
        private void RefrescarTabla()
        {
            if (textBuascar_recepcion.Text.Trim() != "")
            {
                BuscarRecepciones(false);
            }
            else
            {
                ConsultarRecepciones();
            }
        }

        // ===============================================================
        // SELECCIÓN CON CASILLAS (chkSeleccionar)
        // ===============================================================

        /// <summary>Marcar "Seleccionar" agrega la columna de casillas; desmarcarlo la quita y limpia los campos.</summary>
        private void Seleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                if (!dataGridViewUsuarios.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewUsuarios.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewUsuarios.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewUsuarios.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>Clic en la casilla de una fila: esa recepción se carga en "Gestionar".</summary>
        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;
            }

            Recepcion recepcion = (Recepcion)dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(recepcion);
            MarcarFilaSeleccionada();
            tabControl1.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        /// <summary>Deja marcada solo la casilla de la recepción seleccionada.</summary>
        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewUsuarios.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewUsuarios.Rows)
            {
                Recepcion recepcion = (Recepcion)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (recepcion.IdRecepcion == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan una recepción seleccionada con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña de consulta marque 'Seleccionar' " +
                            "y luego la casilla de la recepción.", "Recepciones",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // ===============================================================
        // CAMPOS DE "GESTIONAR"
        // ===============================================================

        /// <summary>Deja los campos en blanco y quita la selección.</summary>
        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            textCodigoCliente.Clear();
            textServicio.Clear();
            textBox1.Clear();
            textRecargoServicio.Clear();
            textTotalServios.Clear();
            textDescripcion.Clear();
            textBox2.Clear();
            MarcarFilaSeleccionada();
        }

        /// <summary>
        /// Convierte lo escrito en los campos a un objeto Recepcion.
        /// Si un número o una fecha están mal escritos, avisa, pone el cursor en ese campo y devuelve false.
        /// </summary>
        private bool LeerCampos(out Recepcion recepcion)
        {
            recepcion = new Recepcion();
            recepcion.IdRecepcion = idSeleccionado;

            int idCliente;
            if (!Formato.LeerEntero(textServicio.Text, out idCliente))
            {
                return Avisar("El ID del cliente debe ser un número entero.", textServicio);
            }
            recepcion.IdCliente = idCliente;

            int idSucursal;
            if (!Formato.LeerEntero(textBox1.Text, out idSucursal))
            {
                return Avisar("El ID de la sucursal debe ser un número entero.", textBox1);
            }
            recepcion.IdSucursal = idSucursal;

            DateTime? fechaRecepcion;
            if (!Formato.LeerFecha(textRecargoServicio.Text, out fechaRecepcion))
            {
                return Avisar("La fecha de recepción debe tener el formato dd/MM/aaaa HH:mm " +
                              "(o déjela vacía para usar la fecha actual).", textRecargoServicio);
            }
            recepcion.FechaRecepcion = fechaRecepcion;

            DateTime? fechaEntrega;
            if (!Formato.LeerFecha(textTotalServios.Text, out fechaEntrega))
            {
                return Avisar("La fecha de entrega estimada debe tener el formato dd/MM/aaaa HH:mm.", textTotalServios);
            }
            recepcion.FechaEntregaEstimada = fechaEntrega;

            // Total vacío = 0 (se calculará con el detalle en el documento 05).
            decimal total = 0;
            if (textBox2.Text.Trim() != "" && !Formato.LeerDecimal(textBox2.Text, out total))
            {
                return Avisar("El total debe ser un número (ejemplo: 35.50).", textBox2);
            }
            recepcion.Total = total;

            recepcion.Observaciones = textDescripcion.Text;
            return true;
        }

        /// <summary>Muestra en los campos los datos de una recepción y la deja seleccionada.</summary>
        private void MostrarEnCampos(Recepcion recepcion)
        {
            idSeleccionado = recepcion.IdRecepcion;
            textCodigoCliente.Text = recepcion.IdRecepcion.ToString();
            textServicio.Text = recepcion.IdCliente.ToString();
            textBox1.Text = recepcion.IdSucursal.ToString();
            textRecargoServicio.Text = Formato.MostrarFecha(recepcion.FechaRecepcion, true);
            textTotalServios.Text = Formato.MostrarFecha(recepcion.FechaEntregaEstimada, true);
            textDescripcion.Text = recepcion.Observaciones;
            textBox2.Text = Formato.MostrarDecimal(recepcion.Total);
        }

        /// <summary>Después de guardar, editar o eliminar: avisa, vuelve a consultar y limpia los campos.</summary>
        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Recepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        /// <summary>Muestra un aviso y pone el cursor en el campo indicado. Devuelve false para cortar la lectura.</summary>
        private bool Avisar(string mensaje, Control campo)
        {
            MessageBox.Show(mensaje, "Recepciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (campo != null)
            {
                campo.Focus();
            }
            return false;
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            textServicio.Focus();   // El cursor queda en "ID cliente".
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: inserta una recepción NUEVA (su estado inicial es 'Recibido').</summary>
        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay una recepción seleccionada. Use Editar para guardar sus cambios " +
                           "o Nuevo para registrar otra.", null);
                    return;
                }

                Recepcion recepcion;
                if (!LeerCampos(out recepcion))
                {
                    return;
                }

                string resultado = negocioRecepciones.Insertar(recepcion);
                if (resultado == NRecepcion.Correcto)
                {
                    TerminarOperacion("Recepción guardada con el código " + recepcion.IdRecepcion + ".");
                }
                else
                {
                    Avisar(resultado, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Editar: guarda los cambios de la recepción seleccionada con la casilla.</summary>
        private void BotonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                Recepcion recepcion;
                if (!LeerCampos(out recepcion))
                {
                    return;
                }

                string resultado = negocioRecepciones.Actualizar(recepcion);
                if (resultado == NRecepcion.Correcto)
                {
                    TerminarOperacion("Recepción actualizada correctamente.");
                }
                else
                {
                    Avisar(resultado, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Eliminar: borra la recepción seleccionada, después de confirmar.</summary>
        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar la recepción " + idSeleccionado + "?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocioRecepciones.Eliminar(idSeleccionado);
                if (resultado == NRecepcion.Correcto)
                {
                    TerminarOperacion("Recepción eliminada correctamente.");
                }
                else
                {
                    Avisar(resultado, null);
                }
            }
            catch (Exception ex)
            {
                // Aquí llega, por ejemplo, el aviso de que la recepción tiene detalle o entregas.
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        // CONTROLES DE PAGINACIÓN (creados por código)
        // ===============================================================

        private void CrearControlesPaginacion()
        {
            Font fuente = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            btnPaginaAnterior = CrearBotonPagina("btnPaginaAnterior", "Anterior", IconChar.AngleLeft,
                TextImageRelation.ImageBeforeText, new Point(565, 431), fuente);
            btnPaginaAnterior.Click += btnPaginaAnterior_Click;

            btnPaginaSiguiente = CrearBotonPagina("btnPaginaSiguiente", "Siguiente", IconChar.AngleRight,
                TextImageRelation.TextBeforeImage, new Point(837, 431), fuente);
            btnPaginaSiguiente.Click += btnPaginaSiguiente_Click;

            labelPagina = new Label();
            labelPagina.Name = "labelPagina";
            labelPagina.AutoSize = false;
            // Un punto más pequeña que los botones para que "Página 10 de 10" quepa en una sola línea.
            labelPagina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelPagina.TextAlign = ContentAlignment.MiddleCenter;
            labelPagina.ForeColor = Color.FromArgb(95, 108, 128);
            labelPagina.Location = new Point(697, 431);
            labelPagina.Size = new Size(138, 38);

            tabPage1.Controls.Add(btnPaginaAnterior);
            tabPage1.Controls.Add(labelPagina);
            tabPage1.Controls.Add(btnPaginaSiguiente);
        }

        /// <summary>
        /// Ubica los controles de paginación tomando como referencia controles del diseñador,
        /// que Windows ya ajustó a la escala de pantalla (100 %, 125 %, ...): misma fila y alto que
        /// el botón Exportar y alineados al borde derecho de la tabla. Así siempre quedan visibles.
        /// </summary>
        private void UbicarControlesPaginacion()
        {
            float escala = btnExportar.Width / 142f;   // 142 = ancho del botón Exportar en el diseño
            int anchoBoton = (int)(130 * escala);
            int anchoEtiqueta = (int)(138 * escala);
            int separacion = (int)(2 * escala);
            int y = btnExportar.Top;
            int alto = btnExportar.Height;

            btnPaginaSiguiente.SetBounds(dataGridViewUsuarios.Right - anchoBoton, y, anchoBoton, alto);
            labelPagina.SetBounds(btnPaginaSiguiente.Left - separacion - anchoEtiqueta, y, anchoEtiqueta, alto);
            btnPaginaAnterior.SetBounds(labelPagina.Left - separacion - anchoBoton, y, anchoBoton, alto);
        }

        private IconButton CrearBotonPagina(string nombre, string texto, IconChar icono,
            TextImageRelation relacion, Point ubicacion, Font fuente)
        {
            IconButton boton = new IconButton();
            boton.Name = nombre;
            boton.Text = texto;
            boton.IconChar = icono;
            // Estilo "secundario" del proyecto: fondo blanco, borde celeste, texto azul marino e icono azul.
            boton.IconColor = Color.FromArgb(13, 110, 253);
            boton.IconFont = IconFont.Auto;
            boton.IconSize = 18;
            boton.TextImageRelation = relacion;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderColor = Color.FromArgb(200, 214, 235);
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 240, 253);
            boton.BackColor = Color.White;
            boton.ForeColor = Color.FromArgb(16, 42, 110);
            boton.Font = fuente;
            boton.Cursor = Cursors.Hand;
            boton.UseVisualStyleBackColor = false;
            boton.Location = ubicacion;
            boton.Size = new Size(130, 38);
            return boton;
        }
    }
}
