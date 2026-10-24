using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>
    /// Módulo Tipos de prenda: integrado desde el proyecto LavanderiasMultinegocio ("Prendas")
    /// y rehecho con la estructura de este proyecto (pestañas Consulta/Gestionar, paginación,
    /// búsqueda y selección con casillas). La Presentación solo usa la capa Negocio.
    /// </summary>
    public partial class TiposPrenda : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NTipoPrenda negocio = new NTipoPrenda();

        // PAGINACIÓN (solo en Presentación): se consulta la lista completa y aquí se divide en páginas de 10.
        private const int RegistrosPorPagina = 10;
        private List<TipoPrenda> lista = new List<TipoPrenda>();
        private int paginaActual = 1;

        // SELECCIÓN (chkSeleccionar): columna de casillas; el registro marcado se carga en "Gestionar".
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código del registro cargado (0 = ninguno)

        public TiposPrenda()
        {
            InitializeComponent();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void TiposPrenda_Load(object sender, EventArgs e)
        {
            ConfigurarTabla();
            Consultar();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewTiposPrenda.ReadOnly = true;
            dataGridViewTiposPrenda.AllowUserToAddRows = false;
            dataGridViewTiposPrenda.AllowUserToDeleteRows = false;
            dataGridViewTiposPrenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTiposPrenda.MultiSelect = false;
            dataGridViewTiposPrenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ===============================================================
        // CONSULTAR Y BUSCAR
        // ===============================================================

        /// <summary>CONSULTAR: pide todos los registros a Negocio y muestra la primera página.</summary>
        private void Consultar()
        {
            try
            {
                lista = negocio.Consultar();
            }
            catch (Exception ex)
            {
                lista = new List<TipoPrenda>();
                MessageBox.Show(ex.Message, "Error al consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();
        }

        /// <summary>BUSCAR: pide a Negocio los registros que coinciden con el texto escrito (búsqueda en la base).</summary>
        private void Buscar(bool avisarSiNoHay)
        {
            try
            {
                lista = negocio.Buscar(textBuscar_tiposprenda.Text);
            }
            catch (Exception ex)
            {
                lista = new List<TipoPrenda>();
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();

            if (avisarSiNoHay && lista.Count == 0)
            {
                MessageBox.Show("No se encontraron tipos de prenda con \"" + textBuscar_tiposprenda.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Después de guardar, editar o eliminar: repite la búsqueda escrita o consulta todo.</summary>
        private void RefrescarTabla()
        {
            if (textBuscar_tiposprenda.Text.Trim() != "")
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

        private void btnBuscar_tiposprenda_Click(object sender, EventArgs e)
        {
            Buscar(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void textBuscar_tiposprenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                Buscar(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todo.</summary>
        private void btnLimpiar_tiposprenda_Click(object sender, EventArgs e)
        {
            textBuscar_tiposprenda.Clear();
            Consultar();
        }

        // ===============================================================
        // PAGINACIÓN
        // ===============================================================

        /// <summary>Cantidad de páginas, redondeando hacia arriba (mínimo 1).</summary>
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

            List<TipoPrenda> pagina = new List<TipoPrenda>();
            if (cantidad > 0)
            {
                pagina = lista.GetRange(inicio, cantidad);
            }

            dataGridViewTiposPrenda.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados claros (por defecto muestran el nombre de la propiedad).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewTiposPrenda.Columns;
            if (!columnas.Contains("IdTipoPrenda"))
            {
                return;
            }
            columnas["IdTipoPrenda"].HeaderText = "Código";
            columnas["Nombre"].HeaderText = "Nombre";
            columnas["Descripcion"].HeaderText = "Descripción";
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
        // SELECCIÓN CON CASILLAS (chkSeleccionar)
        // ===============================================================

        /// <summary>Marcar "Seleccionar" agrega la columna de casillas; desmarcarlo la quita y limpia los campos.</summary>
        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                if (!dataGridViewTiposPrenda.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewTiposPrenda.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewTiposPrenda.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewTiposPrenda.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>Clic en la casilla de una fila: ese registro se carga en "Gestionar".</summary>
        private void dataGridViewTiposPrenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewTiposPrenda.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;
            }

            TipoPrenda registro = (TipoPrenda)dataGridViewTiposPrenda.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(registro);
            MarcarFilaSeleccionada();
            tab_tiposprenda.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        /// <summary>Deja marcada solo la casilla del registro seleccionado.</summary>
        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewTiposPrenda.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewTiposPrenda.Rows)
            {
                TipoPrenda registro = (TipoPrenda)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (registro.IdTipoPrenda == idSeleccionado);
            }
        }

        /// <summary>Editar y Eliminar necesitan un registro seleccionado con la casilla.</summary>
        private bool HaySeleccion()
        {
            if (chkSeleccionar.Checked && idSeleccionado > 0)
            {
                return true;
            }
            MessageBox.Show("Para editar o eliminar: en la pestaña Consulta marque 'Seleccionar' " +
                            "y luego la casilla del tipo de prenda.", "Tipos de prenda",
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
            textCodigo.Clear();
            textNombre.Clear();
            textDescripcion.Clear();
            radioActivo.Checked = true;
            MarcarFilaSeleccionada();
        }

        /// <summary>Crea un objeto con lo escrito en los campos.</summary>
        private TipoPrenda LeerCampos()
        {
            TipoPrenda registro = new TipoPrenda();
            registro.IdTipoPrenda = idSeleccionado;
            registro.Nombre = textNombre.Text;
            registro.Descripcion = textDescripcion.Text;
            registro.Estado = radioActivo.Checked;
            return registro;
        }

        /// <summary>Muestra en los campos los datos de un registro y lo deja seleccionado.</summary>
        private void MostrarEnCampos(TipoPrenda registro)
        {
            idSeleccionado = registro.IdTipoPrenda;
            textCodigo.Text = registro.IdTipoPrenda.ToString();
            textNombre.Text = registro.Nombre;
            textDescripcion.Text = registro.Descripcion;
            radioActivo.Checked = registro.Estado;
            radioInactivo.Checked = !registro.Estado;
        }

        /// <summary>Después de guardar, editar o eliminar: avisa, actualiza la tabla y limpia los campos.</summary>
        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Tipos de prenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        private void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Tipos de prenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        private void btnNuevo_tiposprenda_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            textNombre.Focus();
        }

        private void btnCancelar_tiposprenda_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: inserta un registro NUEVO.</summary>
        private void btnGuardar_tiposprenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay un tipo de prenda seleccionado. Use Editar para guardar sus cambios o Nuevo para registrar otro.");
                    return;
                }

                TipoPrenda registro = LeerCampos();
                string resultado = negocio.Insertar(registro);
                if (resultado == NTipoPrenda.Correcto)
                {
                    TerminarOperacion("Tipo de prenda guardado con el código " + registro.IdTipoPrenda + ".");
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

        /// <summary>Editar: guarda los cambios del registro seleccionado con la casilla.</summary>
        private void btnEditar_tiposprenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                string resultado = negocio.Actualizar(LeerCampos());
                if (resultado == NTipoPrenda.Correcto)
                {
                    TerminarOperacion("Tipo de prenda actualizado correctamente.");
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

        /// <summary>Eliminar: borra el registro seleccionado, después de confirmar.</summary>
        private void btnEliminar_tiposprenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar el tipo de prenda \"" + textNombre.Text + "\"?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocio.Eliminar(idSeleccionado);
                if (resultado == NTipoPrenda.Correcto)
                {
                    TerminarOperacion("Tipo de prenda eliminado correctamente.");
                }
                else
                {
                    Avisar(resultado);
                }
            }
            catch (Exception ex)
            {
                // Aquí llega, por ejemplo, el aviso de que tiene tarifas registradas.
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
