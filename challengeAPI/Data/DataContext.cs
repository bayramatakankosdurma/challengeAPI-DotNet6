using challengeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace challengeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urunler> Urunler{ get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
    }

}
