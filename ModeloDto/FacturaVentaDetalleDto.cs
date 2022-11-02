using LorenzoApplication.Modelos;

namespace LorenzoApplication.ModeloDto
{
    public class FacturaVentaDetalleDto: Ven_Fac
    {
        public FacturaVentaDetalleDto(): base()
        {
            Descri = "";
        }

        public string Descri { get; set; }

        public Double Total()
        {
            return this.Peso * this.Precio;
        }

    }
}
