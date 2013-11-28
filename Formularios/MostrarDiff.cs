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
    public partial class MostrarDiff : Form
    {
        public MostrarDiff()
        {
            InitializeComponent();
        }

        public void cargarDiff(byte[] a, byte[] b)
        {
            string TextoA = System.Text.Encoding.Default.GetString(a);
            string TextoB = System.Text.Encoding.Default.GetString(b);

            diff_match_patch dmp = new diff_match_patch();

            wbDiffViewer.DocumentText = dmp.diff_prettyHtml(dmp.diff_main(TextoA, TextoB));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
