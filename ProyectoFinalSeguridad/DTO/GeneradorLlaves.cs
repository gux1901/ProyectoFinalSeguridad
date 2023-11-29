using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalSeguridad.DTO
{
    public class GeneradorLlaves
    {
        private byte[] key;
        private byte[] iv;

        public byte[] Key { get => key; set => key = value; }
        public byte[] Iv { get => iv; set => iv = value; }
    }
}