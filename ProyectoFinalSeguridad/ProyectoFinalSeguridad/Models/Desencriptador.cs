namespace ProyectoFinalSeguridad.Models
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
