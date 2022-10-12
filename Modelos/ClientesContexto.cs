using LorenzoApplication.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication
{

    public class ClientesContexto : DbContext
    {

        public ClientesContexto(DbContextOptions<ClientesContexto> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Cliente> clientes { get; set; }

    }

}