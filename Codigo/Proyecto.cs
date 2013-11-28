using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Tar;

namespace TarMaker
{
    


    public class Proyecto
    {
        tipoProyecto tipoDelProyecto;
        string codigo;
        string carpeta;
        string descripcion;
        public List<archivo> vectorArchivos;
        public List<directorio> vectorDirectorios;
        public List<archivo> vectorEjecutables;
        int mInicializado;
        public Perfil PerfilUtilizado;

        public Proyecto()
        {
            inicializar();
        }

        public void inicializar()
        {
            tipoDelProyecto = tipoProyecto.Indefinido;
            codigo = "";
            carpeta = "";
            descripcion = "";
            vectorArchivos = new List<archivo>();
            vectorDirectorios = new List<directorio>();
            vectorEjecutables = new List<archivo>();
            
            mInicializado = 1;
        }

        public void setPerfil(string nombrePerfil)
        {
            PerfilUtilizado = new Perfil(nombrePerfil);
        }

        private bool cargarArchivos()
        {
            try
            {
                TextReader lector = new StreamReader(this.carpeta + "\\archivos.csv");

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0] != '#')
                    {
                        string[] Temp = new string[4];
                        Temp = S.Split(";".ToCharArray());
                        agregarArchivo(Temp[0].Trim(new char[] { ' ' }), Temp[1], Temp[2], Temp[3]);
                            
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo archivos.csv");
            }
            return false;
        }

        private bool cargarDirectorios()
        {
            try
            {
                TextReader lector = new StreamReader(this.carpeta + "\\directorios.csv");

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0] != '#')
                    {
                        string[] Temp = new string[4];
                        Temp = S.Split(";".ToCharArray());
                        agregarDirectorio(Temp[0].TrimEnd(new char[] { '/' }).Trim(new char[] { ' ' }), Temp[1], Temp[2], Temp[3]);
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo directorios.csv");
            }
            return false;
        }

        private bool cargarEjecutables()
        {
            try
            {
                TextReader lector = new StreamReader(this.carpeta + "\\ejecutables.csv");

                string S = lector.ReadLine();
                while (S != null)
                {
                    if (S[0]!='#')
                    {
                        agregarEjecutable(S.Trim(new char[] { ' ' }));
                    }
                    S = lector.ReadLine();
                }

                lector.Close();
                return true;
            }
            catch (IOException) {
                Logeador.Instance.log("ERROR: No se pudo leer el archivo ejecutables.csv");
            }
            return false;
        }

        private void guardarDatosProyecto()
        {
            try
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                XmlWriter escritorXML = XmlWriter.Create(this.carpeta + "\\Parametros.tm", ws);

                escritorXML.WriteStartDocument();

                escritorXML.WriteStartElement("Parametros");
                escritorXML.WriteElementString("Perfil", PerfilUtilizado.nombre);
                escritorXML.WriteElementString("Tipo", tipoDelProyecto.ToString());
                escritorXML.WriteElementString("Etiqueta", codigo);
                escritorXML.WriteElementString("Nombre", descripcion);
                escritorXML.WriteEndElement();

                escritorXML.WriteEndDocument();
                escritorXML.Close();

            }
            catch (Exception)
            {
            }
        }


        private bool agregarArchivo(string ruta, string owner, string grupo, string permisos)
        {
            if (ruta.Trim().Equals(""))
                return false;
            if (owner.Trim().Equals("") || grupo.Trim().Equals("") || permisos.Trim().Equals(""))
            {
                Logeador.Instance.log("ERROR: Se detecto uno o mas campos invalidos en el archivo: '" + ruta + "' con dueño '" + owner + "', grupo '" + grupo + "' y permisos '" + permisos + "'");
                return false;
            }

            archivo t;
            t.ruta = ruta;
            t.rutadisco = getCarpeta() + ruta.Replace("/", "\\");
            t.owner = owner;
            t.grupo = grupo;
            t.permisos = permisos;
            t.winEnters = false;
            t.BOM = false;


            try
            {
                
                if (IsText(t.rutadisco))
                {
                    TextReader leerTexto = new StreamReader(t.rutadisco);
                    string textoFile = leerTexto.ReadToEnd();
                    leerTexto.Close();

                    if (textoFile.Contains('\r'))
                        t.winEnters = true;

                    if (getEncodingBOM(t.rutadisco) != Encoding.ASCII)
                        t.BOM = true;
                }

                vectorArchivos.Add(t);
                return true;
            }
            catch (IOException) {
                Logeador.Instance.log("ERROR: No se pudo cargar el archivo: " + t.rutadisco);
                return false;
            }
        }

        private bool agregarDirectorio(string ruta, string owner, string grupo, string permisos)
        {
            if (ruta.Trim().Equals(""))
                return false;
            if (owner.Trim().Equals("") || grupo.Trim().Equals("") || permisos.Trim().Equals(""))
            {
                Logeador.Instance.log("ERROR: Se detecto uno o mas campos invalidos en el directorio: '" + ruta + "' con dueño '" + owner + "', grupo '" + grupo + "' y permisos '" + permisos + "'");
                return false;
            }

            directorio t;
            t.ruta = ruta;
            t.rutadisco = getCarpeta() + ruta.Replace("/", "\\");
            t.owner = owner;
            t.grupo = grupo;
            t.permisos = permisos;
                
            vectorDirectorios.Add(t);
            return true;
        }

        private bool agregarEjecutable(string nombre)
        {
            if (nombre.Trim().Equals(""))
                return false;

            archivo t;
            t.ruta = nombre;
            t.rutadisco = getCarpeta() + "\\" + nombre;
            t.owner = "";
            t.grupo = "";
            t.permisos = "";
            t.winEnters = false;
            t.BOM = false;

            try
            {

                if (IsText(t.rutadisco))
                {
                    TextReader leerTexto = new StreamReader(t.rutadisco);
                    string textoFile = leerTexto.ReadToEnd();
                    leerTexto.Close();

                    if (textoFile.Contains('\r'))
                        t.winEnters = true;

                    if (getEncodingBOM(t.rutadisco) != Encoding.ASCII)
                        t.BOM = true;
                }

                vectorEjecutables.Add(t);
                return true;
            }
            catch (IOException)
            {
                Logeador.Instance.log("ERROR: No se pudo cargar el archivo: " + t.rutadisco);
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

        public int cargarProyecto()
        {
            mInicializado = 0;
            if (tipoDelProyecto == tipoProyecto.Indefinido)
                mInicializado = 1;
            else if (codigo == "")
                mInicializado = 2;
            else if (carpeta == "")
                mInicializado = 3;
            else if (!cargarArchivos())
                mInicializado = 4;
            else if (!cargarDirectorios())
                mInicializado = 5;
            else if (!cargarEjecutables())
                mInicializado = 6;

            guardarDatosProyecto();

            return mInicializado;
        }

        public int inicializado()
        {
            return mInicializado;
        }

        public tipoProyecto getTipo()
        {
            return this.tipoDelProyecto;
        }

        public void setTipo(tipoProyecto t)
        {
            this.tipoDelProyecto = t;
        }

        public string getCodigo()
        {
            return this.codigo;
        }

        public void setCodigo(string t)
        {
            this.codigo = t;
        }

        public string getCarpeta()
        {
            return this.carpeta;
        }

        public void setCarpeta(string t)
        {
            this.carpeta = t;
        }

        public string getLabel()
        {
            string prefijo = "E"; if (tipoDelProyecto == tipoProyecto.Correctivo) prefijo = "C";
            return prefijo + codigo;
        }

        public string getDescripcion()
        {
            return this.descripcion;
        }

        public void setDescripcion(string t)
        {
            this.descripcion = t;
        }
       

        public bool generarTar()
        {
            string pathImplementacion = PerfilUtilizado.rutaImplementacion();
            string miPath = System.IO.Path.Combine(carpeta, "Instalador");
            string prefijo = "E"; if (tipoDelProyecto == tipoProyecto.Correctivo) prefijo = "C";

            string nombreTar = "fuentes_" + prefijo + codigo + ".tar";
            string nombreInstalador = "instalador_" + prefijo + codigo + ".sh";
            string nombreMigracion = "migracion_" + prefijo + codigo + ".html";

            string archivoTar = System.IO.Path.Combine(miPath, nombreTar);
            string archivoInstalador = System.IO.Path.Combine(miPath, nombreInstalador);
            string archivoMigracion = System.IO.Path.Combine(miPath, nombreMigracion);

            try
            {
                TarArchive archivoFuentes = null;

                cambiarPermisos(archivoTar);

                Stream outStream = File.Create(archivoTar);

                archivoFuentes = TarArchive.CreateOutputTarArchive(outStream, TarBuffer.DefaultBlockFactor);
                archivoFuentes.AsciiTranslate = false;
                archivoFuentes.SetUserInfo(0, "", 0, "None");

                for (int i = 0; i < vectorArchivos.Count; i++)
                {
                    TarEntry entry = TarEntry.CreateEntryFromFile(vectorArchivos[i].rutadisco);
                    entry.TarHeader.Name = vectorArchivos[i].ruta.Substring(1); // Ignoro el primer caracter
                    archivoFuentes.WriteEntry(entry, true);
                }

                for (int i = 0; i < vectorEjecutables.Count; i++)
                {
                    TarEntry entry = TarEntry.CreateEntryFromFile(vectorEjecutables[i].rutadisco);
                    entry.TarHeader.Name = vectorEjecutables[i].ruta;
                    archivoFuentes.WriteEntry(entry, true);
                }

                if (archivoFuentes != null)
                    archivoFuentes.Close();
            }
            catch (IOException e)
            { Logeador.Instance.log("Error intentando crear el .tar: " + e.Message); return false; }
            catch (UnauthorizedAccessException e)
            {
                Logeador.Instance.log("Error al intentar crear el .tar, verifique que no este siendo utilizado por otra aplicacion o con permisos de solo lectura. Puede ayudar eliminar el archivo existente. Tambien puede ser que este intentando escribir en un directorio protegido. Mensaje de error: " + e.Message); return false; }
            return true;
        }

        public bool getDirectorioPorRuta(string ruta, out directorio resultado)
        {
            for (int i = 0; i < vectorDirectorios.Count; i++)
            {
                if (vectorDirectorios[i].ruta == ruta)
                {
                    resultado = vectorDirectorios[i];
                    return true;
                }
            }
            resultado = new directorio();
            return false;
        }


        public bool generarScriptInstalador(Entorno e)
        {
            string pathImplementacion = PerfilUtilizado.rutaImplementacion();
            string pathVersionador = PerfilUtilizado.proyectoSegunVersionador() + "\\" + PerfilUtilizado.rutaVersionadorImplementacion();
            string miPath = System.IO.Path.Combine(carpeta, "Instalador");
            string prefijo = "E"; if (tipoDelProyecto == tipoProyecto.Correctivo) prefijo = "C";

            string nombreInstalador;
            if(!e.getProductivo())
                nombreInstalador = "instalador_" + prefijo + codigo + "_" + e.Nombre() + ".sh";
            else
                nombreInstalador = "instalador_" + prefijo + codigo + ".sh";
            string nombreTar = "fuentes_" + prefijo + codigo + ".tar";
            string nombreMigracion = "migracion_" + prefijo + codigo + ".html";

            string archivoTar = System.IO.Path.Combine(miPath, nombreTar);
            string archivoInstalador = System.IO.Path.Combine(miPath, nombreInstalador);
            string archivoMigracion = System.IO.Path.Combine(miPath, nombreMigracion);

            FileInfo f = new FileInfo(archivoTar);

            /* Instalador */
            try
            {
                string pathTemplateInstalador = PerfilUtilizado.getTemplateInstalador(e);
                /* Directorios */
                StringBuilder directoriosCreacion = new StringBuilder();
                for (int i = 0; i < vectorDirectorios.Count; i++)
                {
                    string dirRuta = vectorDirectorios[i].ruta;
                    string dirOwner = vectorDirectorios[i].owner;
                    string dirGrupo = vectorDirectorios[i].grupo;
                    string dirPermisos = vectorDirectorios[i].permisos;
                    if (!e.getProductivo())
                    {
                        dirOwner = e.getUsuarioMapeado(dirOwner);
                        dirGrupo = e.getGrupoMapeado(dirGrupo);
                        dirRuta = e.getDirectorioMapeado(dirRuta);
                    }
                    directoriosCreacion.Append("	CrearDirectorio " + dirRuta + " " + dirOwner + " " + dirGrupo + " " + dirPermisos + '\n');

                }
                /* Archivos */
                StringBuilder archivosCreacion = new StringBuilder();
                for (int i = 0; i < vectorArchivos.Count; i++)
                {
                    string archRuta = vectorArchivos[i].ruta;
                    string archRutaDestino = archRuta;
                    string archOwner = vectorArchivos[i].owner;
                    string archGrupo = vectorArchivos[i].grupo;
                    string archPermisos = vectorArchivos[i].permisos;
                    if (!e.getProductivo())
                    {
                        archOwner = e.getUsuarioMapeado(archOwner);
                        archGrupo = e.getGrupoMapeado(archGrupo);
                        archRutaDestino = e.getDirectorioMapeado(archRutaDestino);
                    }
                    archivosCreacion.Append("CopiarArchivo " + pathImplementacion + prefijo + codigo + archRuta + " " + archRutaDestino + " " + archOwner + " " + archGrupo + " " + archPermisos + " ${ROLLBACK}" + '\n');
                }
                /* Ejecutables */
                StringBuilder ejecutablesPermisos = new StringBuilder();
                StringBuilder ejecutablesCreacion = new StringBuilder();
                for (int i = 0; i < vectorEjecutables.Count; i++)
                {
                    ejecutablesPermisos.Append("PermisosEjecutable " + pathImplementacion + prefijo + codigo + "/" + vectorEjecutables[i].ruta + '\n');
                    if (vectorEjecutables[i].ruta.Substring(vectorEjecutables[i].ruta.Length - 3, 3) == ".sh")
                        ejecutablesCreacion.Append("EjecutarScript " + pathImplementacion + prefijo + codigo + "/" + vectorEjecutables[i].ruta + '\n');
                }


                TextReader leerTemplate = new StreamReader(pathTemplateInstalador);
                string template = leerTemplate.ReadToEnd();
                leerTemplate.Close();

                if (tipoDelProyecto == tipoProyecto.Evolutivo)
                    template = template.Replace("*-*-*TIPO*-*-*", "evolutivo");
                else if (tipoDelProyecto == tipoProyecto.Correctivo)
                    template = template.Replace("*-*-*TIPO*-*-*", "correctivo");

                template = template.Replace("*-*-*CODIGO*-*-*", prefijo + codigo);
                template = template.Replace("*-*-*TAR*-*-*", nombreTar);
                template = template.Replace("*-*-*TARSIZE*-*-*", f.Length.ToString());
                template = template.Replace("*-*-*INSTALADOR*-*-*", nombreInstalador);
                template = template.Replace("*-*-*DESCRIPCION*-*-*", descripcion);
                template = template.Replace("*-*-*COPIADIRECTORIOS*-*-*", directoriosCreacion.ToString());
                template = template.Replace("*-*-*COPIAARCHIVOS*-*-*", archivosCreacion.ToString());
                template = template.Replace("*-*-*PERMISOSSCRIPTS*-*-*", ejecutablesPermisos.ToString());
                template = template.Replace("*-*-*EJECUCIONSCRIPTS*-*-*", ejecutablesCreacion.ToString());
                template = template.Replace("*-*-*RUTAIMPLEMENTACION*-*-*", pathImplementacion);
                template = template.Replace("*-*-*RUTAVERSIONADOR*-*-*", pathVersionador);

                cambiarPermisos(archivoInstalador);

                StreamWriter escribirScript = new StreamWriter(archivoInstalador);
                escribirScript.Write(template);
                escribirScript.Close();

            }
            catch (Exception ex)
            { Logeador.Instance.log("Error intentando crear el script instalador: " + ex.Message); return false; }
            return true;
        }

        private void cambiarPermisos(string arch)
        {
            try
            {
                if(File.Exists(arch)){
                    var attr = File.GetAttributes(arch);

                    if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(arch, (attr ^ FileAttributes.ReadOnly));
                }
            }
            catch (Exception)
            { }
        }

        private bool generarManualSolicitud(Entorno e)
        {
            string pathImplementacion = PerfilUtilizado.rutaImplementacion();
            string pathVersionador = PerfilUtilizado.proyectoSegunVersionador() + "\\" + PerfilUtilizado.rutaVersionadorImplementacion();
            string miPath = System.IO.Path.Combine(carpeta, "Instalador");
            string prefijo = "E"; if (tipoDelProyecto == tipoProyecto.Correctivo) prefijo = "C";

            string nombreTar = "fuentes_" + prefijo + codigo + ".tar";
            string nombreInstalador = "instalador_" + prefijo + codigo + ".sh";
            string nombreInstaladorDesa = "instalador_" + prefijo + codigo + "<ENTORNO>.sh";
            string nombreMigracion = "migracion_" + prefijo + codigo + ".html";

            string archivoTar = System.IO.Path.Combine(miPath, nombreTar);
            string archivoInstalador = System.IO.Path.Combine(miPath, nombreInstalador);
            string archivoMigracion = System.IO.Path.Combine(miPath, nombreMigracion);

            FileInfo f = new FileInfo(archivoTar);
            /* Solicitud */
            try
            {
                string pathTemplateSolicitud = PerfilUtilizado.getTemplateSolicitud(e);

                TextReader leerTemplate = new StreamReader(pathTemplateSolicitud);
                string template = leerTemplate.ReadToEnd();
                leerTemplate.Close();

                string pathTemplateInstalador = PerfilUtilizado.getTemplateInstalador(e);
                /* Directorios */
                StringBuilder directoriosLista = new StringBuilder();
                for (int i = 0; i < vectorDirectorios.Count; i++)
                {
                    string dirRuta = vectorDirectorios[i].ruta;
                    string dirOwner = vectorDirectorios[i].owner;
                    string dirGrupo = vectorDirectorios[i].grupo;
                    string dirPermisos = vectorDirectorios[i].permisos;
                    if (!e.getProductivo())
                    {
                        dirOwner = e.getUsuarioMapeado(dirOwner);
                        dirGrupo = e.getGrupoMapeado(dirGrupo);
                        dirRuta = e.getDirectorioMapeado(dirRuta);
                    }
                    directoriosLista.Append(dirRuta + " (" + dirOwner + ":" + dirGrupo + "/" + dirPermisos + ")" + '\n');

                }
                /* Archivos */
                StringBuilder archivosLista = new StringBuilder();
                for (int i = 0; i < vectorArchivos.Count; i++)
                {
                    string archRuta = vectorArchivos[i].ruta;
                    string archOwner = vectorArchivos[i].owner;
                    string archGrupo = vectorArchivos[i].grupo;
                    string archPermisos = vectorArchivos[i].permisos;
                    if (!e.getProductivo())
                    {
                        archOwner = e.getUsuarioMapeado(archOwner);
                        archGrupo = e.getGrupoMapeado(archGrupo);
                        archRuta = e.getDirectorioMapeado(archRuta);
                    }
                    archivosLista.Append(archRuta + " (" + archOwner + ":" + archGrupo + "/" + archPermisos + ")" + '\n');
                }
                /* Ejecutables */
                StringBuilder ejecutablesLista = new StringBuilder();
                for (int i = 0; i < vectorEjecutables.Count; i++)
                {
                    if (vectorEjecutables[i].ruta.Substring(vectorEjecutables[i].ruta.Length - 3, 3) == ".sh")
                        ejecutablesLista.Append(pathImplementacion + prefijo + codigo + "/" + vectorEjecutables[i].ruta + '\n');
                }

                if (tipoDelProyecto == tipoProyecto.Evolutivo)
                    template = template.Replace("*-*-*TIPO*-*-*", "evolutivo");
                else if (tipoDelProyecto == tipoProyecto.Correctivo)
                    template = template.Replace("*-*-*TIPO*-*-*", "correctivo");

                template = template.Replace("*-*-*CODIGO*-*-*", prefijo + codigo);
                template = template.Replace("*-*-*TAR*-*-*", nombreTar);
                template = template.Replace("*-*-*TARSIZE*-*-*", f.Length.ToString());
                template = template.Replace("*-*-*INSTALADOR*-*-*", nombreInstalador);
                template = template.Replace("*-*-*INSTALADORDESA*-*-*", nombreInstaladorDesa); 
                template = template.Replace("*-*-*DESCRIPCION*-*-*", descripcion);
                template = template.Replace("*-*-*RUTAIMPLEMENTACION*-*-*", pathImplementacion);
                template = template.Replace("*-*-*RUTAVERSIONADOR*-*-*", pathVersionador);
                template = template.Replace("*-*-*LISTAARCHIVOS*-*-*", archivosLista.ToString());
                template = template.Replace("*-*-*LISTADIRECTORIOS*-*-*", directoriosLista.ToString());
                template = template.Replace("*-*-*LISTAEJECUTABLES*-*-*", ejecutablesLista.ToString());

                cambiarPermisos(archivoMigracion);

                StreamWriter escribirScript = new StreamWriter(archivoMigracion);
                escribirScript.Write(template);
                escribirScript.Close();

            }
            catch (Exception ex)
            { Logeador.Instance.log("Error intentando crear el manual de solicitudes: " + ex.Message); return false; }
            return true;
        }

        public bool generarInstalador()
        {
            string miPath = System.IO.Path.Combine(carpeta, "Instalador");
            System.IO.Directory.CreateDirectory(miPath);

            if(!generarTar())
                return false;

            foreach (Entorno e in PerfilUtilizado.entornos)
            {

                if (!generarScriptInstalador(e))
                    return false;
                if(e.getProductivo())
                    if (!generarManualSolicitud(e))
                        return false;
            }

            return true;
        }

        public static bool IsText(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                Encoding encoding = Encoding.Default;
                int windowSize = 500;
                var rawData = new byte[windowSize];
                var text = new char[windowSize];
                var isText = true;

                var rawLength = fileStream.Read(rawData, 0, rawData.Length);
                fileStream.Seek(0, SeekOrigin.Begin);

                if (rawData[0] == 0xef && rawData[1] == 0xbb && rawData[2] == 0xbf)
                {
                    encoding = Encoding.UTF8;
                }
                else if (rawData[0] == 0xfe && rawData[1] == 0xff)
                {
                    encoding = Encoding.Unicode;
                }
                else if (rawData[0] == 0 && rawData[1] == 0 && rawData[2] == 0xfe && rawData[3] == 0xff)
                {
                    encoding = Encoding.UTF32;
                }
                else if (rawData[0] == 0x2b && rawData[1] == 0x2f && rawData[2] == 0x76)
                {
                    encoding = Encoding.UTF7;
                }
                else
                {
                    encoding = Encoding.Default;
                }

                using (var streamReader = new StreamReader(fileStream))
                {
                    streamReader.Read(text, 0, text.Length);
                }

                using (var memoryStream = new MemoryStream())
                {
                    using (var streamWriter = new StreamWriter(memoryStream, encoding))
                    {
                        streamWriter.Write(text);
                        streamWriter.Flush();

                        var memoryBuffer = memoryStream.GetBuffer();

                        for (var i = 0; i < rawLength && isText; i++)
                        {
                            isText = rawData[i] == memoryBuffer[i];
                        }
                    }
                }

                return isText;
            }
        }

        public static Encoding getEncodingBOM(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                Encoding encoding = Encoding.Default;
                int windowSize = 500;
                var rawData = new byte[windowSize];

                var rawLength = fileStream.Read(rawData, 0, rawData.Length);
                fileStream.Seek(0, SeekOrigin.Begin);

                if (rawData[0] == 0xef && rawData[1] == 0xbb && rawData[2] == 0xbf)
                {
                    encoding = Encoding.UTF8;
                }
                else if (rawData[0] == 0xfe && rawData[1] == 0xff)
                {
                    encoding = Encoding.Unicode;
                }
                else if (rawData[0] == 0 && rawData[1] == 0 && rawData[2] == 0xfe && rawData[3] == 0xff)
                {
                    encoding = Encoding.UTF32;
                }
                else if (rawData[0] == 0x2b && rawData[1] == 0x2f && rawData[2] == 0x76)
                {
                    encoding = Encoding.UTF7;
                }
                else
                {
                    encoding = Encoding.ASCII;
                }

                return encoding;
            }
        }
    }
}
