﻿namespace Inventario.TIC.Forms
{
    partial class FrmTermoComputador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTermoComputador = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDataEntrega = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboGestores = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCarregadores = new System.Windows.Forms.DataGridView();
            this.txtCarregador = new System.Windows.Forms.TextBox();
            this.txtCarregadorIdReadOnly = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumSerieReadOnly = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCarregadorMarcaReadOnly = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaCarregador = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUsuarioIdReadOnly = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtChapaReadOnly = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCpfReadOnly = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeReadOnly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaUsuario = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelarDevolucao = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lnkAbrirTermoEntrega = new System.Windows.Forms.LinkLabel();
            this.lnkAddTermo = new System.Windows.Forms.LinkLabel();
            this.txtLinkTermoEntrega = new System.Windows.Forms.TextBox();
            this.txtLinkTermoDevolucao = new System.Windows.Forms.TextBox();
            this.lnkTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.lnkAbrirTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.lnkRemoverTermoEntrega = new System.Windows.Forms.LinkLabel();
            this.lnkRemoverTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdReadOnly = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAtivo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDepartamentoReadOnly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAtivoReadOnly = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoAlugado = new System.Windows.Forms.RadioButton();
            this.rdoProprio = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lnkRelTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.lnkRelTermoEntrega = new System.Windows.Forms.LinkLabel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoComputador)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarregadores)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1008, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTermoComputador
            // 
            this.dgvTermoComputador.AllowUserToAddRows = false;
            this.dgvTermoComputador.AllowUserToDeleteRows = false;
            this.dgvTermoComputador.AllowUserToOrderColumns = true;
            this.dgvTermoComputador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTermoComputador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTermoComputador.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTermoComputador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermoComputador.Location = new System.Drawing.Point(12, 429);
            this.dgvTermoComputador.MultiSelect = false;
            this.dgvTermoComputador.Name = "dgvTermoComputador";
            this.dgvTermoComputador.ReadOnly = true;
            this.dgvTermoComputador.Size = new System.Drawing.Size(1071, 364);
            this.dgvTermoComputador.TabIndex = 61;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.txtId);
            this.groupBox5.Controls.Add(this.txtDataEntrega);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.cboGestores);
            this.groupBox5.Location = new System.Drawing.Point(12, 343);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(353, 80);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Outros Dados";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 80;
            this.label25.Text = "Num. Termo";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 40);
            this.txtId.MaxLength = 9;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(62, 20);
            this.txtId.TabIndex = 83;
            // 
            // txtDataEntrega
            // 
            this.txtDataEntrega.Location = new System.Drawing.Point(80, 40);
            this.txtDataEntrega.Mask = "00/00/0000";
            this.txtDataEntrega.Name = "txtDataEntrega";
            this.txtDataEntrega.Size = new System.Drawing.Size(86, 20);
            this.txtDataEntrega.TabIndex = 6;
            this.txtDataEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(77, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Data Entrega (*)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(169, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Gestor (*)";
            // 
            // cboGestores
            // 
            this.cboGestores.FormattingEnabled = true;
            this.cboGestores.Location = new System.Drawing.Point(172, 39);
            this.cboGestores.Name = "cboGestores";
            this.cboGestores.Size = new System.Drawing.Size(170, 21);
            this.cboGestores.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvCarregadores);
            this.groupBox4.Controls.Add(this.txtCarregador);
            this.groupBox4.Controls.Add(this.txtCarregadorIdReadOnly);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtNumSerieReadOnly);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtCarregadorMarcaReadOnly);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.btnNovaPesquisaCarregador);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(12, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 169);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selecionar Carregador";
            // 
            // dgvCarregadores
            // 
            this.dgvCarregadores.AllowUserToAddRows = false;
            this.dgvCarregadores.AllowUserToDeleteRows = false;
            this.dgvCarregadores.AllowUserToOrderColumns = true;
            this.dgvCarregadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarregadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCarregadores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCarregadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarregadores.Location = new System.Drawing.Point(6, 68);
            this.dgvCarregadores.MultiSelect = false;
            this.dgvCarregadores.Name = "dgvCarregadores";
            this.dgvCarregadores.ReadOnly = true;
            this.dgvCarregadores.RowHeadersVisible = false;
            this.dgvCarregadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarregadores.Size = new System.Drawing.Size(307, 95);
            this.dgvCarregadores.TabIndex = 3;
            this.dgvCarregadores.Visible = false;
            this.dgvCarregadores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarregadores_CellDoubleClick);
            this.dgvCarregadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCarregadores_KeyDown);
            this.dgvCarregadores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCarregadores_KeyPress);
            // 
            // txtCarregador
            // 
            this.txtCarregador.Location = new System.Drawing.Point(6, 40);
            this.txtCarregador.MaxLength = 500;
            this.txtCarregador.Name = "txtCarregador";
            this.txtCarregador.Size = new System.Drawing.Size(208, 20);
            this.txtCarregador.TabIndex = 2;
            this.txtCarregador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarregador_KeyPress);
            // 
            // txtCarregadorIdReadOnly
            // 
            this.txtCarregadorIdReadOnly.Location = new System.Drawing.Point(386, 47);
            this.txtCarregadorIdReadOnly.MaxLength = 9;
            this.txtCarregadorIdReadOnly.Name = "txtCarregadorIdReadOnly";
            this.txtCarregadorIdReadOnly.ReadOnly = true;
            this.txtCarregadorIdReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtCarregadorIdReadOnly.TabIndex = 81;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(330, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "ID";
            // 
            // txtNumSerieReadOnly
            // 
            this.txtNumSerieReadOnly.Location = new System.Drawing.Point(386, 99);
            this.txtNumSerieReadOnly.MaxLength = 9;
            this.txtNumSerieReadOnly.Name = "txtNumSerieReadOnly";
            this.txtNumSerieReadOnly.ReadOnly = true;
            this.txtNumSerieReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtNumSerieReadOnly.TabIndex = 56;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(330, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "N. Série";
            // 
            // txtCarregadorMarcaReadOnly
            // 
            this.txtCarregadorMarcaReadOnly.Location = new System.Drawing.Point(386, 73);
            this.txtCarregadorMarcaReadOnly.MaxLength = 9;
            this.txtCarregadorMarcaReadOnly.Name = "txtCarregadorMarcaReadOnly";
            this.txtCarregadorMarcaReadOnly.ReadOnly = true;
            this.txtCarregadorMarcaReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtCarregadorMarcaReadOnly.TabIndex = 54;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(330, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Marca";
            // 
            // btnNovaPesquisaCarregador
            // 
            this.btnNovaPesquisaCarregador.Location = new System.Drawing.Point(220, 37);
            this.btnNovaPesquisaCarregador.Name = "btnNovaPesquisaCarregador";
            this.btnNovaPesquisaCarregador.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaCarregador.TabIndex = 52;
            this.btnNovaPesquisaCarregador.Text = "Nova Pesquisa";
            this.btnNovaPesquisaCarregador.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaCarregador.Click += new System.EventHandler(this.btnNovaPesquisaCarregador_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Carregador (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsuarioIdReadOnly);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.dgvUsuarios);
            this.groupBox2.Controls.Add(this.txtChapaReadOnly);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCpfReadOnly);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNomeReadOnly);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnNovaPesquisaUsuario);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 150);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuários";
            // 
            // txtUsuarioIdReadOnly
            // 
            this.txtUsuarioIdReadOnly.Location = new System.Drawing.Point(386, 41);
            this.txtUsuarioIdReadOnly.MaxLength = 9;
            this.txtUsuarioIdReadOnly.Name = "txtUsuarioIdReadOnly";
            this.txtUsuarioIdReadOnly.ReadOnly = true;
            this.txtUsuarioIdReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioIdReadOnly.TabIndex = 81;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(330, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "ID";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(6, 41);
            this.txtUsuario.MaxLength = 500;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtUsuario.TabIndex = 10;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 70);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(307, 69);
            this.dgvUsuarios.TabIndex = 11;
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsuarios_KeyDown);
            this.dgvUsuarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvUsuarios_KeyPress);
            // 
            // txtChapaReadOnly
            // 
            this.txtChapaReadOnly.Location = new System.Drawing.Point(386, 119);
            this.txtChapaReadOnly.MaxLength = 9;
            this.txtChapaReadOnly.Name = "txtChapaReadOnly";
            this.txtChapaReadOnly.ReadOnly = true;
            this.txtChapaReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtChapaReadOnly.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Chapa";
            // 
            // txtCpfReadOnly
            // 
            this.txtCpfReadOnly.Location = new System.Drawing.Point(386, 93);
            this.txtCpfReadOnly.MaxLength = 9;
            this.txtCpfReadOnly.Name = "txtCpfReadOnly";
            this.txtCpfReadOnly.ReadOnly = true;
            this.txtCpfReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtCpfReadOnly.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "CPF";
            // 
            // txtNomeReadOnly
            // 
            this.txtNomeReadOnly.Location = new System.Drawing.Point(386, 67);
            this.txtNomeReadOnly.MaxLength = 9;
            this.txtNomeReadOnly.Name = "txtNomeReadOnly";
            this.txtNomeReadOnly.ReadOnly = true;
            this.txtNomeReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtNomeReadOnly.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Nome";
            // 
            // btnNovaPesquisaUsuario
            // 
            this.btnNovaPesquisaUsuario.Location = new System.Drawing.Point(220, 38);
            this.btnNovaPesquisaUsuario.Name = "btnNovaPesquisaUsuario";
            this.btnNovaPesquisaUsuario.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaUsuario.TabIndex = 52;
            this.btnNovaPesquisaUsuario.Text = "Nova Pesquisa";
            this.btnNovaPesquisaUsuario.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaUsuario.Click += new System.EventHandler(this.btnNovaPesquisaUsuario_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Usuário (*)";
            // 
            // btnCancelarDevolucao
            // 
            this.btnCancelarDevolucao.Location = new System.Drawing.Point(886, 244);
            this.btnCancelarDevolucao.Name = "btnCancelarDevolucao";
            this.btnCancelarDevolucao.Size = new System.Drawing.Size(121, 23);
            this.btnCancelarDevolucao.TabIndex = 116;
            this.btnCancelarDevolucao.Text = "Cancelar Devolução";
            this.btnCancelarDevolucao.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(886, 213);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(70, 23);
            this.btnDevolver.TabIndex = 115;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // lnkAbrirTermoEntrega
            // 
            this.lnkAbrirTermoEntrega.AutoSize = true;
            this.lnkAbrirTermoEntrega.Location = new System.Drawing.Point(550, 202);
            this.lnkAbrirTermoEntrega.Name = "lnkAbrirTermoEntrega";
            this.lnkAbrirTermoEntrega.Size = new System.Drawing.Size(176, 13);
            this.lnkAbrirTermoEntrega.TabIndex = 100;
            this.lnkAbrirTermoEntrega.TabStop = true;
            this.lnkAbrirTermoEntrega.Text = "Link do Termo de Entrega Assinado";
            // 
            // lnkAddTermo
            // 
            this.lnkAddTermo.AutoSize = true;
            this.lnkAddTermo.Location = new System.Drawing.Point(809, 208);
            this.lnkAddTermo.Name = "lnkAddTermo";
            this.lnkAddTermo.Size = new System.Drawing.Size(51, 13);
            this.lnkAddTermo.TabIndex = 98;
            this.lnkAddTermo.TabStop = true;
            this.lnkAddTermo.Text = "Adicionar";
            // 
            // txtLinkTermoEntrega
            // 
            this.txtLinkTermoEntrega.Location = new System.Drawing.Point(553, 217);
            this.txtLinkTermoEntrega.MaxLength = 15;
            this.txtLinkTermoEntrega.Name = "txtLinkTermoEntrega";
            this.txtLinkTermoEntrega.ReadOnly = true;
            this.txtLinkTermoEntrega.Size = new System.Drawing.Size(252, 20);
            this.txtLinkTermoEntrega.TabIndex = 99;
            // 
            // txtLinkTermoDevolucao
            // 
            this.txtLinkTermoDevolucao.Location = new System.Drawing.Point(553, 270);
            this.txtLinkTermoDevolucao.MaxLength = 15;
            this.txtLinkTermoDevolucao.Name = "txtLinkTermoDevolucao";
            this.txtLinkTermoDevolucao.ReadOnly = true;
            this.txtLinkTermoDevolucao.Size = new System.Drawing.Size(247, 20);
            this.txtLinkTermoDevolucao.TabIndex = 101;
            // 
            // lnkTermoDevolucao
            // 
            this.lnkTermoDevolucao.AutoSize = true;
            this.lnkTermoDevolucao.Location = new System.Drawing.Point(805, 259);
            this.lnkTermoDevolucao.Name = "lnkTermoDevolucao";
            this.lnkTermoDevolucao.Size = new System.Drawing.Size(51, 13);
            this.lnkTermoDevolucao.TabIndex = 102;
            this.lnkTermoDevolucao.TabStop = true;
            this.lnkTermoDevolucao.Text = "Adicionar";
            // 
            // lnkAbrirTermoDevolucao
            // 
            this.lnkAbrirTermoDevolucao.AutoSize = true;
            this.lnkAbrirTermoDevolucao.Location = new System.Drawing.Point(550, 254);
            this.lnkAbrirTermoDevolucao.Name = "lnkAbrirTermoDevolucao";
            this.lnkAbrirTermoDevolucao.Size = new System.Drawing.Size(191, 13);
            this.lnkAbrirTermoDevolucao.TabIndex = 103;
            this.lnkAbrirTermoDevolucao.TabStop = true;
            this.lnkAbrirTermoDevolucao.Text = "Link do Termo de Devolução Assinado";
            // 
            // lnkRemoverTermoEntrega
            // 
            this.lnkRemoverTermoEntrega.AutoSize = true;
            this.lnkRemoverTermoEntrega.Location = new System.Drawing.Point(810, 225);
            this.lnkRemoverTermoEntrega.Name = "lnkRemoverTermoEntrega";
            this.lnkRemoverTermoEntrega.Size = new System.Drawing.Size(50, 13);
            this.lnkRemoverTermoEntrega.TabIndex = 104;
            this.lnkRemoverTermoEntrega.TabStop = true;
            this.lnkRemoverTermoEntrega.Text = "Remover";
            // 
            // lnkRemoverTermoDevolucao
            // 
            this.lnkRemoverTermoDevolucao.AutoSize = true;
            this.lnkRemoverTermoDevolucao.Location = new System.Drawing.Point(806, 276);
            this.lnkRemoverTermoDevolucao.Name = "lnkRemoverTermoDevolucao";
            this.lnkRemoverTermoDevolucao.Size = new System.Drawing.Size(50, 13);
            this.lnkRemoverTermoDevolucao.TabIndex = 105;
            this.lnkRemoverTermoDevolucao.TabStop = true;
            this.lnkRemoverTermoDevolucao.Text = "Remover";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdReadOnly);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAtivo);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtDepartamentoReadOnly);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAtivoReadOnly);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rdoAlugado);
            this.groupBox1.Controls.Add(this.rdoProprio);
            this.groupBox1.Location = new System.Drawing.Point(546, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 168);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Computador";
            // 
            // txtIdReadOnly
            // 
            this.txtIdReadOnly.Location = new System.Drawing.Point(395, 67);
            this.txtIdReadOnly.MaxLength = 9;
            this.txtIdReadOnly.Name = "txtIdReadOnly";
            this.txtIdReadOnly.ReadOnly = true;
            this.txtIdReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtIdReadOnly.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "ID";
            // 
            // txtAtivo
            // 
            this.txtAtivo.Location = new System.Drawing.Point(15, 67);
            this.txtAtivo.MaxLength = 500;
            this.txtAtivo.Name = "txtAtivo";
            this.txtAtivo.Size = new System.Drawing.Size(208, 20);
            this.txtAtivo.TabIndex = 82;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 96);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(309, 60);
            this.dataGridView1.TabIndex = 83;
            this.dataGridView1.Visible = false;
            // 
            // txtDepartamentoReadOnly
            // 
            this.txtDepartamentoReadOnly.Location = new System.Drawing.Point(395, 119);
            this.txtDepartamentoReadOnly.MaxLength = 9;
            this.txtDepartamentoReadOnly.Name = "txtDepartamentoReadOnly";
            this.txtDepartamentoReadOnly.ReadOnly = true;
            this.txtDepartamentoReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtDepartamentoReadOnly.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(339, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Depart,";
            // 
            // txtAtivoReadOnly
            // 
            this.txtAtivoReadOnly.Location = new System.Drawing.Point(395, 93);
            this.txtAtivoReadOnly.MaxLength = 9;
            this.txtAtivoReadOnly.Name = "txtAtivoReadOnly";
            this.txtAtivoReadOnly.ReadOnly = true;
            this.txtAtivoReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtAtivoReadOnly.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(339, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "Ativo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 25);
            this.button2.TabIndex = 85;
            this.button2.Text = "Nova Pesquisa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 84;
            this.label9.Text = "Ativo (*)";
            // 
            // rdoAlugado
            // 
            this.rdoAlugado.AutoSize = true;
            this.rdoAlugado.Location = new System.Drawing.Point(285, 26);
            this.rdoAlugado.Name = "rdoAlugado";
            this.rdoAlugado.Size = new System.Drawing.Size(64, 17);
            this.rdoAlugado.TabIndex = 1;
            this.rdoAlugado.TabStop = true;
            this.rdoAlugado.Text = "Alugado";
            this.rdoAlugado.UseVisualStyleBackColor = true;
            // 
            // rdoProprio
            // 
            this.rdoProprio.AutoSize = true;
            this.rdoProprio.Location = new System.Drawing.Point(167, 26);
            this.rdoProprio.Name = "rdoProprio";
            this.rdoProprio.Size = new System.Drawing.Size(58, 17);
            this.rdoProprio.TabIndex = 0;
            this.rdoProprio.TabStop = true;
            this.rdoProprio.Text = "Próprio";
            this.rdoProprio.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(371, 385);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 123;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // lnkRelTermoDevolucao
            // 
            this.lnkRelTermoDevolucao.AutoSize = true;
            this.lnkRelTermoDevolucao.Location = new System.Drawing.Point(533, 385);
            this.lnkRelTermoDevolucao.Name = "lnkRelTermoDevolucao";
            this.lnkRelTermoDevolucao.Size = new System.Drawing.Size(196, 13);
            this.lnkRelTermoDevolucao.TabIndex = 122;
            this.lnkRelTermoDevolucao.TabStop = true;
            this.lnkRelTermoDevolucao.Text = "Gerar Relatório do Termo de Devolução";
            // 
            // lnkRelTermoEntrega
            // 
            this.lnkRelTermoEntrega.AutoSize = true;
            this.lnkRelTermoEntrega.Location = new System.Drawing.Point(533, 361);
            this.lnkRelTermoEntrega.Name = "lnkRelTermoEntrega";
            this.lnkRelTermoEntrega.Size = new System.Drawing.Size(181, 13);
            this.lnkRelTermoEntrega.TabIndex = 121;
            this.lnkRelTermoEntrega.TabStop = true;
            this.lnkRelTermoEntrega.Text = "Gerar Relatório do Termo de Entrega";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(452, 385);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 120;
            this.btnExcluir.Text = "Teste";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(452, 356);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 119;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(371, 356);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 118;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // FrmTermoComputador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 805);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.lnkRelTermoDevolucao);
            this.Controls.Add(this.lnkRelTermoEntrega);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelarDevolucao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lnkAbrirTermoEntrega);
            this.Controls.Add(this.lnkAddTermo);
            this.Controls.Add(this.dgvTermoComputador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLinkTermoEntrega);
            this.Controls.Add(this.lnkRemoverTermoDevolucao);
            this.Controls.Add(this.lnkRemoverTermoEntrega);
            this.Controls.Add(this.txtLinkTermoDevolucao);
            this.Controls.Add(this.lnkAbrirTermoDevolucao);
            this.Controls.Add(this.lnkTermoDevolucao);
            this.Name = "FrmTermoComputador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termo de Computadores";
            this.Load += new System.EventHandler(this.FrmTermoComputador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoComputador)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarregadores)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvTermoComputador;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox txtDataEntrega;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboGestores;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvCarregadores;
        private System.Windows.Forms.TextBox txtCarregador;
        private System.Windows.Forms.TextBox txtCarregadorIdReadOnly;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNumSerieReadOnly;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCarregadorMarcaReadOnly;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnNovaPesquisaCarregador;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUsuarioIdReadOnly;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtChapaReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCpfReadOnly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeReadOnly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNovaPesquisaUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelarDevolucao;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.LinkLabel lnkAbrirTermoEntrega;
        private System.Windows.Forms.LinkLabel lnkAddTermo;
        private System.Windows.Forms.TextBox txtLinkTermoEntrega;
        private System.Windows.Forms.TextBox txtLinkTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkAbrirTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkRemoverTermoEntrega;
        private System.Windows.Forms.LinkLabel lnkRemoverTermoDevolucao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoAlugado;
        private System.Windows.Forms.RadioButton rdoProprio;
        private System.Windows.Forms.TextBox txtIdReadOnly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAtivo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDepartamentoReadOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAtivoReadOnly;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.LinkLabel lnkRelTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkRelTermoEntrega;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
    }
}