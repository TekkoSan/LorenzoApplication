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
        public string Tipiva { get; set; } // 1-Responsable Inscripto, 2-Monotributo, 3-Excento
        public string Cuit { get; set; }

        public Provee()
        {
            Id = 0;
            Codigo = "";
            Nombre = "";
            Direcc = "";
            Locali = "";
            CodPos = "";
            Telefo = "";
            Tipiva = "";
            Cuit = "";
        }
    }
}
