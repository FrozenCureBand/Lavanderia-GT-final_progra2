namespace Pfinal_labanderia
{
    partial class Entregas
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
            this.tab_entregas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.textBuscar_entregas = new System.Windows.Forms.TextBox();
            this.btnBuscar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnImprimir_entregas = new FontAwesome.Sharp.IconButton();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.dataGridViewEntregas = new System.Windows.Forms.DataGridView();
            this.btnExportar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnPaginaAnterior = new FontAwesome.Sharp.IconButton();
            this.labelPagina = new System.Windows.Forms.Label();
            this.btnPaginaSiguiente = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboRecepcion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textNombreRecibe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.btnNuevo_entregas = new FontAwesome.Sharp.IconButton();
            this.btnCancelar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnGuardar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnEditar_entregas = new FontAwesome.Sharp.IconButton();
            this.btnEliminar_entregas = new FontAwesome.Sharp.IconButton();
            this.tab_entregas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntregas)).BeginInit();
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
            this.labelTitulo.Text = "Entregas";
            //
            // tab_entregas
            //
            this.tab_entregas.Controls.Add(this.tabPage1);
            this.tab_entregas.Controls.Add(this.tabPage2);
            this.tab_entregas.Location = new System.Drawing.Point(12, 51);
            this.tab_entregas.Name = "tab_entregas";
            this.tab_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_entregas.SelectedIndex = 0;
            this.tab_entregas.Size = new System.Drawing.Size(1004, 524);
            this.tab_entregas.TabIndex = 1;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.labelBuscar);
            this.tabPage1.Controls.Add(this.textBuscar_entregas);
            this.tabPage1.Controls.Add(this.btnBuscar_entregas);
            this.tabPage1.Controls.Add(this.btnLimpiar_entregas);
            this.tabPage1.Controls.Add(this.btnImprimir_entregas);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.labelRegistros);
            this.tabPage1.Controls.Add(this.dataGridViewEntregas);
            this.tabPage1.Controls.Add(this.btnExportar_entregas);
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
            // textBuscar_entregas
            //
            this.textBuscar_entregas.Location = new System.Drawing.Point(136, 76);
            this.textBuscar_entregas.MaxLength = 100;
            this.textBuscar_entregas.Name = "textBuscar_entregas";
            this.textBuscar_entregas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBuscar_entregas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar_entregas.Size = new System.Drawing.Size(328, 22);
            this.textBuscar_entregas.TabIndex = 1;
            this.textBuscar_entregas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBuscar_entregas_KeyDown);
            //
            // btnBuscar_entregas
            //
            this.btnBuscar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar_entregas.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar_entregas.Location = new System.Drawing.Point(498, 73);
            this.btnBuscar_entregas.Name = "btnBuscar_entregas";
            this.btnBuscar_entregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnBuscar_entregas.FlatAppearance.BorderSize = 0;
            this.btnBuscar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnBuscar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnBuscar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar_entregas.ForeColor = System.Drawing.Color.White;
            this.btnBuscar_entregas.IconColor = System.Drawing.Color.White;
            this.btnBuscar_entregas.IconSize = 18;
            this.btnBuscar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar_entregas.UseVisualStyleBackColor = false;
            this.btnBuscar_entregas.Size = new System.Drawing.Size(142, 34);
            this.btnBuscar_entregas.TabIndex = 2;
            this.btnBuscar_entregas.Text = "Buscar";
            this.btnBuscar_entregas.Click += new System.EventHandler(this.btnBuscar_entregas_Click);
            //
            // btnLimpiar_entregas
            //
            this.btnLimpiar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar_entregas.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar_entregas.Location = new System.Drawing.Point(660, 73);
            this.btnLimpiar_entregas.Name = "btnLimpiar_entregas";
            this.btnLimpiar_entregas.BackColor = System.Drawing.Color.White;
            this.btnLimpiar_entregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnLimpiar_entregas.FlatAppearance.BorderSize = 1;
            this.btnLimpiar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnLimpiar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar_entregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnLimpiar_entregas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLimpiar_entregas.IconSize = 18;
            this.btnLimpiar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar_entregas.UseVisualStyleBackColor = false;
            this.btnLimpiar_entregas.Size = new System.Drawing.Size(142, 34);
            this.btnLimpiar_entregas.TabIndex = 3;
            this.btnLimpiar_entregas.Text = "Limpiar";
            this.btnLimpiar_entregas.Click += new System.EventHandler(this.btnLimpiar_entregas_Click);
            //
            // btnImprimir_entregas
            //
            this.btnImprimir_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir_entregas.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir_entregas.Location = new System.Drawing.Point(825, 73);
            this.btnImprimir_entregas.Name = "btnImprimir_entregas";
            this.btnImprimir_entregas.BackColor = System.Drawing.Color.White;
            this.btnImprimir_entregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnImprimir_entregas.FlatAppearance.BorderSize = 1;
            this.btnImprimir_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnImprimir_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_entregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnImprimir_entregas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnImprimir_entregas.IconSize = 18;
            this.btnImprimir_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir_entregas.UseVisualStyleBackColor = false;
            this.btnImprimir_entregas.Size = new System.Drawing.Size(142, 34);
            this.btnImprimir_entregas.TabIndex = 4;
            this.btnImprimir_entregas.Text = "Imprimir";
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
            // dataGridViewEntregas
            //
            this.dataGridViewEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntregas.Location = new System.Drawing.Point(52, 149);
            this.dataGridViewEntregas.Name = "dataGridViewEntregas";
            this.dataGridViewEntregas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dataGridViewEntregas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEntregas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEntregas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewEntregas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewEntregas.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEntregas.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewEntregas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.dataGridViewEntregas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dataGridViewEntregas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.dataGridViewEntregas.EnableHeadersVisualStyles = false;
            this.dataGridViewEntregas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.dataGridViewEntregas.RowHeadersVisible = false;
            this.dataGridViewEntregas.RowHeadersWidth = 51;
            this.dataGridViewEntregas.RowTemplate.Height = 24;
            this.dataGridViewEntregas.Size = new System.Drawing.Size(915, 262);
            this.dataGridViewEntregas.TabIndex = 7;
            this.dataGridViewEntregas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEntregas_CellContentClick);
            //
            // btnExportar_entregas
            //
            this.btnExportar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar_entregas.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar_entregas.Location = new System.Drawing.Point(52, 431);
            this.btnExportar_entregas.Name = "btnExportar_entregas";
            this.btnExportar_entregas.BackColor = System.Drawing.Color.White;
            this.btnExportar_entregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnExportar_entregas.FlatAppearance.BorderSize = 1;
            this.btnExportar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnExportar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar_entregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnExportar_entregas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnExportar_entregas.IconSize = 18;
            this.btnExportar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar_entregas.UseVisualStyleBackColor = false;
            this.btnExportar_entregas.Size = new System.Drawing.Size(142, 38);
            this.btnExportar_entregas.TabIndex = 8;
            this.btnExportar_entregas.Text = "Exportar";
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
            this.tabPage2.Controls.Add(this.dateFechaEntrega);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textNombreRecibe);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textObservaciones);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textEstado);
            this.tabPage2.Controls.Add(this.btnNuevo_entregas);
            this.tabPage2.Controls.Add(this.btnCancelar_entregas);
            this.tabPage2.Controls.Add(this.btnGuardar_entregas);
            this.tabPage2.Controls.Add(this.btnEditar_entregas);
            this.tabPage2.Controls.Add(this.btnEliminar_entregas);
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
            this.label3.Size = new System.Drawing.Size(202, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de entrega";
            //
            // dateFechaEntrega
            //
            this.dateFechaEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFechaEntrega.Location = new System.Drawing.Point(342, 212);
            this.dateFechaEntrega.Name = "dateFechaEntrega";
            this.dateFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaEntrega.Size = new System.Drawing.Size(304, 22);
            this.dateFechaEntrega.TabIndex = 5;
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
            this.label4.Text = "Recibe";
            //
            // textNombreRecibe
            //
            this.textNombreRecibe.Location = new System.Drawing.Point(342, 257);
            this.textNombreRecibe.MaxLength = 150;
            this.textNombreRecibe.Name = "textNombreRecibe";
            this.textNombreRecibe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNombreRecibe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreRecibe.Size = new System.Drawing.Size(304, 22);
            this.textNombreRecibe.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 300);
            this.label5.Name = "label5";
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label5.Size = new System.Drawing.Size(166, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Observaciones";
            //
            // textObservaciones
            //
            this.textObservaciones.Location = new System.Drawing.Point(342, 301);
            this.textObservaciones.MaxLength = 500;
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textObservaciones.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textObservaciones.Size = new System.Drawing.Size(304, 22);
            this.textObservaciones.TabIndex = 9;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 344);
            this.label6.Name = "label6";
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado";
            //
            // textEstado
            //
            this.textEstado.Location = new System.Drawing.Point(342, 345);
            this.textEstado.Name = "textEstado";
            this.textEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEstado.ReadOnly = true;
            this.textEstado.Size = new System.Drawing.Size(304, 22);
            this.textEstado.TabIndex = 11;
            //
            // btnNuevo_entregas
            //
            this.btnNuevo_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo_entregas.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo_entregas.Location = new System.Drawing.Point(809, 157);
            this.btnNuevo_entregas.Name = "btnNuevo_entregas";
            this.btnNuevo_entregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnNuevo_entregas.FlatAppearance.BorderSize = 0;
            this.btnNuevo_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnNuevo_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnNuevo_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo_entregas.ForeColor = System.Drawing.Color.White;
            this.btnNuevo_entregas.IconColor = System.Drawing.Color.White;
            this.btnNuevo_entregas.IconSize = 18;
            this.btnNuevo_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo_entregas.UseVisualStyleBackColor = false;
            this.btnNuevo_entregas.Size = new System.Drawing.Size(142, 34);
            this.btnNuevo_entregas.TabIndex = 12;
            this.btnNuevo_entregas.Text = "Nuevo";
            this.btnNuevo_entregas.Click += new System.EventHandler(this.btnNuevo_entregas_Click);
            //
            // btnCancelar_entregas
            //
            this.btnCancelar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar_entregas.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar_entregas.Location = new System.Drawing.Point(809, 201);
            this.btnCancelar_entregas.Name = "btnCancelar_entregas";
            this.btnCancelar_entregas.BackColor = System.Drawing.Color.White;
            this.btnCancelar_entregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnCancelar_entregas.FlatAppearance.BorderSize = 1;
            this.btnCancelar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnCancelar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_entregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnCancelar_entregas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCancelar_entregas.IconSize = 18;
            this.btnCancelar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar_entregas.UseVisualStyleBackColor = false;
            this.btnCancelar_entregas.Size = new System.Drawing.Size(142, 34);
            this.btnCancelar_entregas.TabIndex = 13;
            this.btnCancelar_entregas.Text = "Cancelar";
            this.btnCancelar_entregas.Click += new System.EventHandler(this.btnCancelar_entregas_Click);
            //
            // btnGuardar_entregas
            //
            this.btnGuardar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar_entregas.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar_entregas.Location = new System.Drawing.Point(809, 238);
            this.btnGuardar_entregas.Name = "btnGuardar_entregas";
            this.btnGuardar_entregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnGuardar_entregas.FlatAppearance.BorderSize = 0;
            this.btnGuardar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(190)))));
            this.btnGuardar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(215)))));
            this.btnGuardar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_entregas.ForeColor = System.Drawing.Color.White;
            this.btnGuardar_entregas.IconColor = System.Drawing.Color.White;
            this.btnGuardar_entregas.IconSize = 18;
            this.btnGuardar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar_entregas.UseVisualStyleBackColor = false;
            this.btnGuardar_entregas.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar_entregas.TabIndex = 14;
            this.btnGuardar_entregas.Text = "Guardar";
            this.btnGuardar_entregas.Click += new System.EventHandler(this.btnGuardar_entregas_Click);
            //
            // btnEditar_entregas
            //
            this.btnEditar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar_entregas.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar_entregas.Location = new System.Drawing.Point(809, 285);
            this.btnEditar_entregas.Name = "btnEditar_entregas";
            this.btnEditar_entregas.BackColor = System.Drawing.Color.White;
            this.btnEditar_entregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(235)))));
            this.btnEditar_entregas.FlatAppearance.BorderSize = 1;
            this.btnEditar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.btnEditar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_entregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnEditar_entregas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnEditar_entregas.IconSize = 18;
            this.btnEditar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar_entregas.UseVisualStyleBackColor = false;
            this.btnEditar_entregas.Size = new System.Drawing.Size(142, 38);
            this.btnEditar_entregas.TabIndex = 15;
            this.btnEditar_entregas.Text = "Editar";
            this.btnEditar_entregas.Click += new System.EventHandler(this.btnEditar_entregas_Click);
            //
            // btnEliminar_entregas
            //
            this.btnEliminar_entregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_entregas.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnEliminar_entregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar_entregas.Location = new System.Drawing.Point(809, 334);
            this.btnEliminar_entregas.Name = "btnEliminar_entregas";
            this.btnEliminar_entregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar_entregas.FlatAppearance.BorderSize = 0;
            this.btnEliminar_entregas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_entregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnEliminar_entregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar_entregas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_entregas.ForeColor = System.Drawing.Color.White;
            this.btnEliminar_entregas.IconColor = System.Drawing.Color.White;
            this.btnEliminar_entregas.IconSize = 18;
            this.btnEliminar_entregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar_entregas.UseVisualStyleBackColor = false;
            this.btnEliminar_entregas.Size = new System.Drawing.Size(142, 33);
            this.btnEliminar_entregas.TabIndex = 16;
            this.btnEliminar_entregas.Text = "Eliminar";
            this.btnEliminar_entregas.Click += new System.EventHandler(this.btnEliminar_entregas_Click);
            //
            // Entregas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1044, 616);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tab_entregas);
            this.Name = "Entregas";
            this.Text = "Entregas";
            this.Load += new System.EventHandler(this.Entregas_Load);
            this.tab_entregas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntregas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TabControl tab_entregas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox textBuscar_entregas;
        private FontAwesome.Sharp.IconButton btnBuscar_entregas;
        private FontAwesome.Sharp.IconButton btnLimpiar_entregas;
        private FontAwesome.Sharp.IconButton btnImprimir_entregas;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.DataGridView dataGridViewEntregas;
        private FontAwesome.Sharp.IconButton btnExportar_entregas;
        private FontAwesome.Sharp.IconButton btnPaginaAnterior;
        private System.Windows.Forms.Label labelPagina;
        private FontAwesome.Sharp.IconButton btnPaginaSiguiente;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboRecepcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFechaEntrega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNombreRecibe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textEstado;
        private FontAwesome.Sharp.IconButton btnNuevo_entregas;
        private FontAwesome.Sharp.IconButton btnCancelar_entregas;
        private FontAwesome.Sharp.IconButton btnGuardar_entregas;
        private FontAwesome.Sharp.IconButton btnEditar_entregas;
        private FontAwesome.Sharp.IconButton btnEliminar_entregas;
    }
}
