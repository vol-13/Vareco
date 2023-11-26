namespace Interfaz.Formularios
{
    partial class FrmPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidos));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbVerActivos = new System.Windows.Forms.CheckBox();
            this.dgLista = new System.Windows.Forms.DataGridView();
            this.CCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstadoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEntrega = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnUsuarioBuscar = new System.Windows.Forms.Button();
            this.btnClienteBuscar = new System.Windows.Forms.Button();
            this.numCanPedido = new System.Windows.Forms.NumericUpDown();
            this.txtPedidoNotas = new System.Windows.Forms.TextBox();
            this.cbEstadoPedido = new System.Windows.Forms.ComboBox();
            this.txtPedidoFecha = new System.Windows.Forms.TextBox();
            this.txtPedidoProducto = new System.Windows.Forms.TextBox();
            this.txtPedidoCliente = new System.Windows.Forms.TextBox();
            this.txtPedidoUsuario = new System.Windows.Forms.TextBox();
            this.txtPedidoID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCanPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(95, 32);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(461, 26);
            this.txtBuscar.TabIndex = 1;
            // 
            // cbVerActivos
            // 
            this.cbVerActivos.AutoSize = true;
            this.cbVerActivos.Checked = true;
            this.cbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVerActivos.Location = new System.Drawing.Point(586, 34);
            this.cbVerActivos.Name = "cbVerActivos";
            this.cbVerActivos.Size = new System.Drawing.Size(169, 24);
            this.cbVerActivos.TabIndex = 2;
            this.cbVerActivos.Text = "Ver Pedidos Activos";
            this.cbVerActivos.UseVisualStyleBackColor = true;
            this.cbVerActivos.CheckedChanged += new System.EventHandler(this.cbVerActivos_CheckedChanged);
            // 
            // dgLista
            // 
            this.dgLista.AllowUserToAddRows = false;
            this.dgLista.AllowUserToDeleteRows = false;
            this.dgLista.AllowUserToOrderColumns = true;
            this.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCodigo,
            this.CProducto,
            this.CFechaPedido,
            this.CFechaEntrega,
            this.CCliente,
            this.CUsuario,
            this.CEstadoPedido});
            this.dgLista.Location = new System.Drawing.Point(12, 78);
            this.dgLista.MultiSelect = false;
            this.dgLista.Name = "dgLista";
            this.dgLista.ReadOnly = true;
            this.dgLista.RowHeadersVisible = false;
            this.dgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLista.Size = new System.Drawing.Size(881, 317);
            this.dgLista.TabIndex = 3;
            this.dgLista.VirtualMode = true;
            this.dgLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLista_CellClick);
            this.dgLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgLista_DataBindingComplete);
            // 
            // CCodigo
            // 
            this.CCodigo.DataPropertyName = "PedidoID";
            this.CCodigo.HeaderText = "Código";
            this.CCodigo.Name = "CCodigo";
            this.CCodigo.ReadOnly = true;
            this.CCodigo.Width = 70;
            // 
            // CProducto
            // 
            this.CProducto.DataPropertyName = "ProductoNombre";
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // CFechaPedido
            // 
            this.CFechaPedido.DataPropertyName = "PedidoFecha";
            this.CFechaPedido.HeaderText = "Fecha del Pedido";
            this.CFechaPedido.Name = "CFechaPedido";
            this.CFechaPedido.ReadOnly = true;
            // 
            // CFechaEntrega
            // 
            this.CFechaEntrega.DataPropertyName = "PedidoFechaEntraga";
            this.CFechaEntrega.HeaderText = "Fecha de Entrega";
            this.CFechaEntrega.Name = "CFechaEntrega";
            this.CFechaEntrega.ReadOnly = true;
            // 
            // CCliente
            // 
            this.CCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CCliente.DataPropertyName = "ClienteNombre";
            this.CCliente.HeaderText = "Cliente";
            this.CCliente.Name = "CCliente";
            this.CCliente.ReadOnly = true;
            // 
            // CUsuario
            // 
            this.CUsuario.DataPropertyName = "UsuarioNombre";
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            this.CUsuario.Width = 200;
            // 
            // CEstadoPedido
            // 
            this.CEstadoPedido.DataPropertyName = "TIPO";
            this.CEstadoPedido.HeaderText = "Estado";
            this.CEstadoPedido.Name = "CEstadoPedido";
            this.CEstadoPedido.ReadOnly = true;
            this.CEstadoPedido.Width = 125;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateEntrega);
            this.groupBox1.Controls.Add(this.btnBuscarProducto);
            this.groupBox1.Controls.Add(this.btnUsuarioBuscar);
            this.groupBox1.Controls.Add(this.btnClienteBuscar);
            this.groupBox1.Controls.Add(this.numCanPedido);
            this.groupBox1.Controls.Add(this.txtPedidoNotas);
            this.groupBox1.Controls.Add(this.cbEstadoPedido);
            this.groupBox1.Controls.Add(this.txtPedidoFecha);
            this.groupBox1.Controls.Add(this.txtPedidoProducto);
            this.groupBox1.Controls.Add(this.txtPedidoCliente);
            this.groupBox1.Controls.Add(this.txtPedidoUsuario);
            this.groupBox1.Controls.Add(this.txtPedidoID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(22, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 274);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Del Pedido";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(658, 207);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(154, 26);
            this.txtTotal.TabIndex = 16;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Total:";
            // 
            // dateEntrega
            // 
            this.dateEntrega.Location = new System.Drawing.Point(620, 76);
            this.dateEntrega.Name = "dateEntrega";
            this.dateEntrega.Size = new System.Drawing.Size(229, 26);
            this.dateEntrega.TabIndex = 14;
            this.dateEntrega.Value = new System.DateTime(2023, 11, 23, 14, 11, 12, 0);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.Teal;
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(351, 204);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(75, 26);
            this.btnBuscarProducto.TabIndex = 13;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnUsuarioBuscar
            // 
            this.btnUsuarioBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnUsuarioBuscar.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioBuscar.Location = new System.Drawing.Point(351, 113);
            this.btnUsuarioBuscar.Name = "btnUsuarioBuscar";
            this.btnUsuarioBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnUsuarioBuscar.TabIndex = 12;
            this.btnUsuarioBuscar.Text = "Buscar";
            this.btnUsuarioBuscar.UseVisualStyleBackColor = false;
            this.btnUsuarioBuscar.Click += new System.EventHandler(this.btnUsuarioBuscar_Click);
            // 
            // btnClienteBuscar
            // 
            this.btnClienteBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnClienteBuscar.ForeColor = System.Drawing.Color.White;
            this.btnClienteBuscar.Location = new System.Drawing.Point(351, 159);
            this.btnClienteBuscar.Name = "btnClienteBuscar";
            this.btnClienteBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnClienteBuscar.TabIndex = 11;
            this.btnClienteBuscar.Text = "Buscar";
            this.btnClienteBuscar.UseVisualStyleBackColor = false;
            this.btnClienteBuscar.Click += new System.EventHandler(this.btnClienteBuscar_Click);
            // 
            // numCanPedido
            // 
            this.numCanPedido.Location = new System.Drawing.Point(658, 165);
            this.numCanPedido.Name = "numCanPedido";
            this.numCanPedido.Size = new System.Drawing.Size(154, 26);
            this.numCanPedido.TabIndex = 10;
            this.numCanPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPedidoNotas
            // 
            this.txtPedidoNotas.Location = new System.Drawing.Point(620, 110);
            this.txtPedidoNotas.Multiline = true;
            this.txtPedidoNotas.Name = "txtPedidoNotas";
            this.txtPedidoNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPedidoNotas.Size = new System.Drawing.Size(223, 49);
            this.txtPedidoNotas.TabIndex = 9;
            // 
            // cbEstadoPedido
            // 
            this.cbEstadoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoPedido.FormattingEnabled = true;
            this.cbEstadoPedido.Location = new System.Drawing.Point(154, 74);
            this.cbEstadoPedido.Name = "cbEstadoPedido";
            this.cbEstadoPedido.Size = new System.Drawing.Size(191, 28);
            this.cbEstadoPedido.TabIndex = 8;
            // 
            // txtPedidoFecha
            // 
            this.txtPedidoFecha.Location = new System.Drawing.Point(620, 40);
            this.txtPedidoFecha.Name = "txtPedidoFecha";
            this.txtPedidoFecha.ReadOnly = true;
            this.txtPedidoFecha.Size = new System.Drawing.Size(223, 26);
            this.txtPedidoFecha.TabIndex = 6;
            // 
            // txtPedidoProducto
            // 
            this.txtPedidoProducto.Location = new System.Drawing.Point(94, 204);
            this.txtPedidoProducto.Name = "txtPedidoProducto";
            this.txtPedidoProducto.ReadOnly = true;
            this.txtPedidoProducto.Size = new System.Drawing.Size(251, 26);
            this.txtPedidoProducto.TabIndex = 5;
            // 
            // txtPedidoCliente
            // 
            this.txtPedidoCliente.Location = new System.Drawing.Point(94, 159);
            this.txtPedidoCliente.Name = "txtPedidoCliente";
            this.txtPedidoCliente.ReadOnly = true;
            this.txtPedidoCliente.Size = new System.Drawing.Size(251, 26);
            this.txtPedidoCliente.TabIndex = 5;
            // 
            // txtPedidoUsuario
            // 
            this.txtPedidoUsuario.Location = new System.Drawing.Point(94, 113);
            this.txtPedidoUsuario.Name = "txtPedidoUsuario";
            this.txtPedidoUsuario.ReadOnly = true;
            this.txtPedidoUsuario.Size = new System.Drawing.Size(251, 26);
            this.txtPedidoUsuario.TabIndex = 4;
            // 
            // txtPedidoID
            // 
            this.txtPedidoID.Location = new System.Drawing.Point(94, 39);
            this.txtPedidoID.Name = "txtPedidoID";
            this.txtPedidoID.ReadOnly = true;
            this.txtPedidoID.Size = new System.Drawing.Size(147, 26);
            this.txtPedidoID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fecha Del Pedido:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(537, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Cantidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Notas:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Producto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cliente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Estado del Pedido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fecha De Entrega:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Usuario:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(703, 695);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 42);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(491, 695);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(131, 42);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(274, 695);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(131, 42);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(34, 695);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(131, 42);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(905, 749);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgLista);
            this.Controls.Add(this.cbVerActivos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión De Pedidos";
            this.Load += new System.EventHandler(this.FrmPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCanPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox cbVerActivos;
        private System.Windows.Forms.DataGridView dgLista;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPedidoNotas;
        private System.Windows.Forms.ComboBox cbEstadoPedido;
        private System.Windows.Forms.TextBox txtPedidoFecha;
        private System.Windows.Forms.TextBox txtPedidoCliente;
        private System.Windows.Forms.TextBox txtPedidoUsuario;
        private System.Windows.Forms.TextBox txtPedidoID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtPedidoProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numCanPedido;
        private System.Windows.Forms.Button btnClienteBuscar;
        private System.Windows.Forms.Button btnUsuarioBuscar;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.DateTimePicker dateEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstadoPedido;
        private System.Windows.Forms.TextBox txtTotal;
    }
}