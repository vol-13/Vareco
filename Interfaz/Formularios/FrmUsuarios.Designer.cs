namespace Interfaz.Formularios
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.LblBuscar = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.cBoxVerActivos = new System.Windows.Forms.CheckBox();
            this.dgLista = new System.Windows.Forms.DataGridView();
            this.CCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuarioDireccion = new System.Windows.Forms.TextBox();
            this.cbUsuarioRol = new System.Windows.Forms.ComboBox();
            this.txtUsuarioContrasenia = new System.Windows.Forms.TextBox();
            this.txtUsuarioCorreo = new System.Windows.Forms.TextBox();
            this.txtUsuarioTelefono = new System.Windows.Forms.TextBox();
            this.txtUsuarioCedula = new System.Windows.Forms.TextBox();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.txtUsuarioID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblBuscar
            // 
            this.LblBuscar.AutoSize = true;
            this.LblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBuscar.Location = new System.Drawing.Point(27, 32);
            this.LblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(59, 20);
            this.LblBuscar.TabIndex = 0;
            this.LblBuscar.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(94, 32);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(483, 26);
            this.TxtBuscar.TabIndex = 1;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // cBoxVerActivos
            // 
            this.cBoxVerActivos.AutoSize = true;
            this.cBoxVerActivos.Checked = true;
            this.cBoxVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxVerActivos.Location = new System.Drawing.Point(584, 32);
            this.cBoxVerActivos.Name = "cBoxVerActivos";
            this.cBoxVerActivos.Size = new System.Drawing.Size(175, 24);
            this.cBoxVerActivos.TabIndex = 2;
            this.cBoxVerActivos.Text = "Ver Usuarios Activos";
            this.cBoxVerActivos.UseVisualStyleBackColor = true;
            this.cBoxVerActivos.CheckedChanged += new System.EventHandler(this.cBoxVerActivos_CheckedChanged);
            // 
            // dgLista
            // 
            this.dgLista.AllowUserToAddRows = false;
            this.dgLista.AllowUserToDeleteRows = false;
            this.dgLista.AllowUserToOrderColumns = true;
            this.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCodigo,
            this.CTipo,
            this.CNombre,
            this.CCedula,
            this.CTelefono,
            this.CEmail});
            this.dgLista.Location = new System.Drawing.Point(12, 63);
            this.dgLista.MultiSelect = false;
            this.dgLista.Name = "dgLista";
            this.dgLista.ReadOnly = true;
            this.dgLista.RowHeadersVisible = false;
            this.dgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLista.Size = new System.Drawing.Size(852, 310);
            this.dgLista.TabIndex = 3;
            this.dgLista.VirtualMode = true;
            this.dgLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLista_CellClick);
            this.dgLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgLista_DataBindingComplete);
            // 
            // CCodigo
            // 
            this.CCodigo.DataPropertyName = "UsuarioID";
            this.CCodigo.HeaderText = "Código";
            this.CCodigo.Name = "CCodigo";
            this.CCodigo.ReadOnly = true;
            // 
            // CTipo
            // 
            this.CTipo.DataPropertyName = "TIPO";
            this.CTipo.HeaderText = "Tipo";
            this.CTipo.Name = "CTipo";
            this.CTipo.ReadOnly = true;
            // 
            // CNombre
            // 
            this.CNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNombre.DataPropertyName = "UsuarioNombre";
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            this.CNombre.ReadOnly = true;
            // 
            // CCedula
            // 
            this.CCedula.DataPropertyName = "UsuarioCedula";
            this.CCedula.HeaderText = "Cédula";
            this.CCedula.Name = "CCedula";
            this.CCedula.ReadOnly = true;
            this.CCedula.Width = 125;
            // 
            // CTelefono
            // 
            this.CTelefono.DataPropertyName = "UsuarioTelefono";
            this.CTelefono.HeaderText = "Teléfono";
            this.CTelefono.Name = "CTelefono";
            this.CTelefono.ReadOnly = true;
            // 
            // CEmail
            // 
            this.CEmail.DataPropertyName = "UsuarioCorreo";
            this.CEmail.HeaderText = "Correo";
            this.CEmail.Name = "CEmail";
            this.CEmail.ReadOnly = true;
            this.CEmail.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsuarioDireccion);
            this.groupBox1.Controls.Add(this.cbUsuarioRol);
            this.groupBox1.Controls.Add(this.txtUsuarioContrasenia);
            this.groupBox1.Controls.Add(this.txtUsuarioCorreo);
            this.groupBox1.Controls.Add(this.txtUsuarioTelefono);
            this.groupBox1.Controls.Add(this.txtUsuarioCedula);
            this.groupBox1.Controls.Add(this.txtUsuarioNombre);
            this.groupBox1.Controls.Add(this.txtUsuarioID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 214);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Del Usuario";
            // 
            // txtUsuarioDireccion
            // 
            this.txtUsuarioDireccion.Location = new System.Drawing.Point(572, 155);
            this.txtUsuarioDireccion.Multiline = true;
            this.txtUsuarioDireccion.Name = "txtUsuarioDireccion";
            this.txtUsuarioDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUsuarioDireccion.Size = new System.Drawing.Size(267, 49);
            this.txtUsuarioDireccion.TabIndex = 9;
            this.txtUsuarioDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioDireccion_KeyPress);
            // 
            // cbUsuarioRol
            // 
            this.cbUsuarioRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarioRol.FormattingEnabled = true;
            this.cbUsuarioRol.Location = new System.Drawing.Point(572, 112);
            this.cbUsuarioRol.Name = "cbUsuarioRol";
            this.cbUsuarioRol.Size = new System.Drawing.Size(267, 28);
            this.cbUsuarioRol.TabIndex = 8;
            // 
            // txtUsuarioContrasenia
            // 
            this.txtUsuarioContrasenia.Location = new System.Drawing.Point(572, 79);
            this.txtUsuarioContrasenia.Name = "txtUsuarioContrasenia";
            this.txtUsuarioContrasenia.Size = new System.Drawing.Size(267, 26);
            this.txtUsuarioContrasenia.TabIndex = 7;
            this.txtUsuarioContrasenia.UseSystemPasswordChar = true;
            this.txtUsuarioContrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioContrasenia_KeyPress);
            // 
            // txtUsuarioCorreo
            // 
            this.txtUsuarioCorreo.Location = new System.Drawing.Point(572, 39);
            this.txtUsuarioCorreo.Name = "txtUsuarioCorreo";
            this.txtUsuarioCorreo.Size = new System.Drawing.Size(267, 26);
            this.txtUsuarioCorreo.TabIndex = 6;
            this.txtUsuarioCorreo.Enter += new System.EventHandler(this.txtUsuarioCorreo_Enter);
            this.txtUsuarioCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioCorreo_KeyPress);
            this.txtUsuarioCorreo.Leave += new System.EventHandler(this.txtUsuarioCorreo_Leave);
            // 
            // txtUsuarioTelefono
            // 
            this.txtUsuarioTelefono.Location = new System.Drawing.Point(94, 159);
            this.txtUsuarioTelefono.Name = "txtUsuarioTelefono";
            this.txtUsuarioTelefono.Size = new System.Drawing.Size(251, 26);
            this.txtUsuarioTelefono.TabIndex = 5;
            this.txtUsuarioTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioTelefono_KeyPress);
            // 
            // txtUsuarioCedula
            // 
            this.txtUsuarioCedula.Location = new System.Drawing.Point(94, 113);
            this.txtUsuarioCedula.Name = "txtUsuarioCedula";
            this.txtUsuarioCedula.Size = new System.Drawing.Size(251, 26);
            this.txtUsuarioCedula.TabIndex = 4;
            this.txtUsuarioCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioCedula_KeyPress);
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.Location = new System.Drawing.Point(94, 80);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.Size = new System.Drawing.Size(251, 26);
            this.txtUsuarioNombre.TabIndex = 3;
            this.txtUsuarioNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioNombre_KeyPress);
            // 
            // txtUsuarioID
            // 
            this.txtUsuarioID.Location = new System.Drawing.Point(94, 39);
            this.txtUsuarioID.Name = "txtUsuarioID";
            this.txtUsuarioID.ReadOnly = true;
            this.txtUsuarioID.Size = new System.Drawing.Size(147, 26);
            this.txtUsuarioID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Correo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Teléfono:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tipo de Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cédula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(12, 626);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(131, 42);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(207, 626);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(131, 42);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(384, 626);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(131, 42);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(544, 626);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(131, 42);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(720, 626);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 42);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(876, 692);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgLista);
            this.Controls.Add(this.cBoxVerActivos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.LblBuscar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión De Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.CheckBox cBoxVerActivos;
        private System.Windows.Forms.DataGridView dgLista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuarioCorreo;
        private System.Windows.Forms.TextBox txtUsuarioTelefono;
        private System.Windows.Forms.TextBox txtUsuarioCedula;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.TextBox txtUsuarioID;
        private System.Windows.Forms.TextBox txtUsuarioDireccion;
        private System.Windows.Forms.ComboBox cbUsuarioRol;
        private System.Windows.Forms.TextBox txtUsuarioContrasenia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEmail;
    }
}