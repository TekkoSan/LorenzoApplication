using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{
    public interface IClientesServicio
    {
        public List<Cliente> Listar();
        public void AgregarCliente(Cliente cliente);
    }
    public class ClientesServicio : IClientesServicio
    {
        private List<Cliente> listaClientes = new List<Cliente>();
        public void AgregarCliente(Cliente cliente)
        {
           listaClientes.Add(cliente);
        }
        public List<Cliente> Listar()
        {
            return listaClientes;
        }
    }
}
