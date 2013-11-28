using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/*
 * TODO
 * Parametros para scripts sh segun entorno(perfil)
 * Opción de subir a un servidor de desarrollo por SSH/SCP el evolutivo a implementar, y si es posible ejecutar el instalador y mostrar la salida
 * Opción para subir a Dimensions fuentes
 * http://code.google.com/p/google-diff-match-patch/ Tri-Diff - Dimensions-Desarrollo-Implementacion
 * Opcion script/s rollback
 * Creacion de links
 * 
 * FIN
 * Agregar touch despues del mv del .pre_EXXXXX
 * Agregar en manual de impl comentarios con componentes impactados
 * Agregar chmod del nohup.out si existe
 * Hacer trim de parametros antes de tomarlos, para evitar errores ocultos
 */


namespace TarMaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
