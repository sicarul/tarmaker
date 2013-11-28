namespace TarMaker
{
    partial class NuevoProyecto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoProyecto));
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbCarpeta = new System.Windows.Forms.TextBox();
            this.lblProy = new System.Windows.Forms.Label();
            this.tbEvolutivo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.cbPerfil = new System.Windows.Forms.ComboBox();
            this.lblCodEvoCor = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(61, 145);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(217, 20);
            this.tbDescripcion.TabIndex = 5;
            this.toolTips.SetToolTip(this.tbDescripcion, "Nombre del evolutivo o correctivo, el titulo");
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 13);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Por favor ingrese los datos correspondientes al proyecto";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(28, 95);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Carpeta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(212, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbCarpeta
            // 
            this.tbCarpeta.Location = new System.Drawing.Point(61, 35);
            this.tbCarpeta.Name = "tbCarpeta";
            this.tbCarpeta.Size = new System.Drawing.Size(145, 20);
            this.tbCarpeta.TabIndex = 0;
            this.toolTips.SetToolTip(this.tbCarpeta, "Directorio donde se encuentran los archivos para generar el paquete.");
            // 
            // lblProy
            // 
            this.lblProy.AutoSize = true;
            this.lblProy.Location = new System.Drawing.Point(9, 122);
            this.lblProy.Name = "lblProy";
            this.lblProy.Size = new System.Drawing.Size(46, 13);
            this.lblProy.TabIndex = 1;
            this.lblProy.Tag = "";
            this.lblProy.Text = "Etiqueta";
            this.toolTips.SetToolTip(this.lblProy, "Etiqueta o Label");
            // 
            // tbEvolutivo
            // 
            this.tbEvolutivo.Location = new System.Drawing.Point(73, 119);
            this.tbEvolutivo.Name = "tbEvolutivo";
            this.tbEvolutivo.Size = new System.Drawing.Size(205, 20);
            this.tbEvolutivo.TabIndex = 4;
            this.toolTips.SetToolTip(this.tbEvolutivo, "Etiqueta o Label para subir a Dimensions y referenciar en SBM");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(131, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Crear";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(208, 171);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Evolutivo",
            "Correctivo"});
            this.cbTipo.Location = new System.Drawing.Point(61, 92);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(217, 21);
            this.cbTipo.TabIndex = 3;
            this.toolTips.SetToolTip(this.cbTipo, "¿Es un evolutivo o un correctivo?");
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(28, 67);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(30, 13);
            this.lblPerfil.TabIndex = 12;
            this.lblPerfil.Text = "Perfil";
            // 
            // cbPerfil
            // 
            this.cbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPerfil.FormattingEnabled = true;
            this.cbPerfil.Location = new System.Drawing.Point(61, 64);
            this.cbPerfil.Name = "cbPerfil";
            this.cbPerfil.Size = new System.Drawing.Size(217, 21);
            this.cbPerfil.TabIndex = 2;
            this.toolTips.SetToolTip(this.cbPerfil, "Define los servidores donde se instalara el paquete");
            // 
            // lblCodEvoCor
            // 
            this.lblCodEvoCor.AutoSize = true;
            this.lblCodEvoCor.Location = new System.Drawing.Point(58, 122);
            this.lblCodEvoCor.Name = "lblCodEvoCor";
            this.lblCodEvoCor.Size = new System.Drawing.Size(14, 13);
            this.lblCodEvoCor.TabIndex = 14;
            this.lblCodEvoCor.Text = "E";
            // 
            // NuevoProyecto
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.lblCodEvoCor);
            this.Controls.Add(this.cbPerfil);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblProy);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbCarpeta);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbEvolutivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 250);
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "NuevoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Proyecto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProy;
        private System.Windows.Forms.TextBox tbEvolutivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox tbCarpeta;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox cbPerfil;
        private System.Windows.Forms.Label lblCodEvoCor;
        private System.Windows.Forms.ToolTip toolTips;

    }
}