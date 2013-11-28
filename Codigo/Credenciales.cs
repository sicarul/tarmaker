using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TarMaker
{
    public sealed class Credenciales
    {
        private static readonly Credenciales instance = new Credenciales();
        private static string mUser;
        private static string mPass;
        private static string mHost;
        private static string mURL;
        private static string mDB;
        private static string ultimoError;
        private static bool CredencialesOK;
        private static bool HuboCambio;

        private Credenciales()
        {
            mUser = Utilitarios.getKey(Utilitarios.RUTA_REGISTRO, "UserDimensions");
            mURL = Utilitarios.getKey(Utilitarios.RUTA_REGISTRO, "URLDimensions");
            mHost = Utilitarios.getKey(Utilitarios.RUTA_REGISTRO, "HostDimensions");
            mDB = Utilitarios.getKey(Utilitarios.RUTA_REGISTRO, "DBDimensions");
            mPass = "";

            if (mUser.Length == 0) mUser = Environment.UserName;
            if (mHost.Length == 0) mHost = "SRVDIMENSION01";
            if (mDB.Length == 0) mDB = "TPDIMDB";
            if (mURL.Length == 0) mURL = "https://dimensions.mctp.corp:8443/dmwebservices2/services/dmwebservices/";

            CredencialesOK = false;
            HuboCambio = false;
            ultimoError = "";
        }

        

        public static Credenciales Instance
        {
            get
            {
                return instance;
            }
        }

        public string getUser()
        {
            return mUser;
        }
        public string getPass()
        {
            return mPass;
        }
        public string getHost()
        {
            return mHost;
        }
        public string getDB()
        {
            return mDB;
        }
        public string getURL()
        {
            return mURL;
        }


        public void setUser(string user)
        {
            mUser = user;
            Utilitarios.setKey(Utilitarios.RUTA_REGISTRO, "UserDimensions", user);
            HuboCambio = true;
        }
        public void setPass(string pass)
        {
            mPass = pass;
            HuboCambio = true;
        }
        public void setHost(string host)
        {
            mHost = host;
            Utilitarios.setKey(Utilitarios.RUTA_REGISTRO, "HostDimensions", host);
            HuboCambio = true;
        }
        public void setDB(string DB)
        {
            mDB = DB;
            Utilitarios.setKey(Utilitarios.RUTA_REGISTRO, "DBDimensions", DB);
            HuboCambio = true;
        }
        public void setURL(string url)
        {
            mURL = url;
            Utilitarios.setKey(Utilitarios.RUTA_REGISTRO, "URLDimensions", url);
            HuboCambio = true;
        }

        public bool GetLoginCorrecto()
        {
            if (CredencialesOK == false && HuboCambio==false){
                return false;
            }
            else if(CredencialesOK == false)
            {
                Dimensions dm = new Dimensions();
                CredencialesOK = dm.conexion();
                return CredencialesOK;
            }
            else return true;
        }

        public void SetLoginIncorrecto()
        {
            CredencialesOK = false;
        }

        public void SetError(string err)
        {
            ultimoError = err;
        }

        public string GetError()
        {
            return ultimoError;
        }

    }
}
