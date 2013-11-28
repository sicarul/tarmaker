using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TarMaker
{
    public partial class frmRevisarFuentesDimensions : Form
    {

        private Proyecto miProyecto;
        private List<ArchivoDimensions> archivos;

        public frmRevisarFuentesDimensions()
        {
            InitializeComponent();
        }

        private void frmSubirFuentes_Load(object sender, EventArgs e)
        {
        }

        public bool cargarProyecto(Proyecto p)
        {
            miProyecto = p;

            if (!Credenciales.Instance.GetLoginCorrecto())
            {
                DimensionsAcciones DA = new DimensionsAcciones();
                DA.setAccion("Listar archivos a subir");
                DA.ShowDialog();
                if (!Credenciales.Instance.GetLoginCorrecto())
                    return false;
            }

            Dimensions dm = new Dimensions();

            archivos = dm.listaArchivos(miProyecto);

            lstArch.Items.Clear();
            foreach (ArchivoDimensions arch in archivos)
            {
                string[] serialize = new string[5];
                serialize[0] = arch.archivo;
                serialize[1] = Utilitarios.TextoDiferencia(arch.diferencias);
                if (arch.ultima_modificacion == DateTime.MinValue)
                    serialize[2] = "N/A";
                else
                    serialize[2] = arch.ultima_modificacion.ToShortDateString() + " " + arch.ultima_modificacion.ToShortTimeString();


                ListViewItem lvi = new ListViewItem(serialize);
                lvi.Tag = arch.id;

                lstArch.Items.Add(lvi);
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void lstArch_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                ListView Lista = sender as ListView;

                foreach (ArchivoDimensions arch in archivos)
                {
                    if (arch.id == Convert.ToInt32(Lista.SelectedItems[0].Tag))
                    {
                        if (arch.diferencias == DIFERENCIA_DIMENSIONS.DiffDistinto)
                        {
                            MostrarDiff md = new MostrarDiff();

                            BinaryReader newFile = new BinaryReader(File.Open(arch.ubicacion, FileMode.Open));
                            byte[] contentsFile = new byte[newFile.BaseStream.Length];
                            contentsFile = newFile.ReadBytes((int)newFile.BaseStream.Length);
                            newFile.Close();

                            md.cargarDiff(arch.contenido, contentsFile);
                            md.Show();
                        }
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo mostrar el Diff entre el archivo local y el de Dimensions, la excepcion fue: " + ex.Message  );
            }
        }



    }
}
