using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{
    public interface ITipoComprobanteServicio
    {
        Task<List<TipoCompobante>> Listar();
    }


    public class TipoComprobanteServicio: ITipoComprobanteServicio
    {
        private List<TipoCompobante> tipos;

        public TipoComprobanteServicio()
        {
            tipos = new List<TipoCompobante>();
            tipos.Add(new TipoCompobante() { Codigo = "0", Descripcion = "FACTURA" });
            tipos.Add(new TipoCompobante() { Codigo = "1", Descripcion = "NOTA DE CREDITO" });
            tipos.Add(new TipoCompobante() { Codigo = "2", Descripcion = "NOTA DE DEBITO" });
            tipos.Add(new TipoCompobante() { Codigo = "3", Descripcion = "PAGO" });
        }

        public async Task<List<TipoCompobante>> Listar()
        {
            await Task.Delay(1);
            return tipos;            
        }

    }
}
