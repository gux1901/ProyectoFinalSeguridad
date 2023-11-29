using ProyectoFinalSeguridad.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectoFinalSeguridad
{
    /// <summary>
    /// Summary description for WsSeguridad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsSeguridad : System.Web.Services.WebService
    {

        [WebMethod]
        public byte[] Encriptar(DTO.Encriptador encriptador)
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.EncriptacionAES256(encriptador);
        }
        [WebMethod]
        public string Desencriptar(DTO.Desencriptador desencriptador)
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.DesencriptacionAES256(desencriptador);
        }
        [WebMethod]
        public byte[] Hashing(string CadenaTexto)
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.Hash(CadenaTexto);
        }
        [WebMethod]
        public DTO.GeneradorLlaves ObtenerLlaves()
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.ObtenerLlaves();
        }
        [WebMethod]
        public string Tarjetas(string Tarjeta)
        {
            Validaciones validaciones = new Validaciones();
            return validaciones.ValidarTarjeta(Tarjeta);
        }
    }
}
