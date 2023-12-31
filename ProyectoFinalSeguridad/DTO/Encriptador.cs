﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalSeguridad.DTO
{
    public class Encriptador
    {
        private string plainText;
        private byte[] key;
        private byte[] iV;

        public string PlainText { get => plainText; set => plainText = value; }
        public byte[] Key { get => key; set => key = value; }
        public byte[] IV { get => iV; set => iV = value; }
    }
}