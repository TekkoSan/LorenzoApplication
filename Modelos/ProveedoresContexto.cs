using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication.Modelos
{
    public class ProveedoresContexto : DbContext
    {

        public ProveedoresContexto(DbContextOptions<ProveedoresContexto> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Provee> Provee { get; set; }
    }
}
