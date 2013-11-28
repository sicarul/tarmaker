using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TarMaker
{
    public partial class NuevoProyecto : Form
    {
        private OpenFileDialog selectorCarpetas;
        private Proyecto mProyecto;

        public NuevoProyecto()
        {
            InitializeComponent();
            selectorCarpetas = new OpenFileDialog();
            this.selectorCarpetas.Title = "Busque el archivos.csv que deberia estar dentro de la carpeta donde estan los fuentes de su evolutivo.";
            this.selectorCarpetas.Multiselect = false;
            this.selectorCarpetas.Filter = "archivos.csv|archivos.csv";
            this.selectorCarpetas.RestoreDirectory = true;
            this.selectorCarpetas.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string defDir = Utilitarios.getKey(Utilitarios.RUTA_REGISTRO, "RutaBuscarProyecto");
            if(defDir != "")
                this.selectorCarpetas.InitialDirectory = defDir;
            this.cbPerfil.Items.AddRange(Perfil.listaPerfiles().ToArray());

        }

        public void cambiarReferencia(ref Proyecto miProyecto){
            mProyecto = miProyecto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cbPerfil.Text.Equals(""))
            {
                MessageBox.Show("Por favor elija el Perfil a utilizar, el mismo define a que servidor/es se instalara el paquete generado", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPerfil.Focus();
                return;
            }

            mProyecto.inicializar();

            if (cbTipo.Text == "Evolutivo")
                mProyecto.setTipo(tipoProyecto.Evolutivo);
            else if (cbTipo.Text == "Correctivo")
                mProyecto.setTipo(tipoProyecto.Correctivo);

            mProyecto.setCodigo(this.tbEvolutivo.Text);
            mProyecto.setCarpeta(this.tbCarpeta.Text);
            mProyecto.setDescripcion(this.tbDescripcion.Text);
            mProyecto.setPerfil(this.cbPerfil.Text);

            int resultado = mProyecto.cargarProyecto();

            if (resultado == 0)
            {
                Utilitarios.setKey(Utilitarios.RUTA_REGISTRO, "RutaBuscarProyecto", tbCarpeta.Text);
                this.Close();
            }
            else
            {
                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Por favor ingrese un tipo de proyecto", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbTipo.Focus();
                        break;
                    case 2:
                        MessageBox.Show("Por favor ingrese el codigo en SBM del proyecto, si el evolutivo es el E00030174, entonces el codigo seria 30174, si es una version de fix se recomienda usar el codigo con v1-v2-v3-etc segun corresponda al final", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbEvolutivo.Focus();
                        break;
                    case 3:
                        MessageBox.Show("Por favor seleccione la carpeta donde se encuentran los archivos del evolutivo", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBuscar.Focus();
                        break;
                    case 4:
                        MessageBox.Show("Por favor tenga en cuenta dejar en el directorio del evolutivo el archivo archivos.csv que contenga los archivos a migrar, y que este no este abierto en otro programa, el separador del archivo debe ser el punto y coma: ;", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 5:
                        MessageBox.Show("Por favor tenga en cuenta dejar en el directorio del evolutivo el archivo directorios.csv que contenga los directorios a crear, y que este no este abierto en otro programa, el separador del archivo debe ser el punto y coma: ;. En caso de no querer crear ningun directorio, debe crearlo solamente con una fila de encabezado.", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 6:
                        MessageBox.Show("Por favor tenga en cuenta dejar en el directorio del evolutivo el archivo ejecutables.csv que contenga los scripts a ejecutar, y que este no este abierto en otro programa, el separador del archivo debe ser el punto y coma: ;. En caso de no querer ejecutar ningun script, debe crearlo solamente con una fila de encabezado.", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Ocurrio un error desconocido", "No se pudo cargar el proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = selectorCarpetas.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                tbCarpeta.Text = System.IO.Path.GetDirectoryName(selectorCarpetas.FileName);
                CargarParametros(tbCarpeta.Text);
            }
        }

        private void CargarParametros(string ruta)
        {
            try
            {
                XmlReader lectorXML = XmlReader.Create(ruta + "\\Parametros.tm");

                while (lectorXML.Read())
                {
                    if (lectorXML.NodeType == XmlNodeType.Element && lectorXML.Name.ToUpper() == "PARAMETROS")
                    {
                        while (lectorXML.Read())
                        {
                            if(lectorXML.NodeType == XmlNodeType.Element && !lectorXML.IsEmptyElement)
                            {
                                string name = lectorXML.Name;
                                string value = lectorXML.ReadElementContentAsString();
                                switch (name.ToUpper())
                                {
                                    case "PERFIL":
                                        if (cbPerfil.Items.Contains(value))
                                            cbPerfil.SelectedItem= value;
                                        break;
                                    case "TIPO":
                                        if (value == "Evolutivo" || value == "Correctivo")
                                            cbTipo.SelectedItem = value;
                                        break;
                                    case "ETIQUETA":
                                        tbEvolutivo.Text = value;
                                        break;
                                    case "NOMBRE":
                                        tbDescripcion.Text = value;
                                        break;
                                }
                                
                            }
                        }
                    }
                    
                }
                lectorXML.Close();
            }
            catch (Exception)
            {
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.SelectedItem.ToString() == "Evolutivo")
                this.lblCodEvoCor.Text = "E";
            else
                this.lblCodEvoCor.Text = "C";
        }




    }
}
