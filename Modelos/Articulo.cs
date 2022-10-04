namespace LorenzoApplication.Modelos
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descri { get; set; }

        public Articulo()
        {
            Id = 0;
            Codigo = "";
            Descri = "";
        }
    }
}
