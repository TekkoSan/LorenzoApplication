namespace LorenzoApplication.Modelos
{
    public class Provee
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direcc { get; set; }
        public string Locali { get; set; }
        public string CodPos { get; set; }
        public string Telefo { get; set; }
        public string TIPIVA { get; set; }
        public string CUIT { get; set; }

        public Provee()
        {
            Id = 0;
            Codigo = "";
            Nombre = "";
            Direcc = "";
            Locali = "";
            CodPos = "";
            Telefo = "";
            TIPIVA = "";
            CUIT = "";
        }
    }
}
