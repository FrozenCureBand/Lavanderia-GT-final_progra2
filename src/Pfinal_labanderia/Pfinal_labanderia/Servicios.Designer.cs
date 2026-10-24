namespace Pfinal_labanderia
{
    partial class Servicios
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
            this.tab_servicios = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.textBuscar_servicios = new System.Windows.Forms.TextBox();
            this.btnBuscar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnImprimir_servicios = new FontAwesome.Sharp.IconButton();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.dataGridViewServicios = new System.Windows.Forms.DataGridView();
            this.btnExportar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnPaginaAnterior = new FontAwesome.Sharp.IconButton();
            this.labelPagina = new System.Windows.Forms.Label();
            this.btnPaginaSiguiente = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioActivo = new System.Windows.Forms.RadioButton();
            this.radioInactivo = new System.Windows.Forms.RadioButton();
            this.btnNuevo_servicios = new FontAwesome.Sharp.IconButton();
            this.btnCancelar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnGuardar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnEditar_servicios = new FontAwesome.Sharp.IconButton();
            this.btnEliminar_servicios = new FontAwesome.Sharp.IconButton();
            this.tab_servicios.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            //
            // labelTitulo
            //
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(428, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.labelTitulo.Size = new System.Drawing.Size(190, 35);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Servicios";
            //
            // tab_servicios
            //
            this.tab_servicios.Controls.Add(this.tabPage1);
            this.tab_servicios.Controls.Add(this.tabPage2);
            this.tab_servicios.Location = new System.Drawing.Point(12, 51);
            this.tab_servicios.Name = "tab_servicios";
            this.tab_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_servicios.SelectedIndex = 0;
            this.tab_servicios.Size = new System.Drawing.Size(1004, 524);
            this.tab_servicios.TabIndex = 1;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.labelBuscar);
            this.tabPage1.Controls.Add(this.textBuscar_servicios);
            this.tabPage1.Controls.Add(this.btnBuscar_servicios);
            this.tabPage1.Controls.Add(this.btnLimpiar_servicios);
            this.tabPage1.Controls.Add(this.btnImprimir_servicios);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.labelRegistros);
            this.tabPage1.Controls.Add(this.dataGridViewServicios);
            this.tabPage1.Controls.Add(this.btnExportar_servicios);
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
            // textBuscar_servicios
            //
            this.textBuscar_servicios.Location = new System.Drawing.Point(136, 76);
            this.textBuscar_servicios.MaxLength = 100;
            this.textBuscar_servicios.Name = "textBuscar_servicios";
            this.textBuscar_servicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBuscar_servicios.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar_servicios.Size = new System.Drawing.Size(328, 22);
            this.textBuscar_servicios.TabIndex = 1;
            this.textBuscar_servicios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBuscar_servicios_KeyDown);
            //
            // btnBuscar_servicios
            //
            this.btnBuscar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar_servicios.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar_servicios.Location = new System.Drawing.Point(498, 73);
            this.btnBuscar_servicios.Name = "btnBuscar_servicios";
            this.btnBuscar_servicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnBuscar_servicios.FlatAppearance.BorderSize = 0;
            this.btnBuscar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnBuscar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnBuscar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar_servicios.ForeColor = System.Drawing.Color.White;
            this.btnBuscar_servicios.IconColor = System.Drawing.Color.White;
            this.btnBuscar_servicios.IconSize = 18;
            this.btnBuscar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar_servicios.UseVisualStyleBackColor = false;
            this.btnBuscar_servicios.Size = new System.Drawing.Size(142, 34);
            this.btnBuscar_servicios.TabIndex = 2;
            this.btnBuscar_servicios.Text = "Buscar";
            this.btnBuscar_servicios.Click += new System.EventHandler(this.btnBuscar_servicios_Click);
            //
            // btnLimpiar_servicios
            //
            this.btnLimpiar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar_servicios.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar_servicios.Location = new System.Drawing.Point(660, 73);
            this.btnLimpiar_servicios.Name = "btnLimpiar_servicios";
            this.btnLimpiar_servicios.BackColor = System.Drawing.Color.White;
            this.btnLimpiar_servicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnLimpiar_servicios.FlatAppearance.BorderSize = 1;
            this.btnLimpiar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar_servicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnLimpiar_servicios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLimpiar_servicios.IconSize = 18;
            this.btnLimpiar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar_servicios.UseVisualStyleBackColor = false;
            this.btnLimpiar_servicios.Size = new System.Drawing.Size(142, 34);
            this.btnLimpiar_servicios.TabIndex = 3;
            this.btnLimpiar_servicios.Text = "Limpiar";
            this.btnLimpiar_servicios.Click += new System.EventHandler(this.btnLimpiar_servicios_Click);
            //
            // btnImprimir_servicios
            //
            this.btnImprimir_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir_servicios.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir_servicios.Location = new System.Drawing.Point(825, 73);
            this.btnImprimir_servicios.Name = "btnImprimir_servicios";
            this.btnImprimir_servicios.BackColor = System.Drawing.Color.White;
            this.btnImprimir_servicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnImprimir_servicios.FlatAppearance.BorderSize = 1;
            this.btnImprimir_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_servicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnImprimir_servicios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnImprimir_servicios.IconSize = 18;
            this.btnImprimir_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir_servicios.UseVisualStyleBackColor = false;
            this.btnImprimir_servicios.Size = new System.Drawing.Size(142, 34);
            this.btnImprimir_servicios.TabIndex = 4;
            this.btnImprimir_servicios.Text = "Imprimir";
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
            // dataGridViewServicios
            //
            this.dataGridViewServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServicios.Location = new System.Drawing.Point(52, 149);
            this.dataGridViewServicios.Name = "dataGridViewServicios";
            this.dataGridViewServicios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dataGridViewServicios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewServicios.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewServicios.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewServicios.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.dataGridViewServicios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dataGridViewServicios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewServicios.EnableHeadersVisualStyles = false;
            this.dataGridViewServicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.dataGridViewServicios.RowHeadersVisible = false;
            this.dataGridViewServicios.RowHeadersWidth = 51;
            this.dataGridViewServicios.RowTemplate.Height = 24;
            this.dataGridViewServicios.Size = new System.Drawing.Size(915, 262);
            this.dataGridViewServicios.TabIndex = 7;
            this.dataGridViewServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServicios_CellContentClick);
            //
            // btnExportar_servicios
            //
            this.btnExportar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar_servicios.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar_servicios.Location = new System.Drawing.Point(52, 431);
            this.btnExportar_servicios.Name = "btnExportar_servicios";
            this.btnExportar_servicios.BackColor = System.Drawing.Color.White;
            this.btnExportar_servicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnExportar_servicios.FlatAppearance.BorderSize = 1;
            this.btnExportar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar_servicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnExportar_servicios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnExportar_servicios.IconSize = 18;
            this.btnExportar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar_servicios.UseVisualStyleBackColor = false;
            this.btnExportar_servicios.Size = new System.Drawing.Size(142, 38);
            this.btnExportar_servicios.TabIndex = 8;
            this.btnExportar_servicios.Text = "Exportar";
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
            this.tabPage2.Controls.Add(this.textNombre);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textDescripcion);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.radioActivo);
            this.tabPage2.Controls.Add(this.radioInactivo);
            this.tabPage2.Controls.Add(this.btnNuevo_servicios);
            this.tabPage2.Controls.Add(this.btnCancelar_servicios);
            this.tabPage2.Controls.Add(this.btnGuardar_servicios);
            this.tabPage2.Controls.Add(this.btnEditar_servicios);
            this.tabPage2.Controls.Add(this.btnEliminar_servicios);
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
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            //
            // textNombre
            //
            this.textNombre.Location = new System.Drawing.Point(342, 169);
            this.textNombre.MaxLength = 100;
            this.textNombre.Name = "textNombre";
            this.textNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Size = new System.Drawing.Size(304, 22);
            this.textNombre.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 212);
            this.label3.Name = "label3";
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label3.Size = new System.Drawing.Size(154, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción";
            //
            // textDescripcion
            //
            this.textDescripcion.Location = new System.Drawing.Point(342, 213);
            this.textDescripcion.MaxLength = 250;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescripcion.Size = new System.Drawing.Size(304, 22);
            this.textDescripcion.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 256);
            this.label4.Name = "label4";
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado";
            //
            // radioActivo
            //
            this.radioActivo.AutoSize = true;
            this.radioActivo.Checked = true;
            this.radioActivo.Location = new System.Drawing.Point(345, 254);
            this.radioActivo.Name = "radioActivo";
            this.radioActivo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.radioActivo.Size = new System.Drawing.Size(103, 27);
            this.radioActivo.TabIndex = 7;
            this.radioActivo.TabStop = true;
            this.radioActivo.Text = "Activo";
            this.radioActivo.UseVisualStyleBackColor = true;
            //
            // radioInactivo
            //
            this.radioInactivo.AutoSize = true;
            this.radioInactivo.Location = new System.Drawing.Point(522, 254);
            this.radioInactivo.Name = "radioInactivo";
            this.radioInactivo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInactivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.radioInactivo.Size = new System.Drawing.Size(127, 27);
            this.radioInactivo.TabIndex = 8;
            this.radioInactivo.Text = "Inactivo";
            this.radioInactivo.UseVisualStyleBackColor = true;
            //
            // btnNuevo_servicios
            //
            this.btnNuevo_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo_servicios.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo_servicios.Location = new System.Drawing.Point(809, 157);
            this.btnNuevo_servicios.Name = "btnNuevo_servicios";
            this.btnNuevo_servicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnNuevo_servicios.FlatAppearance.BorderSize = 0;
            this.btnNuevo_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnNuevo_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnNuevo_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo_servicios.ForeColor = System.Drawing.Color.White;
            this.btnNuevo_servicios.IconColor = System.Drawing.Color.White;
            this.btnNuevo_servicios.IconSize = 18;
            this.btnNuevo_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo_servicios.UseVisualStyleBackColor = false;
            this.btnNuevo_servicios.Size = new System.Drawing.Size(142, 34);
            this.btnNuevo_servicios.TabIndex = 9;
            this.btnNuevo_servicios.Text = "Nuevo";
            this.btnNuevo_servicios.Click += new System.EventHandler(this.btnNuevo_servicios_Click);
            //
            // btnCancelar_servicios
            //
            this.btnCancelar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar_servicios.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar_servicios.Location = new System.Drawing.Point(809, 201);
            this.btnCancelar_servicios.Name = "btnCancelar_servicios";
            this.btnCancelar_servicios.BackColor = System.Drawing.Color.White;
            this.btnCancelar_servicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnCancelar_servicios.FlatAppearance.BorderSize = 1;
            this.btnCancelar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_servicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnCancelar_servicios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCancelar_servicios.IconSize = 18;
            this.btnCancelar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar_servicios.UseVisualStyleBackColor = false;
            this.btnCancelar_servicios.Size = new System.Drawing.Size(142, 34);
            this.btnCancelar_servicios.TabIndex = 10;
            this.btnCancelar_servicios.Text = "Cancelar";
            this.btnCancelar_servicios.Click += new System.EventHandler(this.btnCancelar_servicios_Click);
            //
            // btnGuardar_servicios
            //
            this.btnGuardar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar_servicios.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar_servicios.Location = new System.Drawing.Point(809, 238);
            this.btnGuardar_servicios.Name = "btnGuardar_servicios";
            this.btnGuardar_servicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnGuardar_servicios.FlatAppearance.BorderSize = 0;
            this.btnGuardar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnGuardar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnGuardar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_servicios.ForeColor = System.Drawing.Color.White;
            this.btnGuardar_servicios.IconColor = System.Drawing.Color.White;
            this.btnGuardar_servicios.IconSize = 18;
            this.btnGuardar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar_servicios.UseVisualStyleBackColor = false;
            this.btnGuardar_servicios.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar_servicios.TabIndex = 11;
            this.btnGuardar_servicios.Text = "Guardar";
            this.btnGuardar_servicios.Click += new System.EventHandler(this.btnGuardar_servicios_Click);
            //
            // btnEditar_servicios
            //
            this.btnEditar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar_servicios.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar_servicios.Location = new System.Drawing.Point(809, 285);
            this.btnEditar_servicios.Name = "btnEditar_servicios";
            this.btnEditar_servicios.BackColor = System.Drawing.Color.White;
            this.btnEditar_servicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnEditar_servicios.FlatAppearance.BorderSize = 1;
            this.btnEditar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_servicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnEditar_servicios.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnEditar_servicios.IconSize = 18;
            this.btnEditar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar_servicios.UseVisualStyleBackColor = false;
            this.btnEditar_servicios.Size = new System.Drawing.Size(142, 38);
            this.btnEditar_servicios.TabIndex = 12;
            this.btnEditar_servicios.Text = "Editar";
            this.btnEditar_servicios.Click += new System.EventHandler(this.btnEditar_servicios_Click);
            //
            // btnEliminar_servicios
            //
            this.btnEliminar_servicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_servicios.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnEliminar_servicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar_servicios.Location = new System.Drawing.Point(809, 334);
            this.btnEliminar_servicios.Name = "btnEliminar_servicios";
            this.btnEliminar_servicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar_servicios.FlatAppearance.BorderSize = 0;
            this.btnEliminar_servicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_servicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_servicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar_servicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_servicios.ForeColor = System.Drawing.Color.White;
            this.btnEliminar_servicios.IconColor = System.Drawing.Color.White;
            this.btnEliminar_servicios.IconSize = 18;
            this.btnEliminar_servicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar_servicios.UseVisualStyleBackColor = false;
            this.btnEliminar_servicios.Size = new System.Drawing.Size(142, 33);
            this.btnEliminar_servicios.TabIndex = 13;
            this.btnEliminar_servicios.Text = "Eliminar";
            this.btnEliminar_servicios.Click += new System.EventHandler(this.btnEliminar_servicios_Click);
            //
            // Servicios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1044, 616);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tab_servicios);
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            this.tab_servicios.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TabControl tab_servicios;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox textBuscar_servicios;
        private FontAwesome.Sharp.IconButton btnBuscar_servicios;
        private FontAwesome.Sharp.IconButton btnLimpiar_servicios;
        private FontAwesome.Sharp.IconButton btnImprimir_servicios;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.DataGridView dataGridViewServicios;
        private FontAwesome.Sharp.IconButton btnExportar_servicios;
        private FontAwesome.Sharp.IconButton btnPaginaAnterior;
        private System.Windows.Forms.Label labelPagina;
        private FontAwesome.Sharp.IconButton btnPaginaSiguiente;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioActivo;
        private System.Windows.Forms.RadioButton radioInactivo;
        private FontAwesome.Sharp.IconButton btnNuevo_servicios;
        private FontAwesome.Sharp.IconButton btnCancelar_servicios;
        private FontAwesome.Sharp.IconButton btnGuardar_servicios;
        private FontAwesome.Sharp.IconButton btnEditar_servicios;
        private FontAwesome.Sharp.IconButton btnEliminar_servicios;
    }
}
