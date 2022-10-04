using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication
{

    public class ArticulosContexto : DbContext
    {

        public ArticulosContexto(DbContextOptions<ArticulosContexto> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Articulo> Articulo { get; set; }

    }

}
