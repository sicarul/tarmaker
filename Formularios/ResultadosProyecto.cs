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
    public partial class ResultadosProyecto : Form
    {
        public ResultadosProyecto()
        {
            InitializeComponent();
        }

        public void cargarResultados(List<string> errores)
        {
            listResultados.Items.Clear();
            if (errores.Count == 0)
                this.Close();
            else
            {
                foreach (string err in errores)
                {
                    listResultados.Items.Add(err);
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
