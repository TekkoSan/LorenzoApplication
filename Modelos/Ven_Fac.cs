namespace LorenzoApplication.Modelos
{
    public class Ven_Fac
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Articulo { get; set; }
        public double Peso { get; set; }
        public double Precio { get; set; }
        
        public Ven_Fac()
        {
            Id = 0;
            Codigo = string.Empty;
            Tipo = string.Empty;
            Fecha = new DateTime(1900, 1, 1);
            Articulo = string.Empty;
            Peso = 0;
            Precio = 0;
        }


    }
}
