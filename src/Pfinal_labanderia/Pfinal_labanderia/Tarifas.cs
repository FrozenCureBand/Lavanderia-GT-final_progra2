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
    public partial class Tarifas : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NTarifa negocioTarifas = new NTarifa();

        // ---------------------------------------------------------------
        // PAGINACIÓN (solo en la capa Presentación)
        // ---------------------------------------------------------------
        private const int RegistrosPorPagina = 10;
        private List<Tarifa> listaTarifas = new List<Tarifa>();   // TODAS las tarifas consultadas
        private int paginaActual = 1;

        // Controles de paginación: se crean por código para no modificar Tarifas.Designer.cs.
        private IconButton btnPaginaAnterior;
        private IconButton btnPaginaSiguiente;
        private Label labelPagina;

        // ---------------------------------------------------------------
        // SELECCIÓN (chkSeleccionar): columna de casillas en la tabla.
        // Al marcar la casilla de una fila, esa tarifa se carga en "Gestionar".
        // ---------------------------------------------------------------
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código de la tarifa cargada (0 = ninguna)

        // Correspondencia entre los controles de "Gestionar" y las columnas de dbo.Tbl_Tarifas
        // (los TextBox conservan el nombre que traían del diseño original; la tabla se llama dataGridViewUsuarios):
        //   textCodigoCliente   -> IdTarifa      (solo lectura)
        //   textServicio        -> IdTipoPrenda
        //   textBox1            -> IdServicio
        //   textRecargoServicio -> Precio
        //   textTotalServios    -> FechaInicio   (dd/MM/aaaa; vacía = hoy)
        //   radioActivo / radioInactivo -> Estado

        public Tarifas()
        {
            InitializeComponent();

            // Los eventos se conectan aquí (y no en el Designer.cs, que no se modifica).
            this.Load += FormularioTarifas_Load;
            btnNuevo_tarifa.Click += BotonNuevo_Click;
            btnCancelar_tarifa.Click += BotonCancelar_Click;
            btnGuardar_tarifa.Click += BotonGuardar_Click;
            btnEditar_tarifa.Click += BotonEditar_Click;
            btnEliminar_tarifa.Click += BotonEliminar_Click;
            chkSeleccionar.CheckedChanged += Seleccionar_CheckedChanged;
            btnBuscar_tarifa.Click += BotonBuscar_Click;
            btnLimpiar_tarifa.Click += BotonLimpiarBusqueda_Click;
            textBuascar_tarifa.KeyDown += TextoBuscar_KeyDown;
            dataGridViewUsuarios.CellContentClick += Tabla_CellContentClick;
            CrearControlesPaginacion();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void FormularioTarifas_Load(object sender, EventArgs e)
        {
            UbicarControlesPaginacion();
            ConfigurarTabla();
            ConfigurarCampos();
            ConsultarTarifas();
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

        /// <summary>Campos de solo lectura y largos máximos.</summary>
        private void ConfigurarCampos()
        {
            textCodigoCliente.ReadOnly = true;
            textServicio.MaxLength = 9;
            textBox1.MaxLength = 9;
            textRecargoServicio.MaxLength = 14;
            textTotalServios.MaxLength = 10;
            textBuascar_tarifa.MaxLength = 100;
        }

        // ===============================================================
        // CONSULTAR
        // ===============================================================

        /// <summary>CONSULTAR: pide las tarifas a Negocio, muestra el total y la primera página.</summary>
        private void ConsultarTarifas()
        {
            try
            {
                listaTarifas = negocioTarifas.Consultar();
            }
            catch (Exception ex)
            {
                listaTarifas = new List<Tarifa>();
                MessageBox.Show(ex.Message, "Error al consultar tarifas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();
        }

        /// <summary>Total de TODAS las tarifas; cambiar de página NO lo modifica.</summary>
        private void MostrarTotales()
        {
            labelRegistros.Text = "Registros: " + listaTarifas.Count;
        }

        // ===============================================================
        // PAGINACIÓN
        // ===============================================================

        private int TotalPaginas()
        {
            int total = (listaTarifas.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
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
            int cantidad = Math.Min(RegistrosPorPagina, listaTarifas.Count - inicio);

            List<Tarifa> pagina = new List<Tarifa>();
            if (cantidad > 0)
            {
                pagina = listaTarifas.GetRange(inicio, cantidad);
            }

            dataGridViewUsuarios.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados y formatos; los códigos de prenda y servicio se ocultan (se ven sus nombres).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewUsuarios.Columns;
            if (!columnas.Contains("IdTarifa"))
            {
                return;
            }

            columnas["IdTarifa"].HeaderText = "Código";
            columnas["IdTipoPrenda"].Visible = false;
            columnas["NombreTipoPrenda"].HeaderText = "Tipo de prenda";
            columnas["IdServicio"].Visible = false;
            columnas["NombreServicio"].HeaderText = "Servicio";
            columnas["Precio"].HeaderText = "Precio";
            columnas["Precio"].DefaultCellStyle.Format = "'Q' #,0.00";
            columnas["FechaInicio"].HeaderText = "Vigente desde";
            columnas["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            columnas["Estado"].HeaderText = "Activa";
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
        /// BUSCAR: pide a Negocio las tarifas cuyo tipo de prenda o servicio contienen el texto escrito.
        /// La búsqueda se hace en la base de datos. El resultado usa la misma paginación
        /// y la etiqueta de totales cuenta los registros encontrados.
        /// </summary>
        private void BuscarTarifas(bool avisarSiNoHay)
        {
            try
            {
                listaTarifas = negocioTarifas.Buscar(textBuascar_tarifa.Text);
            }
            catch (Exception ex)
            {
                listaTarifas = new List<Tarifa>();
                MessageBox.Show(ex.Message, "Error al buscar tarifas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();

            if (avisarSiNoHay && listaTarifas.Count == 0)
            {
                MessageBox.Show("No se encontraron tarifas con \"" + textBuascar_tarifa.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            BuscarTarifas(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void TextoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                BuscarTarifas(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todas las tarifas.</summary>
        private void BotonLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            textBuascar_tarifa.Clear();
            ConsultarTarifas();
        }

        /// <summary>
        /// Después de guardar, editar o eliminar: si hay una búsqueda escrita se repite;
        /// si no, se vuelven a consultar todas las tarifas.
        /// </summary>
        private void RefrescarTabla()
        {
            if (textBuascar_tarifa.Text.Trim() != "")
            {
                BuscarTarifas(false);
            }
            else
            {
                ConsultarTarifas();
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

        /// <summary>Clic en la casilla de una fila: esa tarifa se carga en "Gestionar".</summary>
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

            Tarifa tarifa = (Tarifa)dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(tarifa);
            MarcarFilaSeleccionada();
            tabControl1.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        /// <summary>Deja marcada solo la casilla de la tarifa seleccionada.</summary>
        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewUsuarios.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewUsuarios.Rows)
            {
                Tarifa tarifa = (Tarifa)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (tarifa.IdTarifa == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan una tarifa seleccionada con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña de consulta marque 'Seleccionar' " +
                            "y luego la casilla de la tarifa.", "Tarifas",
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
            radioActivo.Checked = true;   // Una tarifa nueva empieza Activa.
            MarcarFilaSeleccionada();
        }

        /// <summary>
        /// Convierte lo escrito en los campos a un objeto Tarifa.
        /// Si un número o la fecha están mal escritos, avisa y devuelve false.
        /// </summary>
        private bool LeerCampos(out Tarifa tarifa)
        {
            tarifa = new Tarifa();
            tarifa.IdTarifa = idSeleccionado;

            int idTipoPrenda;
            if (!Formato.LeerEntero(textServicio.Text, out idTipoPrenda))
            {
                return Avisar("El ID del tipo de prenda debe ser un número entero.", textServicio);
            }
            tarifa.IdTipoPrenda = idTipoPrenda;

            int idServicio;
            if (!Formato.LeerEntero(textBox1.Text, out idServicio))
            {
                return Avisar("El ID del servicio debe ser un número entero.", textBox1);
            }
            tarifa.IdServicio = idServicio;

            decimal precio;
            if (!Formato.LeerDecimal(textRecargoServicio.Text, out precio))
            {
                return Avisar("El precio debe ser un número (ejemplo: 15.00).", textRecargoServicio);
            }
            tarifa.Precio = precio;

            DateTime? fechaInicio;
            if (!Formato.LeerFecha(textTotalServios.Text, out fechaInicio))
            {
                return Avisar("La fecha de inicio debe tener el formato dd/MM/aaaa " +
                              "(o déjela vacía para usar la fecha de hoy).", textTotalServios);
            }
            tarifa.FechaInicio = fechaInicio;

            tarifa.Estado = radioActivo.Checked;
            return true;
        }

        /// <summary>Muestra en los campos los datos de una tarifa y la deja seleccionada.</summary>
        private void MostrarEnCampos(Tarifa tarifa)
        {
            idSeleccionado = tarifa.IdTarifa;
            textCodigoCliente.Text = tarifa.IdTarifa.ToString();
            textServicio.Text = tarifa.IdTipoPrenda.ToString();
            textBox1.Text = tarifa.IdServicio.ToString();
            textRecargoServicio.Text = Formato.MostrarDecimal(tarifa.Precio);
            textTotalServios.Text = Formato.MostrarFecha(tarifa.FechaInicio, false);
            radioActivo.Checked = tarifa.Estado;
            radioInactivo.Checked = !tarifa.Estado;
        }

        /// <summary>Después de guardar, editar o eliminar: avisa, vuelve a consultar y limpia los campos.</summary>
        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Tarifas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        /// <summary>Muestra un aviso y pone el cursor en el campo indicado. Devuelve false para cortar la lectura.</summary>
        private bool Avisar(string mensaje, Control campo)
        {
            MessageBox.Show(mensaje, "Tarifas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            textServicio.Focus();   // El cursor queda en "ID TipoPrenda".
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: inserta una tarifa NUEVA en la base de datos.</summary>
        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay una tarifa seleccionada. Use Editar para guardar sus cambios " +
                           "o Nuevo para registrar otra.", null);
                    return;
                }

                Tarifa tarifa;
                if (!LeerCampos(out tarifa))
                {
                    return;
                }

                string resultado = negocioTarifas.Insertar(tarifa);
                if (resultado == NTarifa.Correcto)
                {
                    TerminarOperacion("Tarifa guardada con el código " + tarifa.IdTarifa + ".");
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

        /// <summary>Editar: guarda los cambios de la tarifa seleccionada con la casilla.</summary>
        private void BotonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                Tarifa tarifa;
                if (!LeerCampos(out tarifa))
                {
                    return;
                }

                string resultado = negocioTarifas.Actualizar(tarifa);
                if (resultado == NTarifa.Correcto)
                {
                    TerminarOperacion("Tarifa actualizada correctamente.");
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

        /// <summary>Eliminar: borra la tarifa seleccionada, después de confirmar.</summary>
        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar la tarifa " + idSeleccionado + "?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocioTarifas.Eliminar(idSeleccionado);
                if (resultado == NTarifa.Correcto)
                {
                    TerminarOperacion("Tarifa eliminada correctamente.");
                }
                else
                {
                    Avisar(resultado, null);
                }
            }
            catch (Exception ex)
            {
                // Aquí llega, por ejemplo, el aviso de que la tarifa se usa en el detalle de recepciones.
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
            float escala = btnExportar_tarifa.Width / 142f;   // 142 = ancho del botón Exportar en el diseño
            int anchoBoton = (int)(130 * escala);
            int anchoEtiqueta = (int)(138 * escala);
            int separacion = (int)(2 * escala);
            int y = btnExportar_tarifa.Top;
            int alto = btnExportar_tarifa.Height;

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
