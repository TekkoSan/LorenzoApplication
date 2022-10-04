using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{
    public interface IProveedoresServicio
    {
        public List<Proveedor> Listar();
        public void AgregarProveedor(Proveedor proveedor);
    }
    public class ProveedoresServicio : IProveedoresServicio
    {
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        public void AgregarProveedor(Proveedor proveedor)
        {
            listaProveedores.Add(proveedor);
        }
        public List<Proveedor> Listar()
        {
            return listaProveedores;
        }
    }
}
