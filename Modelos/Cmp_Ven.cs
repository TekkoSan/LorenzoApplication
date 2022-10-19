namespace LorenzoApplication.Modelos
{
    public class Cmp_Ven
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; } // 0-Factura 1-Nota de Credito(yo debo) 2-Nota de Debito(me debe) 3-Pago
        public DateTime Fecha { get; set; } 
        public string Cliente { get; set; }
        public double Total { get; set; }
        public string Descri { get; set; } // >PAGO<, >FACTURA< 
        

        public Cmp_Ven()
        {
            Id = 0;
            Codigo = string.Empty;
            Tipo = string.Empty;
            Fecha = new DateTime(1900, 1, 1);
            Cliente = string.Empty;
            Total = 0;
            Descri = string.Empty;
        }

    }
}
