using LorenzoApplication.Modelos;
namespace LorenzoApplication.ModeloDto
{
    public class FacturaCompraDto: Cmp_Com
    {
        public List<Com_Fac> Detalle { get; set; }
        public string NombreProveedor { get; set; }
        public List<ClienteDto> proveedores { get; set; }
        public FacturaCompraDto() : base()
        {
            Detalle = new List<Com_Fac>();
            NombreProveedor = string.Empty;
            proveedores = new List<ClienteDto>();
        }
    }
}