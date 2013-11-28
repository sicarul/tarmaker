using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace TarMaker
{
    public partial class MainForm : Form
    {
        public static int SeparadorEjecutables = 1000000;
        public static int MaxSize = 100 * 1024;

        Proyecto miProyecto;
        NuevoProyecto newProj;

        public MainForm()
        {
            InitializeComponent();
            lblDescripcion.Text = "";
            lblArchivosMigrados.Text = "";
            lblErrores.Text = "";
            newProj = new NuevoProyecto();

            this.Show();
            this.tsbLoad.PerformClick();
        }

        private void resetearFormulario()
        {
            string tipo = "";
            if(miProyecto.getTipo() == tipoProyecto.Evolutivo)
                tipo="Evolutivo";
            else if(miProyecto.getTipo() == tipoProyecto.Correctivo)
                tipo="Correctivo";
            this.lblNombreProyecto.Text = tipo + " " + miProyecto.getCodigo();
            this.lblDescripcion.Text = miProyecto.getDescripcion();

            popularDirectorios();
            btnGenerar.Enabled = true;
            btnRevisarFuentes.Enabled = true;

        }


        private void popularDirectorios()
        {
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"res/pre_existente.png")));
            myImageList.Images.Add(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"res/seleccion.png")));
            myImageList.Images.Add(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"res/error.png")));
            myImageList.Images.Add(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"res/archivo.png")));
            myImageList.Images.Add(Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "res/directorio.png")));
            vistaArchivos.ImageList = myImageList;

            vistaArchivos.ImageIndex = 0;
            vistaArchivos.SelectedImageIndex = 1;

            vistaArchivos.Nodes.Clear();
            int cantidadErrores = 0;

            for (int i = 0; i < miProyecto.vectorDirectorios.Count; i++)
            {
                string[] desglosadoRuta = miProyecto.vectorDirectorios[i].ruta.Split("/".ToCharArray());
                for (int j = 1; j < desglosadoRuta.Count<string>(); j++)
                {
                    if (j == 1)
                    {
                        string rutaInicial = "/" + desglosadoRuta[j];
                        if (vistaArchivos.Nodes.Find(rutaInicial, false).Count() == 0)
                        {
                            TreeNode t = new TreeNode();
                            t.Name = rutaInicial;
                            t.Text = desglosadoRuta[j];
                            vistaArchivos.Nodes.Add(t);
                        }
                    }
                    else
                    {
                        StringBuilder rutaCompuesta = new StringBuilder();
                        StringBuilder rutaAnterior = new StringBuilder();
                        for (int k = 1; k <= j; k++)
                        {
                            rutaCompuesta.Append("/" + desglosadoRuta[k]);
                            if (k != j)
                                rutaAnterior.Append("/" + desglosadoRuta[k]);
                        }

                        TreeNode[] ResultadoNodo = vistaArchivos.Nodes.Find(rutaCompuesta.ToString(), true);
                        TreeNode[] NodoAnterior = vistaArchivos.Nodes.Find(rutaAnterior.ToString(), true);
                        if (ResultadoNodo.Count<TreeNode>() == 0) //No existe aun
                        {
                            TreeNode t = new TreeNode();
                            t.Name = rutaCompuesta.ToString();
                            t.Text = desglosadoRuta[j];
                            if (j == desglosadoRuta.Count<string>() - 1)
                                t.ImageIndex = 4;
                            NodoAnterior[0].Nodes.Add(t);
                        }
                        else
                        {
                            if (j == desglosadoRuta.Count<string>() - 1)
                                NodoAnterior[0].ImageIndex = 4;
                        }
                    }
                }
            }

            for(int i = 0; i < miProyecto.vectorArchivos.Count; i++){
                string[] desglosadoRuta = miProyecto.vectorArchivos[i].ruta.Split("/".ToCharArray());
                for (int j = 1; j < desglosadoRuta.Count<string>(); j++)
                {
                    if (j == 1)
                    {
                        string rutaInicial = "/" + desglosadoRuta[j];
                        if (vistaArchivos.Nodes.Find(rutaInicial, false).Count() == 0)
                        {
                            TreeNode t = new TreeNode();
                            t.Name=rutaInicial;
                            t.Text=desglosadoRuta[j];
                            vistaArchivos.Nodes.Add(t);
                        }
                    }
                    else
                    {
                        StringBuilder rutaCompuesta = new StringBuilder();
                        StringBuilder rutaAnterior = new StringBuilder();
                        for (int k = 1; k <= j; k++)
                        {
                            rutaCompuesta.Append("/" + desglosadoRuta[k]);
                            if(k!=j)
                                rutaAnterior.Append("/" + desglosadoRuta[k]);
                        }

                        TreeNode[] ResultadoNodo = vistaArchivos.Nodes.Find(rutaCompuesta.ToString(), true);
                        TreeNode[] NodoAnterior = vistaArchivos.Nodes.Find(rutaAnterior.ToString(), true);
                        if (ResultadoNodo.Count<TreeNode>() == 0) //No existe aun
                        {
                            TreeNode t = new TreeNode();
                            t.Name = rutaCompuesta.ToString();
                            t.Text = desglosadoRuta[j];
                            if (j == desglosadoRuta.Count<string>() - 1)
                            {
                                t.Name = i.ToString();
                                t.ImageIndex = 3;
                                if (miProyecto.vectorArchivos[i].winEnters || miProyecto.vectorArchivos[i].BOM)
                                {
                                    t.ImageIndex = 2;
                                    cantidadErrores++;
                                }
                                
                                t.ForeColor = Color.DarkGreen;
                            }
                            NodoAnterior[0].Nodes.Add(t);
                        }
                    }
                }
            }

            for (int i = 0; i < miProyecto.vectorEjecutables.Count; i++)
            {
                TreeNode t = new TreeNode();
                t.Name = (i + SeparadorEjecutables).ToString();
                t.Text = miProyecto.vectorEjecutables[i].ruta;
                t.ForeColor = Color.DarkMagenta;
                t.ImageIndex = 3;
                if (miProyecto.vectorEjecutables[i].winEnters || miProyecto.vectorEjecutables[i].BOM)
                {
                    t.ImageIndex = 2;
                    cantidadErrores++;
                }
                vistaArchivos.Nodes.Add(t);
            }


            lblArchivosMigrados.Text = "Se migraran " + miProyecto.vectorArchivos.Count.ToString() +" archivos.";
            if(miProyecto.vectorDirectorios.Count > 0)
                lblArchivosMigrados.Text += " Se crearan " + miProyecto.vectorDirectorios.Count.ToString() + " directorios.";
            if(miProyecto.vectorEjecutables.Count > 0)
                lblArchivosMigrados.Text += " Se ejecutaran " + miProyecto.vectorEjecutables.Count.ToString() + " scripts.";

            lblStatus.Text = "Se cargo sin errores el proyecto.";
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Regular);
            if (cantidadErrores > 0)
            {
                lblStatus.Text = "Se encontraron " + cantidadErrores + " archivos con posibles errores, por favor reviselos.";
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            vistaArchivos.ExpandAll();
        }

        private void vistaArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblErrores.Text = "";
            grpErrores.Hide();
            grpPerm.Hide();
            muestraTexto.Text = "";
            muestraTexto.Enabled = false;
            int n;
            directorio dirProcesado = new directorio();
            
            if (int.TryParse(e.Node.Name,out n) == true)
            {
                /*
                 ¿Es un archivo?
                 */
                if (n < SeparadorEjecutables)
                {
                    archivo miFile = miProyecto.vectorArchivos[n];
                    string archivo = miFile.rutadisco;
                    try
                    {
                        permList.Items.Clear();

                        foreach (Entorno ent in miProyecto.PerfilUtilizado.entornos)
                        {
                            string[] vals = new string[4];
                            vals[0] = ent.Nombre();
                            vals[1]=ent.getUsuarioMapeado(miFile.owner);
                            vals[2] = ent.getGrupoMapeado(miFile.grupo);
                            vals[3] =  miFile.permisos;
                            ListViewItem ni = new ListViewItem(vals);
                            permList.Items.Add(ni);
                        }

                        lblErrores.Text="";
                        grpPerm.Show();

                        if (miFile.winEnters)
                        {
                            lblErrores.Text += "Cuidado: El archivo tiene enters de Windows.\n";
                            grpErrores.Show();
                        }
                        if (miFile.BOM)
                        {
                            lblErrores.Text += "Cuidado: El archivo tiene Byte Order Mark (BOM)";
                            grpErrores.Show();
                        }

                        System.IO.TextReader lector = new System.IO.StreamReader(archivo);

                        string S = lector.ReadLine();
                        while (S != null)
                        {
                            muestraTexto.AppendText(S + '\n');
                            S = lector.ReadLine();
                        }

                        lector.Close();
                        muestraTexto.Enabled = true;
                    }
                    catch (System.IO.IOException)
                    {
                        lblErrores.Text = "No puede abrir el archivo " + archivo + " - Puede que este no exista o este abierto en otro programa.";
                        grpErrores.Show();
                    }
                }
                /*
                 ¿Es un ejecutable?
                 */
                else if (n >= SeparadorEjecutables)
                {
                    archivo ejecutable = miProyecto.vectorEjecutables[n - SeparadorEjecutables];
                    string archivo = ejecutable.rutadisco;
                    try
                    {
                        if (ejecutable.winEnters)
                        {
                            lblErrores.Text = "Cuidado: El archivo tiene enters de Windows.";
                            grpErrores.Show();
                        }

                        FileInfo f = new FileInfo(archivo);

                        if (f.Length > MaxSize)
                        {
                            muestraTexto.AppendText("El archivo supera los 100Kb, no se mostrara en esta aplicacion");
                        }
                        else
                        {

                            System.IO.TextReader lector = new System.IO.StreamReader(archivo);

                            string S = lector.ReadLine();
                            while (S != null)
                            {
                                muestraTexto.AppendText(S + '\n');
                                S = lector.ReadLine();
                            }

                            lector.Close();
                        }
                        muestraTexto.Enabled = true;
                    }
                    catch (System.IO.IOException)
                    {
                        lblErrores.Text = "No puede abrir el archivo " + archivo + " - Puede que este no exista o este abierto en otro programa.";
                        grpErrores.Show();
                    }
                }
            }
            /*
             ¿Es un directorio a crear?
             */
            else if (miProyecto.getDirectorioPorRuta(e.Node.Name, out dirProcesado))
            {
                permList.Items.Clear();

                foreach (Entorno ent in miProyecto.PerfilUtilizado.entornos)
                {
                    string[] vals = new string[4];
                    vals[0] = ent.Nombre();
                    vals[1] = ent.getUsuarioMapeado(dirProcesado.owner);
                    vals[2] = ent.getGrupoMapeado(dirProcesado.grupo);
                    vals[3] = dirProcesado.permisos;
                    ListViewItem ni = new ListViewItem(vals);
                    permList.Items.Add(ni);
                }
                grpPerm.Show();
            }
            /*
             ¿Es un directorio preexistente?
             */
            else
            {
                /* Por ahora no hacemos nada */
            }
        }



        private void btnSubirFuentes_Click(object sender, EventArgs e)
        {
            frmRevisarFuentesDimensions sf = new frmRevisarFuentesDimensions();
            if(sf.cargarProyecto(miProyecto))
                sf.ShowDialog();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Proyecto tProyecto = new Proyecto();
            newProj.cambiarReferencia(ref tProyecto);
            newProj.ShowDialog();
            if (tProyecto.inicializado() == 0)
            {
                miProyecto = tProyecto;
                resetearFormulario();
                if (Logeador.Instance.cantidadMensajes() > 0)
                {
                    ResultadosProyecto RP = new ResultadosProyecto();
                    RP.cargarResultados(Logeador.Instance.obtenerMensajes());
                    RP.ShowDialog();
                }
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Ayuda ay = new Ayuda();
            ay.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            if (miProyecto.generarInstalador())
                MessageBox.Show("El instalador se ha generado en " + miProyecto.getCarpeta() + "\\Instalador");
            else
                MessageBox.Show("No se pudo generar el instalador. Si se registraron errores se mostraran a continuacion.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (Logeador.Instance.cantidadMensajes() > 0)
            {
                ResultadosProyecto RP = new ResultadosProyecto();
                RP.cargarResultados(Logeador.Instance.obtenerMensajes());
                RP.ShowDialog();
            }
        }



       
    }
}
