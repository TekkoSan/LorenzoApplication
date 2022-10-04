namespace LorenzoApplication.Modelos
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string NombreP { get; set; }
        public string DirecciónP { get; set; }
        public int CodigoPostalP { get; set; }
        public string LocalidadP { get; set; }
        public string TeléfonoP { get; set; }
        public byte TIPIVAP { get; set; }
        public string CUIL { get; set; }

        public Proveedor()
        {
            Id = "P:" + Guid.NewGuid().ToString();
            NombreP = "";
            DirecciónP = "";
            LocalidadP = "";
            TeléfonoP = "";
            CUIL = "";
        }
    }
}
