using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
namespace LorenzoApplication
{
    public class LorenzoContexto : DbContext
    {
        public LorenzoContexto(DbContextOptions<LorenzoContexto> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Numerar> Numerar { get; set; }
        public DbSet<Provee> Provee { get; set; }
        public DbSet<Cmp_Ven> Cmp_Ven { get; set; }
        public DbSet<Ven_Fac> Ven_Fac { get; set; }

    }
}
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
