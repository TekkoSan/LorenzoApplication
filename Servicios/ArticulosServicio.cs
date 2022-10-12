using Microsoft.EntityFrameworkCore;
using LorenzoApplication.Modelos;
using LorenzoApplication.Servicios;
using LorenzoApplication;

namespace LorenzoApplication.Servicios
{

    public interface IArticulosServicio
    {
        public Task<bool> Agregar(Articulo artículo);
        public Task<List<Articulo>> Listar();
        public Task<Articulo?> Leer(string Codigo);
        public Task<bool> Eliminar(string Codigo);
        public Task<bool> Modificar(Articulo dato);
    }


    public class ArticulosServicio : IArticulosServicio
    {
        private readonly LorenzoContexto Db;
        private readonly INumerarServicio _numerarServicio;

        public ArticulosServicio(LorenzoContexto lorenzoContexto, INumerarServicio numerarServicio)
        {
            Db = lorenzoContexto;
            _numerarServicio = numerarServicio;
        }
        public async Task<bool> Agregar(Articulo articulo)
        {
            articulo.Codigo = await _numerarServicio.NuevoCodigo("Articulo");

            var respuesta = await Db.Articulo.Where(X => X.Codigo.Equals(articulo.Codigo)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                articulo = Normalizar(articulo);
                Db.Articulo.Add(articulo);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Articulo>> Listar()
        {
            var respuesta = await Db.Articulo.ToListAsync();
            return respuesta;
        }
        public async Task<Articulo?> Leer(string codigo)
        {
            var respuesta = await Db.Articulo.Where(X => X.Codigo.Equals(codigo)).FirstOrDefaultAsync();
            return respuesta;
        }
        public async Task<bool> Eliminar(string codigo)
        {
            var respuesta = await Db.Articulo.Where(X => X.Codigo.Equals(codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
            else
            {
                Db.Articulo.Remove(respuesta);
                await Db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Modificar(Articulo dato)
        {
            var respuesta = await Db.Articulo.Where(X => X.Codigo.Equals(dato.Codigo)).FirstOrDefaultAsync();
            if (respuesta == null) return false;
         
            respuesta = Normalizar(respuesta);

            Db.Articulo.Update(respuesta);
            await Db.SaveChangesAsync();
            return true;
        }

        static private Articulo Normalizar(Articulo dato)
        {
            dato.Descri = dato.Descri.ToUpper();
            return dato;
        }

    }
}
