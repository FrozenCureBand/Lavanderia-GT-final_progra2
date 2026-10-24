using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>
    /// Módulo Entregas: integrado desde el proyecto LavanderiasMultinegocio y rehecho con la estructura
    /// de este proyecto (pestañas Consulta/Gestionar, paginación, búsqueda y selección con casillas).
    /// La recepción se elige en una lista desplegable y la fecha en un calendario.
    /// </summary>
    public partial class Entregas : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NEntrega negocio = new NEntrega();
        private readonly NRecepcion negocioRecepciones = new NRecepcion();   // Para la lista de recepciones

        // PAGINACIÓN (solo en Presentación): se consulta la lista completa y aquí se divide en páginas de 10.
        private const int RegistrosPorPagina = 10;
        private List<Entrega> lista = new List<Entrega>();
        private int paginaActual = 1;

        // SELECCIÓN (chkSeleccionar): columna de casillas; el registro marcado se carga en "Gestionar".
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código de la entrega cargada (0 = ninguna)

        public Entregas()
        {
            InitializeComponent();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void Entregas_Load(object sender, EventArgs e)
        {
            ConfigurarTabla();
            CargarListas();
            Consultar();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewEntregas.ReadOnly = true;
            dataGridViewEntregas.AllowUserToAddRows = false;
            dataGridViewEntregas.AllowUserToDeleteRows = false;
            dataGridViewEntregas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEntregas.MultiSelect = false;
            dataGridViewEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Llena la lista desplegable de recepciones ("Recepción #1 - Carlos Méndez").
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar recepciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        // CONSULTAR Y BUSCAR
        // ===============================================================

        /// <summary>CONSULTAR: pide todas las entregas a Negocio y muestra la primera página.</summary>
        private void Consultar()
        {
            try
            {
                lista = negocio.Consultar();
            }
            catch (Exception ex)
            {
                lista = new List<Entrega>();
                MessageBox.Show(ex.Message, "Error al consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();
        }

        /// <summary>BUSCAR: entregas cuyo cliente o persona que recibe contienen el texto (búsqueda en la base).</summary>
        private void Buscar(bool avisarSiNoHay)
        {
            try
            {
                lista = negocio.Buscar(textBuscar_entregas.Text);
            }
            catch (Exception ex)
            {
                lista = new List<Entrega>();
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();

            if (avisarSiNoHay && lista.Count == 0)
            {
                MessageBox.Show("No se encontraron entregas con \"" + textBuscar_entregas.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Después de guardar, editar o eliminar: repite la búsqueda escrita o consulta todo.</summary>
        private void RefrescarTabla()
        {
            if (textBuscar_entregas.Text.Trim() != "")
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

        private void btnBuscar_entregas_Click(object sender, EventArgs e)
        {
            Buscar(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void textBuscar_entregas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                Buscar(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todo.</summary>
        private void btnLimpiar_entregas_Click(object sender, EventArgs e)
        {
            textBuscar_entregas.Clear();
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

            List<Entrega> pagina = new List<Entrega>();
            if (cantidad > 0)
            {
                pagina = lista.GetRange(inicio, cantidad);
            }

            dataGridViewEntregas.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados claros y formato de fecha.</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewEntregas.Columns;
            if (!columnas.Contains("IdEntrega"))
            {
                return;
            }
            columnas["IdEntrega"].HeaderText = "Código";
            columnas["IdRecepcion"].HeaderText = "Recepción";
            columnas["NombreCliente"].HeaderText = "Cliente";
            columnas["FechaEntrega"].HeaderText = "Fecha de entrega";
            columnas["FechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            columnas["NombreRecibe"].HeaderText = "Recibe";
            columnas["Observaciones"].HeaderText = "Observaciones";
            columnas["Estado"].HeaderText = "Estado";
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
                if (!dataGridViewEntregas.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewEntregas.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewEntregas.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewEntregas.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>Clic en la casilla de una fila: esa entrega se carga en "Gestionar".</summary>
        private void dataGridViewEntregas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewEntregas.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;
            }

            Entrega registro = (Entrega)dataGridViewEntregas.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(registro);
            MarcarFilaSeleccionada();
            tab_entregas.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewEntregas.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewEntregas.Rows)
            {
                Entrega registro = (Entrega)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (registro.IdEntrega == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan una entrega seleccionada con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña Consulta marque 'Seleccionar' " +
                            "y luego la casilla de la entrega.", "Entregas",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // ===============================================================
        // CAMPOS DE "GESTIONAR"
        // ===============================================================

        /// <summary>Deja los campos en blanco (fecha = ahora) y quita la selección.</summary>
        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            textCodigo.Clear();
            comboRecepcion.SelectedIndex = -1;
            dateFechaEntrega.Value = DateTime.Now;
            textNombreRecibe.Clear();
            textObservaciones.Clear();
            textEstado.Text = NEntrega.EstadoEntregado;   // Estado automático de una entrega nueva
            MarcarFilaSeleccionada();
        }

        /// <summary>Crea un objeto Entrega con lo elegido y escrito en los campos.</summary>
        private Entrega LeerCampos()
        {
            Entrega registro = new Entrega();
            registro.IdEntrega = idSeleccionado;

            // SelectedValue es el Id de la recepción elegida (null si no se eligió ninguna).
            registro.IdRecepcion = comboRecepcion.SelectedValue != null ? (int)comboRecepcion.SelectedValue : 0;
            registro.FechaEntrega = dateFechaEntrega.Value;
            registro.NombreRecibe = textNombreRecibe.Text;
            registro.Observaciones = textObservaciones.Text;
            return registro;
        }

        /// <summary>Muestra en los campos los datos de una entrega y la deja seleccionada.</summary>
        private void MostrarEnCampos(Entrega registro)
        {
            idSeleccionado = registro.IdEntrega;
            textCodigo.Text = registro.IdEntrega.ToString();
            comboRecepcion.SelectedValue = registro.IdRecepcion;
            dateFechaEntrega.Value = registro.FechaEntrega ?? DateTime.Now;
            textNombreRecibe.Text = registro.NombreRecibe;
            textObservaciones.Text = registro.Observaciones;
            textEstado.Text = registro.Estado;
        }

        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Entregas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        private void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Entregas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        private void btnNuevo_entregas_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            comboRecepcion.Focus();
        }

        private void btnCancelar_entregas_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: registra una entrega NUEVA (queda con estado 'Entregado').</summary>
        private void btnGuardar_entregas_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay una entrega seleccionada. Use Editar para guardar sus cambios o Nuevo para registrar otra.");
                    return;
                }

                Entrega registro = LeerCampos();
                string resultado = negocio.Insertar(registro);
                if (resultado == NEntrega.Correcto)
                {
                    TerminarOperacion("Entrega guardada con el código " + registro.IdEntrega + ".");
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

        /// <summary>Editar: guarda los cambios de la entrega seleccionada con la casilla.</summary>
        private void btnEditar_entregas_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                string resultado = negocio.Actualizar(LeerCampos());
                if (resultado == NEntrega.Correcto)
                {
                    TerminarOperacion("Entrega actualizada correctamente.");
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

        /// <summary>Eliminar: borra la entrega seleccionada, después de confirmar.</summary>
        private void btnEliminar_entregas_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar la entrega " + idSeleccionado + "?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocio.Eliminar(idSeleccionado);
                if (resultado == NEntrega.Correcto)
                {
                    TerminarOperacion("Entrega eliminada correctamente.");
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
