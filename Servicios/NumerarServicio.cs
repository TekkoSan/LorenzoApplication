using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication.Servicios
{

    public interface INumerarServicio
    {
        Task<string> NuevoCodigo(string numerador);

    }

    public class NumerarServicio : INumerarServicio
    {

        private readonly LorenzoContexto _db;
        public NumerarServicio(LorenzoContexto db) 
        {
            _db = db;
        }

        public async Task<string> NuevoCodigo(string numerador)
        {
            numerador = numerador.ToUpper();
            var ultimo = await _db.Numerar.Where(X => X.Numerador.Equals(numerador)).FirstOrDefaultAsync();
            if (ultimo == null)
            {
                ultimo = new Numerar();
                ultimo.Numerador = numerador;
                ultimo.Valor = 1;
                _db.Add(ultimo);
            }
            else
            {
                ultimo.Valor = ultimo.Valor + 1;
                _db.Update(ultimo);
            }
            await _db.SaveChangesAsync();
            return ultimo.Valor.ToString("D04");
        }
    }
}
