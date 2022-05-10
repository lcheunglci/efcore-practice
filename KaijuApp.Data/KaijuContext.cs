using KaijuApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace KaijuApp.Data
{
    public class KaijuContext : DbContext
    {
        public DbSet<Kaiju> Kaijus { get; set; }
        public DbSet<Ability> Abilities { get; set; }
    }
}