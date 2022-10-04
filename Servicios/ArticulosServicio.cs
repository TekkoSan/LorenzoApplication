using Microsoft.EntityFrameworkCore;
using LorenzoApplication.Modelos;

namespace LorenzoApplication.Servicios
{

    public interface IArticulosServicio
    {
        public Task<bool> Agregar(Articulo artículo);
        public Task<List<Articulo>> Listar();
    }


    public class ArticulosServicio : IArticulosServicio
    {
        private ArticulosContexto Db;

        public ArticulosServicio(ArticulosContexto articulosContexto)
        {
            Db = articulosContexto;
        }
        public async Task<bool> Agregar(Articulo artículo)
        {
            var respuesta = await Db.Articulo.Where(X => X.Id.Equals(artículo.Id)).FirstOrDefaultAsync();
            if (respuesta != null) return false;
            else
            {
                Db.Articulo.Add(artículo);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Articulo>> Listar()
        {
            var respuesta = await Db.Articulo.ToListAsync();
            return respuesta;
        }
    }
}
