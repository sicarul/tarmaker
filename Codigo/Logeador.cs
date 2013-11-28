using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TarMaker
{
    public sealed class Logeador
    {
        private static readonly Logeador instance = new Logeador();
        private static List<string> Mensajes;

        private Logeador() {
            Mensajes = new List<string>();
        }

        public static Logeador Instance
        {
            get
            {
                return instance;
            }
        }

        public void log(string texto)
        {
            Mensajes.Add(texto);
        }

        public List<string> obtenerMensajes()
        {
            List<string> m = Mensajes;
            Mensajes = new List<string>();
            return m;
        }

        public int cantidadMensajes()
        {
            return Mensajes.Count;
        }

    }
}
