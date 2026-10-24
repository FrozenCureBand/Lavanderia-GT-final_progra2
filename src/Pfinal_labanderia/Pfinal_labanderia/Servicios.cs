using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>
    /// Módulo Servicios: integrado desde el proyecto LavanderiasMultinegocio
    /// y rehecho con la estructura de este proyecto (pestañas Consulta/Gestionar, paginación,
    /// búsqueda y selección con casillas). La Presentación solo usa la capa Negocio.
    /// </summary>
    public partial class Servicios : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NServicio negocio = new NServicio();

        // PAGINACIÓN (solo en Presentación): se consulta la lista completa y aquí se divide en páginas de 10.
        private const int RegistrosPorPagina = 10;
        private List<Servicio> lista = new List<Servicio>();
        private int paginaActual = 1;

        // SELECCIÓN (chkSeleccionar): columna de casillas; el registro marcado se carga en "Gestionar".
        private const string ColumnaSeleccion = "colSeleccionar";
        private int idSeleccionado = 0;   // Código del registro cargado (0 = ninguno)

        public Servicios()
        {
            InitializeComponent();
        }

        // ===============================================================
        // CARGA DEL FORMULARIO
        // ===============================================================

        private void Servicios_Load(object sender, EventArgs e)
        {
            ConfigurarTabla();
            Consultar();
            LimpiarCampos();
        }

        /// <summary>La tabla solo muestra datos: el usuario no escribe en ella.</summary>
        private void ConfigurarTabla()
        {
            dataGridViewServicios.ReadOnly = true;
            dataGridViewServicios.AllowUserToAddRows = false;
            dataGridViewServicios.AllowUserToDeleteRows = false;
            dataGridViewServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServicios.MultiSelect = false;
            dataGridViewServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                lista = new List<Servicio>();
                MessageBox.Show(ex.Message, "Error al consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();
        }

        /// <summary>BUSCAR: pide a Negocio los registros que coinciden con el texto escrito (búsqueda en la base).</summary>
        private void Buscar(bool avisarSiNoHay)
        {
            try
            {
                lista = negocio.Buscar(textBuscar_servicios.Text);
            }
            catch (Exception ex)
            {
                lista = new List<Servicio>();
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarResultado();

            if (avisarSiNoHay && lista.Count == 0)
            {
                MessageBox.Show("No se encontraron servicios con \"" + textBuscar_servicios.Text.Trim() + "\".",
                    "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Después de guardar, editar o eliminar: repite la búsqueda escrita o consulta todo.</summary>
        private void RefrescarTabla()
        {
            if (textBuscar_servicios.Text.Trim() != "")
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

        private void btnBuscar_servicios_Click(object sender, EventArgs e)
        {
            Buscar(true);
        }

        /// <summary>Pulsar Enter dentro de la caja de búsqueda equivale a pulsar Buscar.</summary>
        private void textBuscar_servicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Evita el sonido de Windows al pulsar Enter.
                Buscar(true);
            }
        }

        /// <summary>Limpiar: borra el texto de búsqueda y vuelve a mostrar todo.</summary>
        private void btnLimpiar_servicios_Click(object sender, EventArgs e)
        {
            textBuscar_servicios.Clear();
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

            List<Servicio> pagina = new List<Servicio>();
            if (cantidad > 0)
            {
                pagina = lista.GetRange(inicio, cantidad);
            }

            dataGridViewServicios.DataSource = pagina;
            ConfigurarColumnas();
            MarcarFilaSeleccionada();

            labelPagina.Text = "Página " + paginaActual + " de " + TotalPaginas();
            btnPaginaAnterior.Enabled = paginaActual > 1;
            btnPaginaSiguiente.Enabled = paginaActual < TotalPaginas();
        }

        /// <summary>Encabezados claros (por defecto muestran el nombre de la propiedad).</summary>
        private void ConfigurarColumnas()
        {
            DataGridViewColumnCollection columnas = dataGridViewServicios.Columns;
            if (!columnas.Contains("IdServicio"))
            {
                return;
            }
            columnas["IdServicio"].HeaderText = "Código";
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
                if (!dataGridViewServicios.Columns.Contains(ColumnaSeleccion))
                {
                    DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                    columna.Name = ColumnaSeleccion;
                    columna.HeaderText = "Sel.";
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = 50;
                    dataGridViewServicios.Columns.Insert(0, columna);
                }
                MarcarFilaSeleccionada();
            }
            else
            {
                if (dataGridViewServicios.Columns.Contains(ColumnaSeleccion))
                {
                    dataGridViewServicios.Columns.Remove(ColumnaSeleccion);
                }
                LimpiarCampos();
            }
        }

        /// <summary>Clic en la casilla de una fila: ese registro se carga en "Gestionar".</summary>
        private void dataGridViewServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                return;
            }
            if (dataGridViewServicios.Columns[e.ColumnIndex].Name != ColumnaSeleccion)
            {
                return;
            }

            Servicio registro = (Servicio)dataGridViewServicios.Rows[e.RowIndex].DataBoundItem;
            MostrarEnCampos(registro);
            MarcarFilaSeleccionada();
            tab_servicios.SelectedTab = tabPage2;   // Pestaña "Gestionar".
        }

        /// <summary>Deja marcada solo la casilla del registro seleccionado.</summary>
        private void MarcarFilaSeleccionada()
        {
            if (!dataGridViewServicios.Columns.Contains(ColumnaSeleccion))
            {
                return;
            }
            foreach (DataGridViewRow fila in dataGridViewServicios.Rows)
            {
                Servicio registro = (Servicio)fila.DataBoundItem;
                fila.Cells[ColumnaSeleccion].Value = (registro.IdServicio == idSeleccionado);
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
                            "y luego la casilla del servicio.", "Servicios",
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
        private Servicio LeerCampos()
        {
            Servicio registro = new Servicio();
            registro.IdServicio = idSeleccionado;
            registro.Nombre = textNombre.Text;
            registro.Descripcion = textDescripcion.Text;
            registro.Estado = radioActivo.Checked;
            return registro;
        }

        /// <summary>Muestra en los campos los datos de un registro y lo deja seleccionado.</summary>
        private void MostrarEnCampos(Servicio registro)
        {
            idSeleccionado = registro.IdServicio;
            textCodigo.Text = registro.IdServicio.ToString();
            textNombre.Text = registro.Nombre;
            textDescripcion.Text = registro.Descripcion;
            radioActivo.Checked = registro.Estado;
            radioInactivo.Checked = !registro.Estado;
        }

        /// <summary>Después de guardar, editar o eliminar: avisa, actualiza la tabla y limpia los campos.</summary>
        private void TerminarOperacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarTabla();
            LimpiarCampos();
        }

        private void Avisar(string mensaje)
        {
            MessageBox.Show(mensaje, "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===============================================================
        // BOTONES DE "GESTIONAR"
        // ===============================================================

        private void btnNuevo_servicios_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            textNombre.Focus();
        }

        private void btnCancelar_servicios_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>Guardar: inserta un registro NUEVO.</summary>
        private void btnGuardar_servicios_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado > 0)
                {
                    Avisar("Hay un servicio seleccionado. Use Editar para guardar sus cambios o Nuevo para registrar otro.");
                    return;
                }

                Servicio registro = LeerCampos();
                string resultado = negocio.Insertar(registro);
                if (resultado == NServicio.Correcto)
                {
                    TerminarOperacion("Servicio guardado con el código " + registro.IdServicio + ".");
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
        private void btnEditar_servicios_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                string resultado = negocio.Actualizar(LeerCampos());
                if (resultado == NServicio.Correcto)
                {
                    TerminarOperacion("Servicio actualizado correctamente.");
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
        private void btnEliminar_servicios_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HaySeleccion())
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar el servicio \"" + textNombre.Text + "\"?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                string resultado = negocio.Eliminar(idSeleccionado);
                if (resultado == NServicio.Correcto)
                {
                    TerminarOperacion("Servicio eliminado correctamente.");
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
