using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using TarMaker.WebDimensions;

namespace TarMaker
{
    class Dimensions
    {

        dmwebservices ws;
        public Dimensions()
        {
            ws = new dmwebservices();            
            WebProxy wp = new WebProxy();
            ws.Proxy = wp;
            ws.UserAgent = "Tarmaker";
            ws.AllowAutoRedirect = true;
        }


        private ConnectionDetails DetallesConexion
        {
            get
            {
                ConnectionDetails ConDet = new ConnectionDetails();
                ConDet.username = Credenciales.Instance.getUser();
                ConDet.password = Credenciales.Instance.getPass();
                ConDet.server = Credenciales.Instance.getHost();
                ConDet.dbConnection = Credenciales.Instance.getDB();

                return ConDet;
            }
        }


        private string ConvertirRutaADimensions(Proyecto Proy, string ruta, bool Dir)
        {
            ws.Url = Credenciales.Instance.getURL();

            string Convertido = Proy.PerfilUtilizado.rutaVersionadorFuentes() + ruta.Trim('/').Replace("/", "\\");
            if (Dir)
            {
                string[] list = Convertido.Split('\\');
                StringBuilder f = new StringBuilder();
                for (int i = 0; i < list.Length - 1; i++) //Se descarta el ultimo item(el archivo) al hacer list.length - 1
                {
                    f.Append(list[i]).Append("\\");
                }
                return f.ToString();
            }
            else
            {
                return Convertido;
            }
        }

        public List<ArchivoDimensions> listaArchivos(Proyecto Proy)
        {
            List<ArchivoDimensions> lista = new List<ArchivoDimensions>();


            int index = 0;
            for (int i = 0; i < Proy.vectorArchivos.Count; i++)
            {

                ArchivoDimensions Arch = new ArchivoDimensions();
                Arch.archivo = ConvertirRutaADimensions(Proy, Proy.vectorArchivos[i].ruta, false);
                Arch.ubicacion = Proy.vectorArchivos[i].rutadisco;
                Arch.ultima_modificacion = DateTime.MinValue;
                Arch.diferencias = DIFERENCIA_DIMENSIONS.NoExiste;
                Arch.id = index;
                index++;

                try
                {
                    ItemFileFolder[] items;
                    ws.getItems(
                        DetallesConexion,
                        Proy.PerfilUtilizado.proyectoSegunVersionador(),
                        null,
                        ConvertirRutaADimensions(Proy, Proy.vectorArchivos[i].ruta, true),
                        new string[] { ConvertirRutaADimensions(Proy, Proy.vectorArchivos[i].ruta, false) },
                        null,
                        null,
                        null,
                        null,
                        null,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        true,
                        true,
                        out items
                        );

                    foreach (ItemFileFolder ItFilFol in items)
                    {
                        if (ItFilFol.file != null)
                        {
                            foreach (ItemFile ItFil in ItFilFol.file)
                            {
                                string[] splitRuta = Proy.vectorArchivos[i].ruta.Split('/');
                                if (ItFil.name == splitRuta[splitRuta.Length - 1])
                                {
                                    Arch.ultima_modificacion = ItFil.modificationTime;
                                    Arch.contenido = ItFil.fileContents;
                                    
                                    string TempDir = System.Environment.GetEnvironmentVariable("TEMP");

                                    try
                                    {
                                        BinaryReader newFile = new BinaryReader(File.Open(Arch.ubicacion, FileMode.Open));
                                        byte[] contentsFile = new byte[newFile.BaseStream.Length];
                                        contentsFile = newFile.ReadBytes((int)newFile.BaseStream.Length);
                                        newFile.Close();
                                        
                                        if (Utilitarios.ArraysIguales(contentsFile, ItFil.fileContents))
                                        {
                                            Arch.diferencias = DIFERENCIA_DIMENSIONS.Iguales;
                                        }
                                        else
                                        {
                                            Arch.diferencias = DIFERENCIA_DIMENSIONS.DiffDistinto;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Arch.diferencias = DIFERENCIA_DIMENSIONS.ErrorComparacion;
                                    }

                                    break;
                                }
                            }

                        }
                    }
                }
                catch (WebException ex)
                {
                    ManejarWebException(ex);
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    ManejarSOAPException(ex);
                }

                lista.Add(Arch);

            }

            return lista;


        }

        public bool conexion()
        {
            ws.Url = Credenciales.Instance.getURL();
            try
            {
                /* Para probar la conexion pedimos la version de Dimensions */
                string high, low;
                ws.getVersion(DetallesConexion, out high, out low);
            }
            catch (WebException ex)
            {
                ManejarWebException(ex);
                return false;
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                ManejarSOAPException(ex);
                return false;
            }
            return true;
        }

        private void ManejarWebException(WebException ex)
        {
            if (ex.Response != null)
            {
                var resp = (HttpWebResponse)ex.Response;
                if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
                {
                    Credenciales.Instance.SetError("ERROR conectandose a Dimensions: 404 pagina no encontrada");
                }
                else if (resp.StatusCode == HttpStatusCode.InternalServerError) // HTTP 500
                {
                    Credenciales.Instance.SetError("ERROR conectandose a Dimensions: 500 error interno del servidor");
                }
                else
                {
                    Credenciales.Instance.SetError("ERROR conectandose a Dimensions: codigo del error: " + resp.StatusCode);
                }
            }
            else
            {
                Credenciales.Instance.SetError("ERROR conectandose a Dimensions: " + ex.Message);
            }
        }

        private void ManejarSOAPException(System.Web.Services.Protocols.SoapException ex)
        {
            Credenciales.Instance.SetError("Revise las credenciales ingresadas, el servidor devolvio el error: " + ex.Message);
        }


    }
}
