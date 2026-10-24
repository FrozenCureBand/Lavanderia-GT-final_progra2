namespace Pfinal_labanderia
{
    partial class Procesos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tab_procesos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.textBuscar_procesos = new System.Windows.Forms.TextBox();
            this.btnBuscar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnImprimir_procesos = new FontAwesome.Sharp.IconButton();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.dataGridViewProcesos = new System.Windows.Forms.DataGridView();
            this.btnExportar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnPaginaAnterior = new FontAwesome.Sharp.IconButton();
            this.labelPagina = new System.Windows.Forms.Label();
            this.btnPaginaSiguiente = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboRecepcion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textObservaciones = new System.Windows.Forms.TextBox();
            this.btnNuevo_procesos = new FontAwesome.Sharp.IconButton();
            this.btnCancelar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnGuardar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnEditar_procesos = new FontAwesome.Sharp.IconButton();
            this.btnEliminar_procesos = new FontAwesome.Sharp.IconButton();
            this.tab_procesos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            //
            // labelTitulo
            //
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(439, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.labelTitulo.Size = new System.Drawing.Size(166, 35);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Procesos";
            //
            // tab_procesos
            //
            this.tab_procesos.Controls.Add(this.tabPage1);
            this.tab_procesos.Controls.Add(this.tabPage2);
            this.tab_procesos.Location = new System.Drawing.Point(12, 51);
            this.tab_procesos.Name = "tab_procesos";
            this.tab_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_procesos.SelectedIndex = 0;
            this.tab_procesos.Size = new System.Drawing.Size(1004, 524);
            this.tab_procesos.TabIndex = 1;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.labelBuscar);
            this.tabPage1.Controls.Add(this.textBuscar_procesos);
            this.tabPage1.Controls.Add(this.btnBuscar_procesos);
            this.tabPage1.Controls.Add(this.btnLimpiar_procesos);
            this.tabPage1.Controls.Add(this.btnImprimir_procesos);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.labelRegistros);
            this.tabPage1.Controls.Add(this.dataGridViewProcesos);
            this.tabPage1.Controls.Add(this.btnExportar_procesos);
            this.tabPage1.Controls.Add(this.btnPaginaAnterior);
            this.tabPage1.Controls.Add(this.labelPagina);
            this.tabPage1.Controls.Add(this.btnPaginaSiguiente);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(996, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            //
            // labelBuscar
            //
            this.labelBuscar.AutoSize = true;
            this.labelBuscar.Location = new System.Drawing.Point(48, 73);
            this.labelBuscar.Name = "labelBuscar";
            this.labelBuscar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.labelBuscar.Size = new System.Drawing.Size(82, 23);
            this.labelBuscar.TabIndex = 0;
            this.labelBuscar.Text = "Nombre";
            //
            // textBuscar_procesos
            //
            this.textBuscar_procesos.Location = new System.Drawing.Point(136, 76);
            this.textBuscar_procesos.MaxLength = 100;
            this.textBuscar_procesos.Name = "textBuscar_procesos";
            this.textBuscar_procesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBuscar_procesos.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar_procesos.Size = new System.Drawing.Size(328, 22);
            this.textBuscar_procesos.TabIndex = 1;
            this.textBuscar_procesos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBuscar_procesos_KeyDown);
            //
            // btnBuscar_procesos
            //
            this.btnBuscar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar_procesos.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar_procesos.Location = new System.Drawing.Point(498, 73);
            this.btnBuscar_procesos.Name = "btnBuscar_procesos";
            this.btnBuscar_procesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnBuscar_procesos.FlatAppearance.BorderSize = 0;
            this.btnBuscar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnBuscar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnBuscar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar_procesos.ForeColor = System.Drawing.Color.White;
            this.btnBuscar_procesos.IconColor = System.Drawing.Color.White;
            this.btnBuscar_procesos.IconSize = 18;
            this.btnBuscar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar_procesos.UseVisualStyleBackColor = false;
            this.btnBuscar_procesos.Size = new System.Drawing.Size(142, 34);
            this.btnBuscar_procesos.TabIndex = 2;
            this.btnBuscar_procesos.Text = "Buscar";
            this.btnBuscar_procesos.Click += new System.EventHandler(this.btnBuscar_procesos_Click);
            //
            // btnLimpiar_procesos
            //
            this.btnLimpiar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar_procesos.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar_procesos.Location = new System.Drawing.Point(660, 73);
            this.btnLimpiar_procesos.Name = "btnLimpiar_procesos";
            this.btnLimpiar_procesos.BackColor = System.Drawing.Color.White;
            this.btnLimpiar_procesos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnLimpiar_procesos.FlatAppearance.BorderSize = 1;
            this.btnLimpiar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar_procesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnLimpiar_procesos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLimpiar_procesos.IconSize = 18;
            this.btnLimpiar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar_procesos.UseVisualStyleBackColor = false;
            this.btnLimpiar_procesos.Size = new System.Drawing.Size(142, 34);
            this.btnLimpiar_procesos.TabIndex = 3;
            this.btnLimpiar_procesos.Text = "Limpiar";
            this.btnLimpiar_procesos.Click += new System.EventHandler(this.btnLimpiar_procesos_Click);
            //
            // btnImprimir_procesos
            //
            this.btnImprimir_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir_procesos.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir_procesos.Location = new System.Drawing.Point(825, 73);
            this.btnImprimir_procesos.Name = "btnImprimir_procesos";
            this.btnImprimir_procesos.BackColor = System.Drawing.Color.White;
            this.btnImprimir_procesos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnImprimir_procesos.FlatAppearance.BorderSize = 1;
            this.btnImprimir_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_procesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnImprimir_procesos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnImprimir_procesos.IconSize = 18;
            this.btnImprimir_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir_procesos.UseVisualStyleBackColor = false;
            this.btnImprimir_procesos.Size = new System.Drawing.Size(142, 34);
            this.btnImprimir_procesos.TabIndex = 4;
            this.btnImprimir_procesos.Text = "Imprimir";
            //
            // chkSeleccionar
            //
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Location = new System.Drawing.Point(52, 123);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeleccionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.chkSeleccionar.Size = new System.Drawing.Size(101, 20);
            this.chkSeleccionar.TabIndex = 5;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            this.chkSeleccionar.CheckedChanged += new System.EventHandler(this.chkSeleccionar_CheckedChanged);
            //
            // labelRegistros
            //
            this.labelRegistros.AutoSize = true;
            this.labelRegistros.Location = new System.Drawing.Point(849, 123);
            this.labelRegistros.Name = "labelRegistros";
            this.labelRegistros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(108)))), ((int)(((byte)(128)))));
            this.labelRegistros.Size = new System.Drawing.Size(118, 23);
            this.labelRegistros.TabIndex = 6;
            this.labelRegistros.Text = "Registros";
            //
            // dataGridViewProcesos
            //
            this.dataGridViewProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesos.Location = new System.Drawing.Point(52, 149);
            this.dataGridViewProcesos.Name = "dataGridViewProcesos";
            this.dataGridViewProcesos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dataGridViewProcesos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProcesos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProcesos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewProcesos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewProcesos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProcesos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewProcesos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.dataGridViewProcesos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dataGridViewProcesos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewProcesos.EnableHeadersVisualStyles = false;
            this.dataGridViewProcesos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.dataGridViewProcesos.RowHeadersVisible = false;
            this.dataGridViewProcesos.RowHeadersWidth = 51;
            this.dataGridViewProcesos.RowTemplate.Height = 24;
            this.dataGridViewProcesos.Size = new System.Drawing.Size(915, 262);
            this.dataGridViewProcesos.TabIndex = 7;
            this.dataGridViewProcesos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProcesos_CellContentClick);
            //
            // btnExportar_procesos
            //
            this.btnExportar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar_procesos.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar_procesos.Location = new System.Drawing.Point(52, 431);
            this.btnExportar_procesos.Name = "btnExportar_procesos";
            this.btnExportar_procesos.BackColor = System.Drawing.Color.White;
            this.btnExportar_procesos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnExportar_procesos.FlatAppearance.BorderSize = 1;
            this.btnExportar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar_procesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnExportar_procesos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnExportar_procesos.IconSize = 18;
            this.btnExportar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar_procesos.UseVisualStyleBackColor = false;
            this.btnExportar_procesos.Size = new System.Drawing.Size(142, 38);
            this.btnExportar_procesos.TabIndex = 8;
            this.btnExportar_procesos.Text = "Exportar";
            //
            // btnPaginaAnterior
            //
            this.btnPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnterior.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnPaginaAnterior.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPaginaAnterior.Location = new System.Drawing.Point(565, 431);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.BackColor = System.Drawing.Color.White;
            this.btnPaginaAnterior.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnPaginaAnterior.FlatAppearance.BorderSize = 1;
            this.btnPaginaAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnPaginaAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnPaginaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnPaginaAnterior.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnPaginaAnterior.IconSize = 18;
            this.btnPaginaAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaginaAnterior.UseVisualStyleBackColor = false;
            this.btnPaginaAnterior.Size = new System.Drawing.Size(130, 38);
            this.btnPaginaAnterior.TabIndex = 9;
            this.btnPaginaAnterior.Text = "Anterior";
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            //
            // labelPagina
            //
            this.labelPagina.Location = new System.Drawing.Point(697, 431);
            this.labelPagina.Name = "labelPagina";
            this.labelPagina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(108)))), ((int)(((byte)(128)))));
            this.labelPagina.Size = new System.Drawing.Size(138, 38);
            this.labelPagina.TabIndex = 10;
            this.labelPagina.Text = "Página 1 de 1";
            this.labelPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnPaginaSiguiente
            //
            this.btnPaginaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSiguiente.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnPaginaSiguiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(837, 431);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.BackColor = System.Drawing.Color.White;
            this.btnPaginaSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnPaginaSiguiente.FlatAppearance.BorderSize = 1;
            this.btnPaginaSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnPaginaSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnPaginaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnPaginaSiguiente.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnPaginaSiguiente.IconSize = 18;
            this.btnPaginaSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaginaSiguiente.UseVisualStyleBackColor = false;
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(130, 38);
            this.btnPaginaSiguiente.TabIndex = 11;
            this.btnPaginaSiguiente.Text = "Siguiente";
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            //
            // tabPage2
            //
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textCodigo);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboRecepcion);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.comboEstado);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dateFechaInicio);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dateFechaFin);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textObservaciones);
            this.tabPage2.Controls.Add(this.btnNuevo_procesos);
            this.tabPage2.Controls.Add(this.btnCancelar_procesos);
            this.tabPage2.Controls.Add(this.btnGuardar_procesos);
            this.tabPage2.Controls.Add(this.btnEditar_procesos);
            this.tabPage2.Controls.Add(this.btnEliminar_procesos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(996, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestionar";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 124);
            this.label1.Name = "label1";
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            //
            // textCodigo
            //
            this.textCodigo.Location = new System.Drawing.Point(342, 125);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCodigo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCodigo.ReadOnly = true;
            this.textCodigo.Size = new System.Drawing.Size(304, 22);
            this.textCodigo.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 168);
            this.label2.Name = "label2";
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recepción";
            //
            // comboRecepcion
            //
            this.comboRecepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRecepcion.FormattingEnabled = true;
            this.comboRecepcion.Location = new System.Drawing.Point(342, 168);
            this.comboRecepcion.Name = "comboRecepcion";
            this.comboRecepcion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRecepcion.Size = new System.Drawing.Size(304, 24);
            this.comboRecepcion.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 212);
            this.label3.Name = "label3";
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            //
            // comboEstado
            //
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Location = new System.Drawing.Point(342, 212);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstado.Size = new System.Drawing.Size(304, 24);
            this.comboEstado.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 256);
            this.label4.Name = "label4";
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha de inicio";
            //
            // dateFechaInicio
            //
            this.dateFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFechaInicio.Location = new System.Drawing.Point(342, 256);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaInicio.Size = new System.Drawing.Size(304, 22);
            this.dateFechaInicio.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 300);
            this.label5.Name = "label5";
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label5.Size = new System.Drawing.Size(154, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de fin";
            //
            // dateFechaFin
            //
            this.dateFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFechaFin.Location = new System.Drawing.Point(342, 300);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaFin.ShowCheckBox = true;
            this.dateFechaFin.Size = new System.Drawing.Size(304, 22);
            this.dateFechaFin.TabIndex = 9;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 344);
            this.label6.Name = "label6";
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label6.Size = new System.Drawing.Size(166, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Observaciones";
            //
            // textObservaciones
            //
            this.textObservaciones.Location = new System.Drawing.Point(342, 345);
            this.textObservaciones.MaxLength = 500;
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textObservaciones.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textObservaciones.Size = new System.Drawing.Size(304, 22);
            this.textObservaciones.TabIndex = 11;
            //
            // btnNuevo_procesos
            //
            this.btnNuevo_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo_procesos.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo_procesos.Location = new System.Drawing.Point(809, 157);
            this.btnNuevo_procesos.Name = "btnNuevo_procesos";
            this.btnNuevo_procesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnNuevo_procesos.FlatAppearance.BorderSize = 0;
            this.btnNuevo_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnNuevo_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnNuevo_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo_procesos.ForeColor = System.Drawing.Color.White;
            this.btnNuevo_procesos.IconColor = System.Drawing.Color.White;
            this.btnNuevo_procesos.IconSize = 18;
            this.btnNuevo_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo_procesos.UseVisualStyleBackColor = false;
            this.btnNuevo_procesos.Size = new System.Drawing.Size(142, 34);
            this.btnNuevo_procesos.TabIndex = 12;
            this.btnNuevo_procesos.Text = "Nuevo";
            this.btnNuevo_procesos.Click += new System.EventHandler(this.btnNuevo_procesos_Click);
            //
            // btnCancelar_procesos
            //
            this.btnCancelar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar_procesos.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar_procesos.Location = new System.Drawing.Point(809, 201);
            this.btnCancelar_procesos.Name = "btnCancelar_procesos";
            this.btnCancelar_procesos.BackColor = System.Drawing.Color.White;
            this.btnCancelar_procesos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnCancelar_procesos.FlatAppearance.BorderSize = 1;
            this.btnCancelar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_procesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnCancelar_procesos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCancelar_procesos.IconSize = 18;
            this.btnCancelar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar_procesos.UseVisualStyleBackColor = false;
            this.btnCancelar_procesos.Size = new System.Drawing.Size(142, 34);
            this.btnCancelar_procesos.TabIndex = 13;
            this.btnCancelar_procesos.Text = "Cancelar";
            this.btnCancelar_procesos.Click += new System.EventHandler(this.btnCancelar_procesos_Click);
            //
            // btnGuardar_procesos
            //
            this.btnGuardar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar_procesos.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar_procesos.Location = new System.Drawing.Point(809, 238);
            this.btnGuardar_procesos.Name = "btnGuardar_procesos";
            this.btnGuardar_procesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnGuardar_procesos.FlatAppearance.BorderSize = 0;
            this.btnGuardar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnGuardar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnGuardar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_procesos.ForeColor = System.Drawing.Color.White;
            this.btnGuardar_procesos.IconColor = System.Drawing.Color.White;
            this.btnGuardar_procesos.IconSize = 18;
            this.btnGuardar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar_procesos.UseVisualStyleBackColor = false;
            this.btnGuardar_procesos.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar_procesos.TabIndex = 14;
            this.btnGuardar_procesos.Text = "Guardar";
            this.btnGuardar_procesos.Click += new System.EventHandler(this.btnGuardar_procesos_Click);
            //
            // btnEditar_procesos
            //
            this.btnEditar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar_procesos.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar_procesos.Location = new System.Drawing.Point(809, 285);
            this.btnEditar_procesos.Name = "btnEditar_procesos";
            this.btnEditar_procesos.BackColor = System.Drawing.Color.White;
            this.btnEditar_procesos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnEditar_procesos.FlatAppearance.BorderSize = 1;
            this.btnEditar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_procesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnEditar_procesos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnEditar_procesos.IconSize = 18;
            this.btnEditar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar_procesos.UseVisualStyleBackColor = false;
            this.btnEditar_procesos.Size = new System.Drawing.Size(142, 38);
            this.btnEditar_procesos.TabIndex = 15;
            this.btnEditar_procesos.Text = "Editar";
            this.btnEditar_procesos.Click += new System.EventHandler(this.btnEditar_procesos_Click);
            //
            // btnEliminar_procesos
            //
            this.btnEliminar_procesos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_procesos.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnEliminar_procesos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar_procesos.Location = new System.Drawing.Point(809, 334);
            this.btnEliminar_procesos.Name = "btnEliminar_procesos";
            this.btnEliminar_procesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar_procesos.FlatAppearance.BorderSize = 0;
            this.btnEliminar_procesos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_procesos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar_procesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_procesos.ForeColor = System.Drawing.Color.White;
            this.btnEliminar_procesos.IconColor = System.Drawing.Color.White;
            this.btnEliminar_procesos.IconSize = 18;
            this.btnEliminar_procesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar_procesos.UseVisualStyleBackColor = false;
            this.btnEliminar_procesos.Size = new System.Drawing.Size(142, 33);
            this.btnEliminar_procesos.TabIndex = 16;
            this.btnEliminar_procesos.Text = "Eliminar";
            this.btnEliminar_procesos.Click += new System.EventHandler(this.btnEliminar_procesos_Click);
            //
            // Procesos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1044, 616);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tab_procesos);
            this.Name = "Procesos";
            this.Text = "Procesos";
            this.Load += new System.EventHandler(this.Procesos_Load);
            this.tab_procesos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TabControl tab_procesos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox textBuscar_procesos;
        private FontAwesome.Sharp.IconButton btnBuscar_procesos;
        private FontAwesome.Sharp.IconButton btnLimpiar_procesos;
        private FontAwesome.Sharp.IconButton btnImprimir_procesos;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.DataGridView dataGridViewProcesos;
        private FontAwesome.Sharp.IconButton btnExportar_procesos;
        private FontAwesome.Sharp.IconButton btnPaginaAnterior;
        private System.Windows.Forms.Label labelPagina;
        private FontAwesome.Sharp.IconButton btnPaginaSiguiente;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboRecepcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textObservaciones;
        private FontAwesome.Sharp.IconButton btnNuevo_procesos;
        private FontAwesome.Sharp.IconButton btnCancelar_procesos;
        private FontAwesome.Sharp.IconButton btnGuardar_procesos;
        private FontAwesome.Sharp.IconButton btnEditar_procesos;
        private FontAwesome.Sharp.IconButton btnEliminar_procesos;
    }
}
