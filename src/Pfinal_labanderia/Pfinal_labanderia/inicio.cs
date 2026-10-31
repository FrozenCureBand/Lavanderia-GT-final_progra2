using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;   // Chart, Series: gráficas de .NET Framework
using Entidad;
using Negocio;

namespace Pfinal_labanderia
{
    /// <summary>
    /// Pantalla de Inicio (dashboard): indicadores y gráficas de la lavandería.
    /// Solo CONSULTA datos: Presentación -> Negocio (NInicio) -> Datos (DInicio).
    /// </summary>
    public partial class inicio : Form
    {
        // Capa Negocio: la Presentación no usa la capa Datos ni SQL Server directamente.
        private readonly NInicio negocioInicio = new NInicio();

        // Colores para las porciones de la gráfica de dona (misma paleta del login).
        private readonly Color[] paleta =
        {
            Color.FromArgb(13, 110, 253),    // azul
            Color.FromArgb(111, 168, 255),   // celeste
            Color.FromArgb(230, 120, 20),    // naranja
            Color.FromArgb(25, 135, 84),     // verde
            Color.FromArgb(111, 66, 193),    // morado
            Color.FromArgb(220, 53, 69)      // rojo
        };

        public inicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al abrir la pantalla: muestra la fecha y la hora y consulta los datos.
        /// </summary>
        private void inicio_Load(object sender, EventArgs e)
        {
            MostrarFechaHora();
            timerReloj.Start();   // Actualiza la hora cada segundo.
            CargarDatos();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            MostrarFechaHora();
        }

        private void MostrarFechaHora()
        {
            DateTime ahora = DateTime.Now;
            lblFecha.Text = ahora.ToString("dd/MM/yyyy");
            lblHora.Text = ahora.ToString("HH:mm");
        }

        /// <summary>
        /// Pide a Negocio los indicadores y los datos de cada gráfica.
        /// Si algo falla (por ejemplo, SQL Server apagado) se avisa con un solo mensaje.
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                // ---- Tarjetas de indicadores ----
                // El primer indicador se consulta de forma independiente por la capa Negocio.
                lblValorClientes.Text = negocioInicio.ObtenerClientesActivos().ToString("N0");

                ResumenInicio resumen = negocioInicio.ObtenerResumen();
                lblValorSucursales.Text = resumen.SucursalesActivas.ToString("N0");
                lblValorRecepciones.Text = resumen.RecepcionesMes.ToString("N0");
                lblValorIngresos.Text = "Q " + resumen.IngresosMes.ToString("N2");
                lblValorEntregas.Text = resumen.EntregasMes.ToString("N0");

                // ---- Gráficas ----
                // Barras: se quita "Lavandería " del nombre para que quepa debajo de cada barra.
                LlenarSerie(chartSucursales, negocioInicio.IngresosPorSucursal(), "Lavandería ");

                List<DatoGrafica> meses = negocioInicio.RecepcionesUltimosMeses(6);
                LlenarSerie(chartMeses, meses, "");
                AjustarEjeEntero(chartMeses, meses);

                LlenarDona(negocioInicio.RecepcionesPorEstadoProceso());

                // Barras horizontales: el gráfico dibuja el primer punto abajo,
                // por eso se invierte la lista para que el servicio con más prendas quede arriba.
                List<DatoGrafica> servicios = negocioInicio.ServiciosMasSolicitados();
                servicios.Reverse();
                LlenarSerie(chartServicios, servicios, "");
                AjustarEjeEntero(chartServicios, servicios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el Inicio",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Pasa una lista de DatoGrafica a la serie de una gráfica.
        /// 'textoQuitar' se elimina de cada etiqueta para acortarla ("" = no se quita nada).
        /// </summary>
        private void LlenarSerie(Chart grafica, List<DatoGrafica> datos, string textoQuitar)
        {
            Series serie = grafica.Series[0];
            serie.Points.Clear();

            foreach (DatoGrafica dato in datos)
            {
                string etiqueta = dato.Etiqueta;
                if (textoQuitar != "")
                {
                    etiqueta = etiqueta.Replace(textoQuitar, "");
                }
                serie.Points.AddXY(etiqueta, dato.Valor);
            }
        }

        /// <summary>
        /// Gráfica de dona: solo se dibujan los estados que tienen recepciones,
        /// cada uno con un color de la paleta. El total se muestra en el título.
        /// </summary>
        private void LlenarDona(List<DatoGrafica> datos)
        {
            Series serie = chartEstados.Series[0];
            serie.Points.Clear();
            decimal total = 0;

            foreach (DatoGrafica dato in datos)
            {
                if (dato.Valor > 0)
                {
                    int indice = serie.Points.AddXY(dato.Etiqueta, dato.Valor);
                    serie.Points[indice].Color = paleta[indice % paleta.Length];
                    total += dato.Valor;
                }
            }

            lblTituloGraficaEstados.Text = "Estado de las recepciones (" + total.ToString("N0") + ")";
        }

        /// <summary>
        /// En gráficas de cantidades (recepciones, prendas) el eje debe avanzar de 1 en 1 o más,
        /// para que no aparezcan valores como 0.5.
        /// </summary>
        private void AjustarEjeEntero(Chart grafica, List<DatoGrafica> datos)
        {
            decimal maximo = 0;
            foreach (DatoGrafica dato in datos)
            {
                if (dato.Valor > maximo)
                {
                    maximo = dato.Valor;
                }
            }

            // Unas 5 divisiones como máximo; nunca menos de 1.
            double intervalo = Math.Max(1, Math.Ceiling((double)maximo / 5));
            grafica.ChartAreas[0].AxisY.Interval = intervalo;
        }
    }
}
