using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalSeguridad.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinalSeguridad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguridadController : ControllerBase
    {

        [HttpPost("Hash")]
        public ActionResult<byte[]> PostHash([FromBody] string CadenaTexto)
        {
            byte[] hashValue = null;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                try
                {
                    hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(CadenaTexto));
                    Console.Write($"{hashValue}: ");

                }
                catch (IOException e)
                {
                    Console.WriteLine($"I/O Exception: {e.Message}");
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine($"Access Exception: {e.Message}");
                }

                return hashValue;

            }
        }

        [HttpPost("Encriptacion")]
        public byte[] PostEncriptacionAES256([FromBody] Models.Encriptador encriptador)
        {
            // Check arguments.
            if (encriptador.PlainText == null || encriptador.PlainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (encriptador.Key == null || encriptador.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (encriptador.IV == null || encriptador.IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = encriptador.Key;
                aesAlg.IV = encriptador.IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(encriptador.PlainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        [HttpPost("Desencriptacion")]
        public string PostDesencriptacionAES256([FromBody] Models.Desencriptador desencriptador)
        {
            // Check arguments.
            if (desencriptador.CipherText == null || desencriptador.CipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (desencriptador.Key == null || desencriptador.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (desencriptador.IV == null || desencriptador.IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = desencriptador.Key;
                aesAlg.IV = desencriptador.IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(desencriptador.CipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        [HttpPost("ObtenerLlaves")]
        public DatosEnc PruebaEncriptacion([FromBody] string TextoPlano)
        {
            DatosEnc datos = new DatosEnc();

            using (Aes myAes = Aes.Create())
            {

                datos.Key = myAes.Key;
                datos.Iv = myAes.IV;
                datos.Texto = TextoPlano;

            }
            return datos;
        }
        [HttpPost("ValidarTarjeta")]
        public string PostExpresionRegular([FromBody] string TextoPlano)
        {
            Regex r = new Regex(@"[0-9]{16}");
            string response = Regex.Replace(TextoPlano, @"[^\w\s.!@$%^&*()\-\/]+", "");

            if (r.IsMatch(TextoPlano)) 
            {
                response = TextoPlano.Replace(TextoPlano.Substring(0,12),"*************");
                return response;
            }
            return "No es tarjeta Valida";
        }
    }
}
