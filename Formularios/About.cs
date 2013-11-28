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
    public partial class About : Form
    {
        //bool HaciaDerecha;
        int offset;

        public About()
        {
            InitializeComponent();
            //HaciaDerecha = true;
            offset = lblMovil.Left;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://tarmaker.sicarul.com.ar");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Licencia lic = new Licencia();
            lic.ShowDialog();
        }

    }
}
