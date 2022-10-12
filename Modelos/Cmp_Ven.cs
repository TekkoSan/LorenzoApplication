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


    }
}
