namespace Pfinal_labanderia
{
    partial class TiposPrenda
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
            this.tab_tiposprenda = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.textBuscar_tiposprenda = new System.Windows.Forms.TextBox();
            this.btnBuscar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnImprimir_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.dataGridViewTiposPrenda = new System.Windows.Forms.DataGridView();
            this.btnExportar_tiposprenda = new FontAwesome.Sharp.IconButton();
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
            this.btnNuevo_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnCancelar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnGuardar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnEditar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.btnEliminar_tiposprenda = new FontAwesome.Sharp.IconButton();
            this.tab_tiposprenda.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTiposPrenda)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            //
            // labelTitulo
            //
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(360, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.labelTitulo.Size = new System.Drawing.Size(330, 35);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Tipos de prenda";
            //
            // tab_tiposprenda
            //
            this.tab_tiposprenda.Controls.Add(this.tabPage1);
            this.tab_tiposprenda.Controls.Add(this.tabPage2);
            this.tab_tiposprenda.Location = new System.Drawing.Point(12, 51);
            this.tab_tiposprenda.Name = "tab_tiposprenda";
            this.tab_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_tiposprenda.SelectedIndex = 0;
            this.tab_tiposprenda.Size = new System.Drawing.Size(1004, 524);
            this.tab_tiposprenda.TabIndex = 1;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.labelBuscar);
            this.tabPage1.Controls.Add(this.textBuscar_tiposprenda);
            this.tabPage1.Controls.Add(this.btnBuscar_tiposprenda);
            this.tabPage1.Controls.Add(this.btnLimpiar_tiposprenda);
            this.tabPage1.Controls.Add(this.btnImprimir_tiposprenda);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.labelRegistros);
            this.tabPage1.Controls.Add(this.dataGridViewTiposPrenda);
            this.tabPage1.Controls.Add(this.btnExportar_tiposprenda);
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
            // textBuscar_tiposprenda
            //
            this.textBuscar_tiposprenda.Location = new System.Drawing.Point(136, 76);
            this.textBuscar_tiposprenda.MaxLength = 100;
            this.textBuscar_tiposprenda.Name = "textBuscar_tiposprenda";
            this.textBuscar_tiposprenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBuscar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar_tiposprenda.Size = new System.Drawing.Size(328, 22);
            this.textBuscar_tiposprenda.TabIndex = 1;
            this.textBuscar_tiposprenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBuscar_tiposprenda_KeyDown);
            //
            // btnBuscar_tiposprenda
            //
            this.btnBuscar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar_tiposprenda.Location = new System.Drawing.Point(498, 73);
            this.btnBuscar_tiposprenda.Name = "btnBuscar_tiposprenda";
            this.btnBuscar_tiposprenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnBuscar_tiposprenda.FlatAppearance.BorderSize = 0;
            this.btnBuscar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnBuscar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnBuscar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar_tiposprenda.ForeColor = System.Drawing.Color.White;
            this.btnBuscar_tiposprenda.IconColor = System.Drawing.Color.White;
            this.btnBuscar_tiposprenda.IconSize = 18;
            this.btnBuscar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnBuscar_tiposprenda.Size = new System.Drawing.Size(142, 34);
            this.btnBuscar_tiposprenda.TabIndex = 2;
            this.btnBuscar_tiposprenda.Text = "Buscar";
            this.btnBuscar_tiposprenda.Click += new System.EventHandler(this.btnBuscar_tiposprenda_Click);
            //
            // btnLimpiar_tiposprenda
            //
            this.btnLimpiar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar_tiposprenda.Location = new System.Drawing.Point(660, 73);
            this.btnLimpiar_tiposprenda.Name = "btnLimpiar_tiposprenda";
            this.btnLimpiar_tiposprenda.BackColor = System.Drawing.Color.White;
            this.btnLimpiar_tiposprenda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnLimpiar_tiposprenda.FlatAppearance.BorderSize = 1;
            this.btnLimpiar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar_tiposprenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnLimpiar_tiposprenda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLimpiar_tiposprenda.IconSize = 18;
            this.btnLimpiar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnLimpiar_tiposprenda.Size = new System.Drawing.Size(142, 34);
            this.btnLimpiar_tiposprenda.TabIndex = 3;
            this.btnLimpiar_tiposprenda.Text = "Limpiar";
            this.btnLimpiar_tiposprenda.Click += new System.EventHandler(this.btnLimpiar_tiposprenda_Click);
            //
            // btnImprimir_tiposprenda
            //
            this.btnImprimir_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir_tiposprenda.Location = new System.Drawing.Point(825, 73);
            this.btnImprimir_tiposprenda.Name = "btnImprimir_tiposprenda";
            this.btnImprimir_tiposprenda.BackColor = System.Drawing.Color.White;
            this.btnImprimir_tiposprenda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnImprimir_tiposprenda.FlatAppearance.BorderSize = 1;
            this.btnImprimir_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_tiposprenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnImprimir_tiposprenda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnImprimir_tiposprenda.IconSize = 18;
            this.btnImprimir_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir_tiposprenda.UseVisualStyleBackColor = false;
            this.btnImprimir_tiposprenda.Size = new System.Drawing.Size(142, 34);
            this.btnImprimir_tiposprenda.TabIndex = 4;
            this.btnImprimir_tiposprenda.Text = "Imprimir";
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
            // dataGridViewTiposPrenda
            //
            this.dataGridViewTiposPrenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTiposPrenda.Location = new System.Drawing.Point(52, 149);
            this.dataGridViewTiposPrenda.Name = "dataGridViewTiposPrenda";
            this.dataGridViewTiposPrenda.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dataGridViewTiposPrenda.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTiposPrenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTiposPrenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewTiposPrenda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewTiposPrenda.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTiposPrenda.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTiposPrenda.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.dataGridViewTiposPrenda.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dataGridViewTiposPrenda.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewTiposPrenda.EnableHeadersVisualStyles = false;
            this.dataGridViewTiposPrenda.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.dataGridViewTiposPrenda.RowHeadersVisible = false;
            this.dataGridViewTiposPrenda.RowHeadersWidth = 51;
            this.dataGridViewTiposPrenda.RowTemplate.Height = 24;
            this.dataGridViewTiposPrenda.Size = new System.Drawing.Size(915, 262);
            this.dataGridViewTiposPrenda.TabIndex = 7;
            this.dataGridViewTiposPrenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTiposPrenda_CellContentClick);
            //
            // btnExportar_tiposprenda
            //
            this.btnExportar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar_tiposprenda.Location = new System.Drawing.Point(52, 431);
            this.btnExportar_tiposprenda.Name = "btnExportar_tiposprenda";
            this.btnExportar_tiposprenda.BackColor = System.Drawing.Color.White;
            this.btnExportar_tiposprenda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnExportar_tiposprenda.FlatAppearance.BorderSize = 1;
            this.btnExportar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar_tiposprenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnExportar_tiposprenda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnExportar_tiposprenda.IconSize = 18;
            this.btnExportar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnExportar_tiposprenda.Size = new System.Drawing.Size(142, 38);
            this.btnExportar_tiposprenda.TabIndex = 8;
            this.btnExportar_tiposprenda.Text = "Exportar";
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
            this.tabPage2.Controls.Add(this.btnNuevo_tiposprenda);
            this.tabPage2.Controls.Add(this.btnCancelar_tiposprenda);
            this.tabPage2.Controls.Add(this.btnGuardar_tiposprenda);
            this.tabPage2.Controls.Add(this.btnEditar_tiposprenda);
            this.tabPage2.Controls.Add(this.btnEliminar_tiposprenda);
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
            // btnNuevo_tiposprenda
            //
            this.btnNuevo_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo_tiposprenda.Location = new System.Drawing.Point(809, 157);
            this.btnNuevo_tiposprenda.Name = "btnNuevo_tiposprenda";
            this.btnNuevo_tiposprenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnNuevo_tiposprenda.FlatAppearance.BorderSize = 0;
            this.btnNuevo_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnNuevo_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnNuevo_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo_tiposprenda.ForeColor = System.Drawing.Color.White;
            this.btnNuevo_tiposprenda.IconColor = System.Drawing.Color.White;
            this.btnNuevo_tiposprenda.IconSize = 18;
            this.btnNuevo_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo_tiposprenda.UseVisualStyleBackColor = false;
            this.btnNuevo_tiposprenda.Size = new System.Drawing.Size(142, 34);
            this.btnNuevo_tiposprenda.TabIndex = 9;
            this.btnNuevo_tiposprenda.Text = "Nuevo";
            this.btnNuevo_tiposprenda.Click += new System.EventHandler(this.btnNuevo_tiposprenda_Click);
            //
            // btnCancelar_tiposprenda
            //
            this.btnCancelar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar_tiposprenda.Location = new System.Drawing.Point(809, 201);
            this.btnCancelar_tiposprenda.Name = "btnCancelar_tiposprenda";
            this.btnCancelar_tiposprenda.BackColor = System.Drawing.Color.White;
            this.btnCancelar_tiposprenda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnCancelar_tiposprenda.FlatAppearance.BorderSize = 1;
            this.btnCancelar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_tiposprenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnCancelar_tiposprenda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCancelar_tiposprenda.IconSize = 18;
            this.btnCancelar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnCancelar_tiposprenda.Size = new System.Drawing.Size(142, 34);
            this.btnCancelar_tiposprenda.TabIndex = 10;
            this.btnCancelar_tiposprenda.Text = "Cancelar";
            this.btnCancelar_tiposprenda.Click += new System.EventHandler(this.btnCancelar_tiposprenda_Click);
            //
            // btnGuardar_tiposprenda
            //
            this.btnGuardar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar_tiposprenda.Location = new System.Drawing.Point(809, 238);
            this.btnGuardar_tiposprenda.Name = "btnGuardar_tiposprenda";
            this.btnGuardar_tiposprenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnGuardar_tiposprenda.FlatAppearance.BorderSize = 0;
            this.btnGuardar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnGuardar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnGuardar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_tiposprenda.ForeColor = System.Drawing.Color.White;
            this.btnGuardar_tiposprenda.IconColor = System.Drawing.Color.White;
            this.btnGuardar_tiposprenda.IconSize = 18;
            this.btnGuardar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnGuardar_tiposprenda.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar_tiposprenda.TabIndex = 11;
            this.btnGuardar_tiposprenda.Text = "Guardar";
            this.btnGuardar_tiposprenda.Click += new System.EventHandler(this.btnGuardar_tiposprenda_Click);
            //
            // btnEditar_tiposprenda
            //
            this.btnEditar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar_tiposprenda.Location = new System.Drawing.Point(809, 285);
            this.btnEditar_tiposprenda.Name = "btnEditar_tiposprenda";
            this.btnEditar_tiposprenda.BackColor = System.Drawing.Color.White;
            this.btnEditar_tiposprenda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnEditar_tiposprenda.FlatAppearance.BorderSize = 1;
            this.btnEditar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_tiposprenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnEditar_tiposprenda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnEditar_tiposprenda.IconSize = 18;
            this.btnEditar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnEditar_tiposprenda.Size = new System.Drawing.Size(142, 38);
            this.btnEditar_tiposprenda.TabIndex = 12;
            this.btnEditar_tiposprenda.Text = "Editar";
            this.btnEditar_tiposprenda.Click += new System.EventHandler(this.btnEditar_tiposprenda_Click);
            //
            // btnEliminar_tiposprenda
            //
            this.btnEliminar_tiposprenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_tiposprenda.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnEliminar_tiposprenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar_tiposprenda.Location = new System.Drawing.Point(809, 334);
            this.btnEliminar_tiposprenda.Name = "btnEliminar_tiposprenda";
            this.btnEliminar_tiposprenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar_tiposprenda.FlatAppearance.BorderSize = 0;
            this.btnEliminar_tiposprenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_tiposprenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_tiposprenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar_tiposprenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_tiposprenda.ForeColor = System.Drawing.Color.White;
            this.btnEliminar_tiposprenda.IconColor = System.Drawing.Color.White;
            this.btnEliminar_tiposprenda.IconSize = 18;
            this.btnEliminar_tiposprenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar_tiposprenda.UseVisualStyleBackColor = false;
            this.btnEliminar_tiposprenda.Size = new System.Drawing.Size(142, 33);
            this.btnEliminar_tiposprenda.TabIndex = 13;
            this.btnEliminar_tiposprenda.Text = "Eliminar";
            this.btnEliminar_tiposprenda.Click += new System.EventHandler(this.btnEliminar_tiposprenda_Click);
            //
            // TiposPrenda
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1044, 616);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tab_tiposprenda);
            this.Name = "TiposPrenda";
            this.Text = "Tipos de prenda";
            this.Load += new System.EventHandler(this.TiposPrenda_Load);
            this.tab_tiposprenda.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTiposPrenda)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TabControl tab_tiposprenda;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox textBuscar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnBuscar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnLimpiar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnImprimir_tiposprenda;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.DataGridView dataGridViewTiposPrenda;
        private FontAwesome.Sharp.IconButton btnExportar_tiposprenda;
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
        private FontAwesome.Sharp.IconButton btnNuevo_tiposprenda;
        private FontAwesome.Sharp.IconButton btnCancelar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnGuardar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnEditar_tiposprenda;
        private FontAwesome.Sharp.IconButton btnEliminar_tiposprenda;
    }
}
