using LorenzoApplication.Modelos;
namespace LorenzoApplication.ModeloDto
{
    public class FacturaVentaDto: Cmp_Ven
    {
        public List<FacturaVentaDetalleDto> Detalle { get; set; }
        public string NombreCliente { get; set; }
        public List<ClienteDto> clientes { get; set; }
        public FacturaVentaDto(): base()
        {
            Detalle = new List<FacturaVentaDetalleDto>();
            NombreCliente = string.Empty;
            clientes = new List<ClienteDto>();
        }
    }
}