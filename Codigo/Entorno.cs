using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace TarMaker
{
    public class Entorno
    {
        List<mapeo> vectorMapeoUsuarios;
        List<mapeo> vectorMapeoGrupos;
        List<mapeo> vectorMapeoDirectorios;
        String mNombre;
        String mPerfil;
        bool productivo;

        public Entorno(string pNombre, string pPerfil)
        {
            mNombre = pNombre;
            mPerfil = pPerfil;
            vectorMapeoUsuarios = new List<mapeo>();
            vectorMapeoGrupos = new List<mapeo>();
            vectorMapeoDirectorios = new List<mapeo>();
            setProductivo(false);

            if (!existeEntorno())
            {
                crearEntorno();
            }
            else
            {
                cargarEntorno();
            }
        }

        public void setProductivo(bool pProd)
        {
            productivo = pProd;
        }

        public bool getProductivo()
        {
            return productivo;
        }

        public string Nombre()
        {
            return mNombre;
        }

        private bool existeEntorno()
        {
            return Directory.Exists(rutaEntorno());
        }

        private void crearEntorno()
        {
            Directory.CreateDirectory(rutaEntorno());
        }

        private bool cargarEntorno()
        {
            if (cargarMapeoDirectorios() && cargarMapeoGrupos() && cargarMapeoUsuarios())
                return true;
            else
            {
                Logeador.Instance.log("Error cargando entorno " + mNombre + " del perfil " + mPerfil);
                return false;
            }
        }

        private string rutaEntorno()
        {
            return Path.Combine(Path.Combine(Perfil.rutaPerfiles(), mPerfil),mNombre);
        }

        public string leerRuta()
        {
            try
            {
                TextReader lector = new StreamReader(Path.Combine(rutaEntorno(), "rutaImplementacion.txt"));
                string ruta = lector.ReadLine();
                lector.Close();

                return ruta;
            }
            catch (IOException err)
            {
                Console.WriteLine("Error en leerRuta: {0}", err.ToString());
            }
            return "/sasFiles/Implementacion/";
        }

        public void escribirRuta(string ruta)
        {
            try
            {
                TextWriter escritor = new StreamWriter(Path.Combine(rutaEntorno(), "rutaImplementacion.txt"));
                escritor.WriteLine(ruta);
                escritor.Close();
            }
            catch (IOException err)
            {
                Console.WriteLine("Error en leerRuta: {0}", err.ToString());
            }
        }


        private bool cargarMapeoUsuarios()
        {
            try
            {
                TextReader lector = new StreamReader(Path.Combine(rutaEntorno(), "mapeo_usuarios.csv"));

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0] != '#')
                    {
                        string[] Temp = new string[2];
                        Temp = S.Split(";".ToCharArray());
                        agregarMapeo(Temp[0], Temp[1], ref vectorMapeoUsuarios);
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo de mapeo de usuarios de produccion a desarrollo.");
            }
            return false;
        }

        private bool cargarMapeoGrupos()
        {
            try
            {
                TextReader lector = new StreamReader(Path.Combine(rutaEntorno(), "mapeo_grupos.csv"));

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0] != '#')
                    {
                        string[] Temp = new string[2];
                        Temp = S.Split(";".ToCharArray());
                        agregarMapeo(Temp[0], Temp[1], ref vectorMapeoGrupos);
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo de mapeo de usuarios de produccion a desarrollo.");
            }
            return false;
        }

        private bool cargarMapeoDirectorios()
        {
            try
            {
                TextReader lector = new StreamReader(Path.Combine(rutaEntorno(), "mapeo_directorios.csv"));

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0] != '#')
                    {
                        string[] Temp = new string[2];
                        Temp = S.Split(";".ToCharArray());
                        agregarMapeo(Temp[0], Temp[1], ref vectorMapeoDirectorios);
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                 return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo de mapeo de directorios de produccion a desarrollo.");
            }
            return false;
        }


        private bool agregarMapeo(string original, string destino, ref List<mapeo> lista)
        {
            if (original.Trim().Equals("") || destino.Trim().Equals(""))
            {

                Logeador.Instance.log("ERROR: Se encontro un nombre vacio en el csv de ejecutables");
                return false;
            }

            try
            {
                mapeo t = new mapeo();
                t.original = original;
                t.destino = destino;
                lista.Add(t);
                return true;
            }
            catch (Exception) { return false; }
        }


       
        public string getUsuarioMapeado(string usuario)
        {
            foreach (mapeo usermap in vectorMapeoUsuarios)
            {
                if (usermap.original == usuario)
                    return usermap.destino;
            }

            if(!getProductivo())
                Logeador.Instance.log("Aviso: No se encontro un mapeo en el entorno " + mNombre + " para el usuario " + usuario + " - Se usa el mismo");
            return usuario;
        }

        public string getGrupoMapeado(string grupo)
        {
            foreach (mapeo groupmap in vectorMapeoGrupos)
            {
                if (groupmap.original == grupo)
                    return groupmap.destino;
            }
            if(!getProductivo())
                Logeador.Instance.log("Aviso: No se encontro un mapeo en el entorno " + mNombre + " para el grupo " + grupo + " - Se usa el mismo");
            return grupo;
        }

        public string getDirectorioMapeado(string directorio)
        {
            foreach (mapeo dirMap in vectorMapeoDirectorios)
            {
                if (directorio.Contains(dirMap.original))
                    return directorio.Replace(dirMap.original, dirMap.destino);
            }
            return directorio;
        }

        public string getTemplateInstalador()
        {
            string ruta = Path.Combine(Path.Combine(rutaEntorno(), "templates"),"instalador.sh");
            if(File.Exists(ruta))
                return ruta;
            else
                return null;
        }

        public string getTemplateSolicitud()
        {
            string ruta = Path.Combine(Path.Combine(rutaEntorno(), "templates"),"solicitudes.html");
            if(File.Exists(ruta))
                return ruta;
            else
                return null;
        }

    }
}
