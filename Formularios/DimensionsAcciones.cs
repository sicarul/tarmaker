using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TarMaker
{
    public partial class DimensionsAcciones : Form
    {
        public DimensionsAcciones()
        {
            InitializeComponent();
            tbUser.Text = Credenciales.Instance.getUser();
            tbHost.Text = Credenciales.Instance.getHost();
            tbDB.Text = Credenciales.Instance.getDB();
            tbDimensionsRuta.Text = Credenciales.Instance.getURL();
        }

        public void setAccion(string accion){
            lblAccion.Text = accion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Credenciales.Instance.setUser(tbUser.Text);
            Credenciales.Instance.setPass(tbPass.Text);
            Credenciales.Instance.setHost(tbHost.Text);
            Credenciales.Instance.setDB(tbDB.Text);
            Credenciales.Instance.setURL(tbDimensionsRuta.Text);

            if (Credenciales.Instance.GetLoginCorrecto())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(Credenciales.Instance.GetError(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DimensionsAcciones_Shown(object sender, EventArgs e)
        {
            tbPass.Focus();
        }
    }
}
