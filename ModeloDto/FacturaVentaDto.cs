using LorenzoApplication.Modelos;

namespace LorenzoApplication.ModeloDto
{
    public class FacturaVentaDto: Cmp_Ven
    {
        public List<Ven_Fac> Detalle { get; set; }
        public string NombreCliente { get; set; }
        public List<ClienteDto> clientes { get; set; }

        public FacturaVentaDto(): base() {

            Detalle = new List<Ven_Fac>();
            NombreCliente = string.Empty;
            clientes = new List<ClienteDto>();
        }

    }
}
