using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication.Servicios
{
    public interface IProveedoresServicio
    {
        public Task<bool> Agregar(Provee proveedor);
        public Task<List<Provee>> Listar();
        public Task<Provee?> Leer(string codigo);
        public Task<bool> Eliminar(string codigo);
        public Task<bool> Modificar(Provee dato);
    }
    public class ProveedoresServicio : IProveedoresServicio
    {
        private readonly LorenzoContexto Db;
        public ProveedoresServicio(LorenzoContexto lorenzoContexto)
        {
            Db = lorenzoContexto;
        }
        public async Task<bool> Agregar(Provee proveedor)
        {
            var respuesta = await Db.Provee.Where(X => X.Id.Equals(proveedor.Id)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                Db.Provee.Add(proveedor);
                await Db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<List<Provee>> Listar()
        {
            var respuesta = await Db.Provee.ToListAsync();
            return respuesta;
        }
        public async Task<Provee?> Leer(string codigo)
        {
            var respuesta = await Db.Provee.Where(X => X.Codigo.Equals(codigo)).FirstOrDefaultAsync();
            return respuesta;
        }
        public async Task<bool> Eliminar(string codigo)
        {
            var respuesta = await Db.Provee.Where(X => X.Codigo.Equals(codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
            else
            {
                Db.Provee.Remove(respuesta);
                await Db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Modificar(Provee dato)
        {
            var respuesta = await Db.Provee.Where(X => X.Codigo.Equals(dato.Codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
            respuesta.Nombre = dato.Nombre;
            respuesta.Locali = dato.Locali;
            respuesta.Direcc = dato.Direcc;
            respuesta.CodPos = dato.CodPos;
            respuesta.TIPIVA = dato.TIPIVA;
            respuesta.CUIT = dato.CUIT;
            Db.Provee.Update(respuesta);
            await Db.SaveChangesAsync();
            return true;
        }

    }
}