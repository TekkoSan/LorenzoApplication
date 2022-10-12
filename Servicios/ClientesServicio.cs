using Microsoft.EntityFrameworkCore;
using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{
    public interface IClientesServicio
    {
        public Task<List<Cliente>> Listar();
        public Task<bool> AgregarCliente(Cliente cliente);
    }
    public class ClientesServicio : IClientesServicio
    {
        private ClientesContexto Db;

        public ClientesServicio(ClientesContexto clientesContext)
        {
            Db = clientesContext;
        }
        public async Task<bool> AgregarCliente(Cliente cliente)
        {
            var respuesta = await Db.clientes.Where(X => X.Id.Equals(cliente.Id)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                Db.clientes.Add(cliente);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Cliente>> Listar()
        {
            var respuesta = await Db.clientes.ToListAsync();
            return respuesta;
        }
    }
}