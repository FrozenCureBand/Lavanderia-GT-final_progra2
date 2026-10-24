using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>
    /// Módulo Procesos: integrado desde el proyecto LavanderiasMultinegocio y rehecho con la estructura
    /// de este proyecto (pestañas Consulta/Gestionar, paginación, búsqueda y selección con casillas).
    /// La recepción y el estado se eligen en listas desplegables; las fechas, en calendarios.
    /// </summary>
    public partial class Procesos : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NProceso negocio = new NProceso();
        private readonly NRecepcion negocioRecepciones = new NRecepcion();   // Para la lista de recepciones

        // PAGINACIÓN (solo en Presentación): se consulta la lista completa y aquí se divide en páginas de 10.
        private const int RegistrosPorPagina = 10;
        private List<Proceso> lista = new List<Proceso>();
        private int paginaActual = 1;

        // SELECCIÓN (chkSeleccionar): columna de casillas; el registro marcado se carga en "Gestionar".
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código del proceso cargado (0 = ninguno)

        public Procesos()
        {
            InitializeComponent();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void Procesos_Load(object sender, EventArgs e)
        {
            ConfigurarTabla();
            CargarListas();
            Consultar();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewProcesos.ReadOnly = true;
            dataGridViewProcesos.AllowUserToAddRows = false;
            dataGridViewProcesos.AllowUserToDeleteRows = false;
            dataGridViewProcesos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProcesos.MultiSelect = false;
            dataGridViewProcesos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Llena las listas desplegables de recepciones y de estados de proceso.
        /// DisplayMember = lo que se ve; ValueMember = el código que se guarda.
        /// </summary>
        private void CargarListas()
        {
            try
            {
                comboRecepcion.DisplayMember = "Texto";
                comboRecepcion.ValueMember = "Id";
                comboRecepcion.DataSource = negocioRecepciones.ListarOpciones();
                comboRecepcion.SelectedIndex = -1;

                comboEstado.DisplayMember = "Texto";
                comboEstado.ValueMember = "Id";
                comboEstado.DataSource = negocio.ListarEstados();
                comboEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar las listas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        // CONSULTAR Y BUSCAR
        // ===============================================================

        /// <summary>CONSULTAR: pide todos los procesos a Negocio y muestra la primera página.</summary>
        private void Consultar()
        {
            try
            {
                lista = negocio.Consultar();
            }
            catch (Exception ex)
            {
                lista = new List<Proceso>();
                MessageBox.Show(ex.Message, "Error al consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();
        }

        /// <summary>BUSCAR: procesos cuyo cliente o estado contienen el texto (búsqueda en la base).</summary>
        private void Buscar(bool avisarSiNoHay)
        {
            try
            {
                lista = negocio.Buscar(textBuscar_procesos.Text);
            }
            catch (Exception ex)
            {
                lista = new List<Proceso>();
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();

            if (avisarSiNoHay && lista.Count == 0)
            {
                MessageBox.Show("No se encontraron procesos con \"" + textBuscar_procesos.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Después de guardar, editar o eliminar: repite la búsqueda escrita o consulta todo.</summary>
        private void RefrescarTabla()
        {
            if (textBuscar_procesos.Text.Trim() != "")
            {
                Buscar(false);
            }
            else
            {
                Consultar();
            }
        }

        /// <summary>Total de registros (no cambia al pasar de página) y primera página.</summary>
        private void MostrarResultado()
        {
            labelRegistros.Text = "Registros: " + lista.Count;
            paginaActual = 1;
            MostrarPagina();
        }

        private void btnBuscar_procesos_Click(object sender, EventArgs e)
        {
            Buscar(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void textBuscar_procesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                Buscar(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todo.</summary>
        private void btnLimpiar_procesos_Click(object sender, EventArgs e)
        {
            textBuscar_procesos.Clear();
            Consultar();
        }

        // ===============================================================
        // PAGINACIÓN
        // ===============================================================

        private int TotalPaginas()
        {
            int total = (lista.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
            return total < 1 ? 1 : total;
        }

        /// <summary>Muestra en la tabla solo los registros de la página actual.</summary>
        private void MostrarPagina()
        {
            int inicio = (paginaActual - 1) * RegistrosPorPagina;
            int cantidad = Math.Min(RegistrosPorPagina, lista.Count - inicio);

            List<Proceso> pagina = new List<Proceso>();
            if (cantidad > 0)
            {
                pagina = lista.GetRange(inicio, cantidad);
            }

            dataGridViewProcesos.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados claros y formato de fechas; el código del estado se oculta (se ve su nombre).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewProcesos.Columns;
            if (!columnas.Contains("IdProceso"))
            {
                return;
            }
            columnas["IdProceso"].HeaderText = "Código";
            columnas["IdRecepcion"].HeaderText = "Recepción";
            columnas["NombreCliente"].HeaderText = "Cliente";
            columnas["IdEstadoProceso"].Visible = false;
            columnas["NombreEstado"].HeaderText = "Estado";
            columnas["FechaInicio"].HeaderText = "Inicio";
            columnas["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            columnas["FechaFin"].HeaderText = "Fin";
            columnas["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
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
        // SELECCIÓN CON CASILLAS (chkSeleccionar)
        // ===============================================================

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                if (!dataGridViewProcesos.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewProcesos.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewProcesos.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewProcesos.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>Clic en la casilla de una fila: ese proceso se carga en "Gestionar".</summary>
        private void dataGridViewProcesos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewProcesos.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;
            }

            Proceso registro = (Proceso)dataGridViewProcesos.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(registro);
            MarcarFilaSeleccionada();
            tab_procesos.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewProcesos.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewProcesos.Rows)
            {
                Proceso registro = (Proceso)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (registro.IdProceso == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan un proceso seleccionado con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña Consulta marque 'Seleccionar' " +
                            "y luego la casilla del proceso.", "Procesos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // ===============================================================
        // CAMPOS DE "GESTIONAR"
        // ===============================================================

        /// <summary>Deja los campos en blanco (inicio = ahora, sin fecha de fin) y quita la selección.</summary>
        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            textCodigo.Clear();
            comboRecepcion.SelectedIndex = -1;
            comboEstado.SelectedIndex = -1;
            dateFechaInicio.Value = DateTime.Now;
            dateFechaFin.Value = DateTime.Now;
            dateFechaFin.Checked = false;   // Sin marcar = el proceso todavía no termina (FechaFin NULL)
            textObservaciones.Clear();
            MarcarFilaSeleccionada();
        }

        /// <summary>Crea un objeto Proceso con lo elegido y escrito en los campos.</summary>
        private Proceso LeerCampos()
        {
            Proceso registro = new Proceso();
            registro.IdProceso = idSeleccionado;

            // SelectedValue es el Id elegido en cada lista (null si no se eligió nada).
            registro.IdRecepcion = comboRecepcion.SelectedValue != null ? (int)comboRecepcion.SelectedValue : 0;
            registro.IdEstadoProceso = comboEstado.SelectedValue != null ? (int)comboEstado.SelectedValue : 0;
            registro.FechaInicio = dateFechaInicio.Value;

            // La casilla del calendario indica si el proceso ya tiene fecha de fin.
            if (dateFechaFin.Checked)
            {
                registro.FechaFin = dateFechaFin.Value;
            }

            registro.Observaciones = textObservaciones.Text;
            return registro;
        }

        /// <summary>Muestra en los campos los datos de un proceso y lo deja seleccionado.</summary>
        private void MostrarEnCampos(Proceso registro)
        {
            idSeleccionado = registro.IdProceso;
            textCodigo.Text = registro.IdProceso.ToString();
            comboRecepcion.SelectedValue = registro.IdRecepcion;
            comboEstado.SelectedValue = registro.IdEstadoProceso;
            dateFechaInicio.Value = registro.FechaInicio ?? DateTime.Now;

            if (registro.FechaFin.HasValue)
            {
                dateFechaFin.Value = registro.FechaFin.Value;
                dateFechaFin.Checked = true;
            }
            else
            {
                dateFechaFin.Value = DateTime.Now;
                dateFechaFin.Checked = false;
            }

            textObservaciones.Text = registro.Observaciones;
        }

        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Procesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        private void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Procesos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        private void btnNuevo_procesos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            comboRecepcion.Focus();
        }

        private void btnCancelar_procesos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: registra un proceso NUEVO.</summary>
        private void btnGuardar_procesos_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay un proceso seleccionado. Use Editar para guardar sus cambios o Nuevo para registrar otro.");
                    return;
                }

                Proceso registro = LeerCampos();
                string resultado = negocio.Insertar(registro);
                if (resultado == NProceso.Correcto)
                {
                    TerminarOperacion("Proceso guardado con el código " + registro.IdProceso + ".");
                }
                else
                {
                    Avisar(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Editar: guarda los cambios del proceso seleccionado con la casilla.</summary>
        private void btnEditar_procesos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                string resultado = negocio.Actualizar(LeerCampos());
                if (resultado == NProceso.Correcto)
                {
                    TerminarOperacion("Proceso actualizado correctamente.");
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

        /// <summary>Eliminar: borra el proceso seleccionado, después de confirmar.</summary>
        private void btnEliminar_procesos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar el proceso " + idSeleccionado + "?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocio.Eliminar(idSeleccionado);
                if (resultado == NProceso.Correcto)
                {
                    TerminarOperacion("Proceso eliminado correctamente.");
                }
                else
                {
                    Avisar(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
