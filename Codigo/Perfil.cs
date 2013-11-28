using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace TarMaker
{
    public class Perfil
    {
        string mNombre;
        string pathImplementacion;
        string pathVersionadorImplementacion;
        string pathVersionadorFuentes;
        string ProyectoVersionador;
        string eProductivo;
        public List<Entorno> entornos;

        public string nombre
        {

            get { return mNombre; }

        }

        public static string rutaPerfiles()
        {
            string rutaPerfiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Perfiles_Tarmaker");
            if (!Directory.Exists(rutaPerfiles))
                Directory.CreateDirectory(rutaPerfiles);
            return rutaPerfiles;
        }

        public static List<string> listaPerfiles()
        {
            List<string> tmpPerfiles;
            tmpPerfiles = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(rutaPerfiles());
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if(d.Name.ToLower() != "templates")
                    tmpPerfiles.Add(d.Name);
            }

            return tmpPerfiles;
        }

        public Perfil(string pNombre)
        {
            mNombre = pNombre;
            entornos = new List<Entorno>();
            if (!cargarPerfil())
            {
                crearPerfil();
            }
        }

        public bool existePerfil(string NombrePerfil)
        {
            foreach (Entorno e in entornos)
            {
                if (e.Nombre().Equals(NombrePerfil))
                    return true;
            }
            return false;
        }

        public void agregarPerfil(string NombrePerfil)
        {
            if(!existePerfil(NombrePerfil))
                entornos.Add(new Entorno(NombrePerfil, mNombre));
        }

        private void crearPerfil()
        {
            if(!Directory.Exists(rutaPerfiles()))
                Directory.CreateDirectory(rutaPerfiles());
            Directory.CreateDirectory(rutaPerfil());
            File.Create(System.IO.Path.Combine(rutaPerfil(), "rutaImplementacion.txt"));
            eProductivo = "";
        }

        private bool cargarPerfil()
        {
            if(!Directory.Exists(rutaPerfil()))
                return false;


            eProductivo = leerConfig("productivo.txt");
            pathImplementacion = leerConfig("rutaImplementacion.txt");
            pathVersionadorImplementacion = leerConfig("rutaVersionadorImplementacion.txt");
            pathVersionadorFuentes = leerConfig("rutaVersionadorFuentes.txt");
            ProyectoVersionador = leerConfig("ProyectoVersionador.txt");

            char[] barrasTrimEnd = {'/','\\'};
            pathImplementacion = pathImplementacion.TrimEnd(barrasTrimEnd) + "/";
            pathVersionadorImplementacion = pathVersionadorImplementacion.TrimEnd(barrasTrimEnd) + "\\";
            pathVersionadorFuentes = pathVersionadorFuentes.TrimEnd(barrasTrimEnd) + "\\";
            

            DirectoryInfo dir = new DirectoryInfo(rutaPerfil());
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (!d.Name.ToUpper().Equals("TEMPLATES"))
                {
                    entornos.Add(new Entorno(d.Name, mNombre));
                    if (d.Name.ToUpper().Equals(eProductivo.ToUpper()))
                        entornos[entornos.Count - 1].setProductivo(true);
                }
            }


            return true;
        }


        private string rutaPerfil()
        {
            return Path.Combine(rutaPerfiles(), mNombre);
        }

        public string rutaImplementacion()
        {
            return pathImplementacion;
        }

        public string rutaVersionadorImplementacion()
        {
            return pathVersionadorImplementacion;
        }

        public string rutaVersionadorFuentes()
        {
            return pathVersionadorFuentes;
        }


        public string proyectoSegunVersionador()
        {
            return ProyectoVersionador;
        }

        
        public string getTemplateInstalador(Entorno e)
        {
            string ruta = e.getTemplateInstalador();
            if (ruta != null)
                return ruta;
            else
            {
                string ruta2 = Path.Combine(Path.Combine(rutaPerfil(), "templates"), "instalador.sh");
                if (File.Exists(ruta2))
                    return ruta2;
                else
                    return Path.Combine(Path.Combine(rutaPerfiles(), "templates"), "instalador.sh");
            }
        }

        public string getTemplateSolicitud(Entorno e)
        {
                
            string ruta = e.getTemplateSolicitud();
            if (ruta != null)
                return ruta;
            else
            {
                string ruta2 = Path.Combine(Path.Combine(rutaPerfil(), "templates"),"solicitudes.html");
                if (File.Exists(ruta2))
                    return ruta2;
                else
                    return Path.Combine(Path.Combine(rutaPerfiles(), "templates"), "solicitudes.html");
            }
        }

        public string leerConfig(string archivo)
        {
            try
            {
                TextReader lector = new StreamReader(System.IO.Path.Combine(rutaPerfil(), archivo));
                string Conf = lector.ReadLine();
                lector.Close();

                return Conf;
            }
            catch (IOException err)
            {
                Logeador.Instance.log("Error en leerRuta: " + err.ToString());
            }
            return "";
        }
        
    }
}
