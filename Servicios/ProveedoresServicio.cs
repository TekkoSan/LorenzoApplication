using LorenzoApplication.ModeloDto;
using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication.Servicios
{
    public interface IProveedoresServicio
    {
        public Task<List<ProveeDto>> CargarCombo();
        public Task<bool> Agregar(Provee proveedor);
        public Task<List<Provee>> Listar();
        public Task<Provee?> Leer(string codigo);
        public Task<bool> Eliminar(string codigo);
        public Task<bool> Modificar(Provee dato);
    }
    public class ProveedoresServicio : IProveedoresServicio
    {
        private readonly LorenzoContexto Db;
        private readonly INumerarServicio _numerarServicio;
        public ProveedoresServicio(LorenzoContexto lorenzoContexto, INumerarServicio numerarServicio)
        {
            Db = lorenzoContexto;
            _numerarServicio = numerarServicio;
        }
        public async Task<bool> Agregar(Provee proveedor)
        {
            proveedor.Codigo = await _numerarServicio.NuevoCodigo("Proveedor");
            var respuesta = await Db.Provee.Where(X => X.Id.Equals(proveedor.Id)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                proveedor = Normalizar(proveedor);
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
            respuesta.Nombre = dato.Nombre.ToUpper();
            respuesta.Locali = dato.Locali.ToUpper();
            respuesta.Direcc = dato.Direcc.ToUpper();
            respuesta.CodPos = dato.CodPos.ToUpper();
            respuesta.Tipiva = dato.Tipiva.ToUpper();
            respuesta.Cuit = dato.Cuit.ToUpper();
            Db.Provee.Update(respuesta);
            await Db.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProveeDto>> CargarCombo()
        {
            List<ProveeDto> respuesta = new List<ProveeDto>();
            var lista = await Listar();
            foreach (var X in lista)
            {
                respuesta.Add(new ProveeDto() { Codigo = X.Codigo, Nombre = X.Nombre });
            }
            return respuesta;
        }
        static private Provee Normalizar(Provee dato)
        {
            dato.Nombre = dato.Nombre.ToUpper();
            dato.Direcc = dato.Direcc.ToUpper();
            dato.Locali = dato.Locali.ToUpper();
            dato.Tipiva = dato.Tipiva.ToUpper();
            dato.Cuit = dato.Cuit.ToUpper();
            return dato;
        }
    }
}