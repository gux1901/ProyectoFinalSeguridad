namespace ProyectoFinalSeguridad.Models
{
    public class DatosEnc
    {
        private byte[] key;
        private byte[] iv;
        private string texto;

        public byte[] Key { get => key; set => key = value; }
        public byte[] Iv { get => iv; set => iv = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}
