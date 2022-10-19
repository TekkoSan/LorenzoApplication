using Microsoft.EntityFrameworkCore;
using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{
    public interface IClientesServicio
    {
        public Task<List<Cliente>> Listar();
        public Task<bool> AgregarCliente(Cliente cliente);
        public Task<Cliente> Leer(string cliente);
        public Task<bool> Eliminar(string codigo);
        public Task<bool> Modificar(Cliente cliente);
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

        public async Task<Cliente?> Leer(string cliente)
        {
            var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(cliente)).FirstOrDefaultAsync();
            return respuesta;

        }

        public async Task<bool> Eliminar(string codigo)
        {
            var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
            else
            {
                Db.Clientes.Remove(respuesta);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Modificar(Cliente cliente)
        {
            var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(cliente.Codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
            else
            {
                respuesta = Normalizar(respuesta);
                Db.Clientes.Update(respuesta);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        static private Cliente Normalizar(Cliente dato)
        {
            dato.Nombre = dato.Nombre.ToUpper();
            return dato;
        }
    }
}