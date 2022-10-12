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
        private LorenzoContexto Db;

        public ClientesServicio(LorenzoContexto lorenzoContexto)
        {
            Db = lorenzoContexto;
        }
        public async Task<bool> AgregarCliente(Cliente cliente)
        {
            var respuesta = await Db.Clientes.Where(X => X.Id.Equals(cliente.Id)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                Db.Clientes.Add(cliente);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Cliente>> Listar()
        {
            var respuesta = await Db.Clientes.ToListAsync();
            return respuesta;
        }
    }
}