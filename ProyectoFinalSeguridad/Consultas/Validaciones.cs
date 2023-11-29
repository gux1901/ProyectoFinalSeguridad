using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ProyectoFinalSeguridad.Consultas
{
    public class Validaciones
    {
        public string ValidarTarjeta(string TextoPlano)
        {
            Regex r = new Regex(@"[0-9]{16}");
            

            if (r.IsMatch(TextoPlano))
            {
                TextoPlano = TextoPlano.Replace(TextoPlano.Substring(0, 12), "*************");
                return TextoPlano;
            }
            return "No es tarjeta Valida";
        }
        public DTO.GeneradorLlaves ObtenerLlaves()
        {
            DTO.GeneradorLlaves datos = new DTO.GeneradorLlaves();

            using (Aes myAes = Aes.Create())
            {

                datos.Key = myAes.Key;
                datos.Iv = myAes.IV;

            }
            return datos;
        }

        public byte[] EncriptacionAES256(DTO.Encriptador encriptador)
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

        public string DesencriptacionAES256(DTO.Desencriptador desencriptador)
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
        public byte[] Hash(string CadenaTexto)
        {
            byte[] hashValue = null;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                try
                {
                    hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(CadenaTexto));
                    

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
    }
}