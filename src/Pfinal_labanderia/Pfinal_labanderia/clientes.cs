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
    public partial class clientes : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NCliente negocioClientes = new NCliente();

        // ---------------------------------------------------------------
        // PAGINACIÓN (solo en la capa Presentación)
        // Se consulta la lista completa UNA vez y aquí se divide en páginas de 10.
        // ---------------------------------------------------------------
        private const int RegistrosPorPagina = 10;
        private List<Cliente> listaClientes = new List<Cliente>();   // TODOS los clientes consultados
        private int paginaActual = 1;

        // Controles de paginación: se crean por código para no modificar clientes.Designer.cs.
        private IconButton btnPaginaAnterior;
        private IconButton btnPaginaSiguiente;
        private Label labelPagina;

        // ---------------------------------------------------------------
        // SELECCIÓN (chkSeleccionar)
        // Al marcar "Seleccionar" aparece una columna de casillas en la tabla.
        // Al marcar la casilla de una fila, ese cliente se carga en "Gestionar" para Editar o Eliminar.
        // ---------------------------------------------------------------
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código del cliente cargado en "Gestionar" (0 = ninguno)

        // Correspondencia entre los controles de "Gestionar" y las columnas de dbo.Tbl_Clientes
        // (algunos TextBox conservan el nombre que traían del diseño original):
        //   textCodigoCliente   -> IdCliente       (solo lectura)
        //   textServicio        -> NombreCompleto
        //   textBox1            -> Telefono
        //   textRecargoServicio -> Correo
        //   textTotalServios    -> Direccion
        //   textDescripcion     -> FechaRegistro   (solo lectura)
        //   radioActivo / radioInactivo -> Estado

        public clientes()
        {
            InitializeComponent();

            // Los eventos se conectan aquí (y no en el Designer.cs, que no se modifica).
            this.Load += FormularioClientes_Load;
            btnNuevo_clientes.Click += BotonNuevo_Click;
            btnCancelar_clientes.Click += BotonCancelar_Click;
            btnGuardar_clientes.Click += BotonGuardar_Click;
            btnEditar_clientes.Click += BotonEditar_Click;
            btnEliminar_clientes.Click += BotonEliminar_Click;
            chkSeleccionar.CheckedChanged += Seleccionar_CheckedChanged;
            btnBuscar_clientes.Click += BotonBuscar_Click;
            textBuascar__clientes.KeyDown += TextoBuscar_KeyDown;
            // btnLimpiar_clientes ya está conectado en el diseño a btnLimpiar_Click.
            dataGridViewclientes.CellContentClick += Tabla_CellContentClick;
            CrearControlesPaginacion();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void FormularioClientes_Load(object sender, EventArgs e)
        {
            UbicarControlesPaginacion();
            ConfigurarTabla();
            ConfigurarCampos();
            ConsultarClientes();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewclientes.ReadOnly = true;
            dataGridViewclientes.AllowUserToAddRows = false;      // Sin la fila vacía del final.
            dataGridViewclientes.AllowUserToDeleteRows = false;
            dataGridViewclientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewclientes.MultiSelect = false;
            dataGridViewclientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>Campos de solo lectura y largo máximo igual al de las columnas de la tabla.</summary>
        private void ConfigurarCampos()
        {
            textCodigoCliente.ReadOnly = true;
            textDescripcion.ReadOnly = true;
            textServicio.MaxLength = 150;
            textBox1.MaxLength = 20;
            textRecargoServicio.MaxLength = 100;
            textTotalServios.MaxLength = 250;
            textBuascar__clientes.MaxLength = 100;
        }

        // ===============================================================
        // CONSULTAR
        // ===============================================================

        /// <summary>CONSULTAR: pide los clientes a Negocio, muestra el total y la primera página.</summary>
        private void ConsultarClientes()
        {
            try
            {
                listaClientes = negocioClientes.Consultar();
            }
            catch (Exception ex)
            {
                listaClientes = new List<Cliente>();
                MessageBox.Show(ex.Message, "Error al consultar clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();
        }

        /// <summary>
        /// Etiqueta de totales: cuenta TODOS los clientes consultados.
        /// Solo se llama al consultar; cambiar de página NO la modifica.
        /// </summary>
        private void MostrarTotales()
        {
            labelRegistros.Text = "Registros: " + listaClientes.Count;
        }

        // ===============================================================
        // PAGINACIÓN
        // ===============================================================

        /// <summary>Cantidad de páginas, redondeando hacia arriba (mínimo 1).</summary>
        private int TotalPaginas()
        {
            int total = (listaClientes.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
            if (total < 1)
            {
                total = 1;
            }
            return total;
        }

        /// <summary>Muestra en la tabla solo los registros de la página actual.</summary>
        private void MostrarPagina()
        {
            // Posición del primer registro de la página (página 1 → 0, página 2 → 10, ...).
            int inicio = (paginaActual - 1) * RegistrosPorPagina;

            // La última página puede tener menos de 10 registros.
            int cantidad = Math.Min(RegistrosPorPagina, listaClientes.Count - inicio);

            List<Cliente> pagina = new List<Cliente>();
            if (cantidad > 0)
            {
                pagina = listaClientes.GetRange(inicio, cantidad);
            }

            // DataSource crea una columna por cada propiedad de la clase Cliente.
            dataGridViewclientes.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados claros (por defecto muestran el nombre de la propiedad).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewclientes.Columns;
            if (!columnas.Contains("IdCliente"))
            {
                return;
            }

            columnas["IdCliente"].HeaderText = "Código";
            columnas["NombreCompleto"].HeaderText = "Nombre completo";
            columnas["Telefono"].HeaderText = "Teléfono";
            columnas["Correo"].HeaderText = "Correo";
            columnas["Direccion"].HeaderText = "Dirección";
            columnas["FechaRegistro"].HeaderText = "Fecha de registro";
            columnas["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            columnas["Estado"].HeaderText = "Activo";
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
        // BUSCAR (caja "Nombre" de la pestaña Consulta)
        // ===============================================================

        /// <summary>
        /// BUSCAR: pide a Negocio los clientes cuyo nombre o teléfono contienen el texto escrito.
        /// La búsqueda se hace en la base de datos. El resultado usa la misma paginación
        /// y la etiqueta de totales cuenta los registros encontrados.
        /// </summary>
        private void BuscarClientes(bool avisarSiNoHay)
        {
            try
            {
                listaClientes = negocioClientes.Buscar(textBuascar__clientes.Text);
            }
            catch (Exception ex)
            {
                listaClientes = new List<Cliente>();
                MessageBox.Show(ex.Message, "Error al buscar clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarTotales();
            paginaActual = 1;
            MostrarPagina();

            if (avisarSiNoHay && listaClientes.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes con \"" + textBuascar__clientes.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void TextoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                BuscarClientes(true);
            }
        }

        /// <summary>
        /// Después de guardar, editar o eliminar: si hay una búsqueda escrita se repite;
        /// si no, se vuelven a consultar todos los clientes.
        /// </summary>
        private void RefrescarTabla()
        {
            if (textBuascar__clientes.Text.Trim() != "")
            {
                BuscarClientes(false);
            }
            else
            {
                ConsultarClientes();
            }
        }

        // ===============================================================
        // SELECCIÓN CON CASILLAS (chkSeleccionar)
        // ===============================================================

        /// <summary>
        /// Marcar "Seleccionar" agrega la columna de casillas al inicio de la tabla.
        /// Desmarcarlo la quita y deja los campos en blanco (ya no hay registro para editar).
        /// </summary>
        private void Seleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                if (!dataGridViewclientes.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewclientes.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewclientes.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewclientes.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>
        /// Clic en la casilla de una fila: ese cliente se carga en "Gestionar" y se cambia a esa pestaña.
        /// Solo se puede marcar un registro a la vez.
        /// </summary>
        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewclientes.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;   // Se hizo clic en otra columna.
            }

            // DataBoundItem es el objeto Cliente que se muestra en esa fila.
            Cliente cliente = (Cliente)dataGridViewclientes.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(cliente);
            MarcarFilaSeleccionada();
            tab_clientes.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        /// <summary>Deja marcada solo la casilla del cliente seleccionado (si la columna está visible).</summary>
        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewclientes.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewclientes.Rows)
            {
                Cliente cliente = (Cliente)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (cliente.IdCliente == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan un cliente seleccionado con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña Consulta marque 'Seleccionar' " +
                            "y luego la casilla del cliente.", "Clientes",
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
            radioActivo.Checked = true;   // Un cliente nuevo empieza como Activo.
            MarcarFilaSeleccionada();
        }

        /// <summary>Crea un objeto Cliente con lo escrito en los campos.</summary>
        private Cliente LeerCampos()
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = idSeleccionado;
            cliente.NombreCompleto = textServicio.Text;
            cliente.Telefono = textBox1.Text;
            cliente.Correo = textRecargoServicio.Text;
            cliente.Direccion = textTotalServios.Text;
            cliente.Estado = radioActivo.Checked;
            return cliente;
        }

        /// <summary>Muestra en los campos los datos de un cliente y lo deja seleccionado.</summary>
        private void MostrarEnCampos(Cliente cliente)
        {
            idSeleccionado = cliente.IdCliente;
            textCodigoCliente.Text = cliente.IdCliente.ToString();
            textServicio.Text = cliente.NombreCompleto;
            textBox1.Text = cliente.Telefono;
            textRecargoServicio.Text = cliente.Correo;
            textTotalServios.Text = cliente.Direccion;
            textDescripcion.Text = Formato.MostrarFecha(cliente.FechaRegistro, true);
            radioActivo.Checked = cliente.Estado;
            radioInactivo.Checked = !cliente.Estado;
        }

        /// <summary>Después de guardar, editar o eliminar: avisa, vuelve a consultar y limpia los campos.</summary>
        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        private void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        /// <summary>Nuevo: deja los campos listos para registrar un cliente.</summary>
        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            textServicio.Focus();   // El cursor queda en "Nombre Completo".
        }

        /// <summary>Cancelar: deja en blanco los campos.</summary>
        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: inserta un cliente NUEVO en la base de datos.</summary>
        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay un cliente seleccionado. Use Editar para guardar sus cambios " +
                           "o Nuevo para registrar otro cliente.");
                    return;
                }

                Cliente cliente = LeerCampos();
                string resultado = negocioClientes.Insertar(cliente);

                if (resultado == NCliente.Correcto)
                {
                    TerminarOperacion("Cliente guardado con el código " + cliente.IdCliente + ".");
                }
                else
                {
                    Avisar(resultado);   // Mensaje de validación de la capa Negocio.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Editar: guarda los cambios del cliente seleccionado con la casilla.</summary>
        private void BotonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                string resultado = negocioClientes.Actualizar(LeerCampos());

                if (resultado == NCliente.Correcto)
                {
                    TerminarOperacion("Cliente actualizado correctamente.");
                }
                else
                {
                    Avisar(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Eliminar: borra el cliente seleccionado, después de confirmar.</summary>
        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                // Se pide confirmación porque eliminar no se puede deshacer.
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar al cliente \"" + textServicio.Text + "\"?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocioClientes.Eliminar(idSeleccionado);

                if (resultado == NCliente.Correcto)
                {
                    TerminarOperacion("Cliente eliminado correctamente.");
                }
                else
                {
                    Avisar(resultado);
                }
            }
            catch (Exception ex)
            {
                // Aquí llega, por ejemplo, el aviso de que el cliente tiene recepciones registradas.
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        // CONTROLES DE PAGINACIÓN (creados por código)
        // ===============================================================

        /// <summary>
        /// Crea los botones "Anterior" y "Siguiente" y el indicador de página,
        /// debajo de la tabla (a la derecha), con la misma fuente y estilo de los demás botones.
        /// </summary>
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

            // Se agregan a la pestaña "Consulta", donde está la tabla.
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

            btnPaginaSiguiente.SetBounds(dataGridViewclientes.Right - anchoBoton, y, anchoBoton, alto);
            labelPagina.SetBounds(btnPaginaSiguiente.Left - separacion - anchoEtiqueta, y, anchoEtiqueta, alto);
            btnPaginaAnterior.SetBounds(labelPagina.Left - separacion - anchoBoton, y, anchoBoton, alto);
        }

        /// <summary>Crea un botón de paginación con el mismo estilo que los botones del formulario.</summary>
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

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todos los clientes.</summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBuascar__clientes.Clear();
            ConsultarClientes();
        }
    }
}
