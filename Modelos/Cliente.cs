namespace LorenzoApplication.Modelos
{
    public class Cliente
    {
        public string Id { get; set; }
        public string NombreC { get; set; }
        public string DirecciónC { get; set; }
        public string LocalidadC { get; set; }
        public int CodigoPostalC { get; set; }
        public string TeléfonoC { get; set; }
        public byte TIPIVAC { get; set; }
        public string CUIT { get; set; }
        public bool Reparto { get; set; }

        public Cliente()
        {
            Id = "C:" + Guid.NewGuid().ToString();
            NombreC = "";
            DirecciónC = "";
            LocalidadC = "";
            TeléfonoC = "";
            CUIT = "";
        }
    }
}
