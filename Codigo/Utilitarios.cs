using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TarMaker
{
    
    
    public enum tipoProyecto { Indefinido, Evolutivo, Correctivo };

    public struct archivo
    {
        public string ruta;
        public string rutadisco;
        public string owner;
        public string grupo;
        public string permisos;
        public bool winEnters;
        public bool BOM;
    }

    public struct directorio
    {
        public string ruta;
        public string rutadisco;
        public string owner;
        public string grupo;
        public string permisos;
    }

    public struct mapeo
    {
        public string original;
        public string destino;
    }

    public enum DIFERENCIA_DIMENSIONS
    {
        NoExiste,
        DiffDistinto,
        Iguales,
        ErrorComparacion
    }

    public struct ArchivoDimensions
    {
        public int id;
        public string ubicacion;
        public string archivo;
        public DateTime ultima_modificacion;
        public byte[] contenido;
        public DIFERENCIA_DIMENSIONS diferencias;

    }

    public sealed class Utilitarios
    {
        public const string RUTA_REGISTRO = "SOFTWARE\\Tarmaker";
        public static string TextoDiferencia(DIFERENCIA_DIMENSIONS Dif)
        {
            switch (Dif)
            {
                case DIFERENCIA_DIMENSIONS.Iguales:
                    return "Igual a Dimensions";
                case DIFERENCIA_DIMENSIONS.DiffDistinto:
                    return "Distintos archivos";
                case DIFERENCIA_DIMENSIONS.NoExiste:
                    return "No existe";
                case DIFERENCIA_DIMENSIONS.ErrorComparacion:
                    return "Error comparando fuentes";
                default:
                    return "";
            }
        }

        public static byte[] StringAByteArray(string S)
        {
            char[] cArr;
            cArr = S.ToCharArray();
            List<byte> lByte = new List<byte>();
            foreach (char e in cArr)
            {
                lByte.Add((byte)e);
            }

            return lByte.ToArray();
        }
        
        public static bool ArraysIguales(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        public static string getKey(string ruta, string key)
        {
            RegistryKey theKey = Registry.LocalMachine.CreateSubKey
            (ruta);
            string retKey;
            if (theKey == null)
            {
                retKey = "";
            }
            else
            {
                try
                {
                    retKey = theKey.GetValue(key).ToString();
                }
                catch
                {
                    retKey = "";
                }
            }
            theKey.Close();
            return retKey;
        }

        public static void setKey(string ruta, string key, string valor)
        {
            RegistryKey theKey = Registry.LocalMachine.CreateSubKey
            (ruta);
            theKey.SetValue(key, valor);
            theKey.Close();
        }

    }

}
