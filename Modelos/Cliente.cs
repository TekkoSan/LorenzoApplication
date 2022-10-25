using LorenzoApplication.Servicios;
namespace LorenzoApplication.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direcc { get; set; }
        public string Locali { get; set; }
        public string Codpos { get; set; }
        public string Telefo { get; set; }
        public string TIPIVA { get; set; }
        public string CUIT { get; set; }
        public string Reparto { get; set; }

        public Cliente()
        {
            Id = 0;
            Codigo = "";
            TIPIVA = "";
            Nombre = "";
            Direcc = "";
            Locali = "";
            Telefo = "";
            CUIT = "";
            Reparto = "";
            Codpos = "";
        }
    }
}