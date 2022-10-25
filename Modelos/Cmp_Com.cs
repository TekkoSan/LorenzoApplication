namespace LorenzoApplication.Modelos
{
    public class Cmp_Com
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Provee { get; set; }
        public double Otros { get; set; }
        public double Neto { get; set; }
        public double Reten { get; set; }
        public double V_Iva { get; set; }
        public double Seguro { get; set; }
        public double Total { get; set; }
        public string Descri { get; set; }
        public Cmp_Com()
        {
            Id = 0;
            Codigo = "";
            Tipo = "";
            Fecha = new DateTime(1, 1, 1900);
            Provee = "";
            Otros = 0;
            Neto = 0;
            Reten = 0;
            V_Iva = 0;
            Seguro = 0;
            Total = 0;
            Descri = "";
        }
    }
}
