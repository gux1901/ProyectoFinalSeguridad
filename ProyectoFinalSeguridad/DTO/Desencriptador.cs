using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalSeguridad.DTO
{
    public class Desencriptador
    {
        private byte[] cipherText;
        private byte[] key;
        private byte[] iV;

        public byte[] CipherText { get => cipherText; set => cipherText = value; }
        public byte[] Key { get => key; set => key = value; }
        public byte[] IV { get => iV; set => iV = value; }
    }
}