namespace TarMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuBar = new System.Windows.Forms.ToolStrip();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAyuda = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vistaArchivos = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lblNombreProyecto = new System.Windows.Forms.Label();
            this.lblArchivosMigrados = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnRevisarFuentes = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.grpErrores = new System.Windows.Forms.GroupBox();
            this.lblErrores = new System.Windows.Forms.Label();
            this.grpPerm = new System.Windows.Forms.GroupBox();
            this.permList = new System.Windows.Forms.ListView();
            this.entorno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.perms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.muestraTexto = new System.Windows.Forms.RichTextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.grpErrores.SuspendLayout();
            this.grpPerm.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.toolStripSeparator,
            this.tsbAyuda,
            this.toolStripSeparator1,
            this.tsbAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar.Size = new System.Drawing.Size(842, 25);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "toolStrip1";
            // 
            // tsbLoad
            // 
            this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
            this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(112, 22);
            this.tsbLoad.Text = "&Cargar proyecto";
            this.tsbLoad.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAyuda
            // 
            this.tsbAyuda.Image = ((System.Drawing.Image)(resources.GetObject("tsbAyuda.Image")));
            this.tsbAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAyuda.Name = "tsbAyuda";
            this.tsbAyuda.Size = new System.Drawing.Size(61, 22);
            this.tsbAyuda.Text = "&Ayuda";
            this.tsbAyuda.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::TarMaker.Properties.Resources.icono_mini;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(132, 22);
            this.tsbAbout.Text = "Acerca de Tarmaker";
            this.tsbAbout.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 496);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vistaArchivos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(842, 496);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 0;
            // 
            // vistaArchivos
            // 
            this.vistaArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vistaArchivos.Location = new System.Drawing.Point(0, 0);
            this.vistaArchivos.Name = "vistaArchivos";
            this.vistaArchivos.Size = new System.Drawing.Size(260, 496);
            this.vistaArchivos.TabIndex = 0;
            this.vistaArchivos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.vistaArchivos_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.muestraTexto);
            this.splitContainer2.Size = new System.Drawing.Size(578, 496);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.grpErrores);
            this.splitContainer3.Panel2.Controls.Add(this.grpPerm);
            this.splitContainer3.Size = new System.Drawing.Size(578, 200);
            this.splitContainer3.SplitterDistance = 74;
            this.splitContainer3.TabIndex = 9;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lblNombreProyecto);
            this.splitContainer4.Panel1.Controls.Add(this.lblArchivosMigrados);
            this.splitContainer4.Panel1.Controls.Add(this.lblDescripcion);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnRevisarFuentes);
            this.splitContainer4.Panel2.Controls.Add(this.btnGenerar);
            this.splitContainer4.Size = new System.Drawing.Size(578, 74);
            this.splitContainer4.SplitterDistance = 410;
            this.splitContainer4.TabIndex = 0;
            // 
            // lblNombreProyecto
            // 
            this.lblNombreProyecto.AutoSize = true;
            this.lblNombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProyecto.Location = new System.Drawing.Point(3, 0);
            this.lblNombreProyecto.Name = "lblNombreProyecto";
            this.lblNombreProyecto.Size = new System.Drawing.Size(242, 24);
            this.lblNombreProyecto.TabIndex = 6;
            this.lblNombreProyecto.Text = "Debe cargar un proyecto";
            this.lblNombreProyecto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblArchivosMigrados
            // 
            this.lblArchivosMigrados.AutoSize = true;
            this.lblArchivosMigrados.Location = new System.Drawing.Point(3, 37);
            this.lblArchivosMigrados.Name = "lblArchivosMigrados";
            this.lblArchivosMigrados.Size = new System.Drawing.Size(93, 13);
            this.lblArchivosMigrados.TabIndex = 8;
            this.lblArchivosMigrados.Text = "Archivos migrados";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(4, 24);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // btnRevisarFuentes
            // 
            this.btnRevisarFuentes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRevisarFuentes.Enabled = false;
            this.btnRevisarFuentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevisarFuentes.Location = new System.Drawing.Point(82, 0);
            this.btnRevisarFuentes.Name = "btnRevisarFuentes";
            this.btnRevisarFuentes.Size = new System.Drawing.Size(82, 74);
            this.btnRevisarFuentes.TabIndex = 10;
            this.btnRevisarFuentes.Text = "Revisar fuentes en Dimensions";
            this.btnRevisarFuentes.UseVisualStyleBackColor = true;
            this.btnRevisarFuentes.Click += new System.EventHandler(this.btnSubirFuentes_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGenerar.Enabled = false;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(0, 0);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(83, 74);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar Instalador";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // grpErrores
            // 
            this.grpErrores.Controls.Add(this.lblErrores);
            this.grpErrores.Location = new System.Drawing.Point(7, 7);
            this.grpErrores.Name = "grpErrores";
            this.grpErrores.Size = new System.Drawing.Size(188, 109);
            this.grpErrores.TabIndex = 8;
            this.grpErrores.TabStop = false;
            this.grpErrores.Text = "Errores";
            this.grpErrores.Visible = false;
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrores.Location = new System.Drawing.Point(7, 20);
            this.lblErrores.MaximumSize = new System.Drawing.Size(170, 0);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(34, 13);
            this.lblErrores.TabIndex = 0;
            this.lblErrores.Text = "Error";
            // 
            // grpPerm
            // 
            this.grpPerm.Controls.Add(this.permList);
            this.grpPerm.Location = new System.Drawing.Point(212, 7);
            this.grpPerm.Name = "grpPerm";
            this.grpPerm.Size = new System.Drawing.Size(354, 112);
            this.grpPerm.TabIndex = 6;
            this.grpPerm.TabStop = false;
            this.grpPerm.Text = "Permisos";
            this.grpPerm.Visible = false;
            // 
            // permList
            // 
            this.permList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.entorno,
            this.user,
            this.group,
            this.perms});
            this.permList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permList.Location = new System.Drawing.Point(3, 16);
            this.permList.Name = "permList";
            this.permList.Size = new System.Drawing.Size(348, 93);
            this.permList.TabIndex = 0;
            this.permList.UseCompatibleStateImageBehavior = false;
            this.permList.View = System.Windows.Forms.View.Details;
            // 
            // entorno
            // 
            this.entorno.Text = "Entorno";
            this.entorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // user
            // 
            this.user.Text = "Usuario";
            this.user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // group
            // 
            this.group.Text = "Grupo";
            this.group.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // perms
            // 
            this.perms.Text = "Permisos";
            this.perms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // muestraTexto
            // 
            this.muestraTexto.BackColor = System.Drawing.SystemColors.Window;
            this.muestraTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muestraTexto.Location = new System.Drawing.Point(0, 0);
            this.muestraTexto.Name = "muestraTexto";
            this.muestraTexto.ReadOnly = true;
            this.muestraTexto.Size = new System.Drawing.Size(578, 292);
            this.muestraTexto.TabIndex = 0;
            this.muestraTexto.Text = "";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblName,
            this.lblStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 521);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(842, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblName.Size = new System.Drawing.Size(115, 17);
            this.lblName.Text = "Sicarul TarMaker";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 570);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sicarul TarMaker";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.grpErrores.ResumeLayout(false);
            this.grpErrores.PerformLayout();
            this.grpPerm.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView vistaArchivos;
        private System.Windows.Forms.RichTextBox muestraTexto;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox grpErrores;
        private System.Windows.Forms.GroupBox grpPerm;
        private System.Windows.Forms.ToolStripStatusLabel lblName;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView permList;
        private System.Windows.Forms.ColumnHeader user;
        private System.Windows.Forms.ColumnHeader group;
        private System.Windows.Forms.ColumnHeader perms;
        private System.Windows.Forms.ColumnHeader entorno;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lblNombreProyecto;
        private System.Windows.Forms.Label lblArchivosMigrados;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnRevisarFuentes;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbAyuda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAbout;

    }
}

