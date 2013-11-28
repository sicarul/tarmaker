using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TarMaker
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
            System.Uri myUri = new Uri(System.IO.Path.Combine(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Manual"), "Manual.html"));
            this.wbBrowser.Url = myUri;
        }

    }
}
