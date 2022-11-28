using AdvancedWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PokemonCategory>().HasKey(pc => new { pc.Pokemonİd, pc.Categoryİd });
            builder.Entity<PokemonCategory>().HasOne(p => p.Pokemon).WithMany(pc => pc.PokemonCategories).HasForeignKey(c => c.Pokemonİd);
            builder.Entity<PokemonCategory>().HasOne(p=>p.Category).WithMany(pc=>pc.PokemonCategories).HasForeignKey(c=>c.Categoryİd);

            builder.Entity<PokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });
            builder.Entity<PokemonOwner>().HasOne(p => p.Pokemon).WithMany(po => po.PokemonOwners).HasForeignKey(c => c.PokemonId);
            builder.Entity<PokemonOwner>().HasOne(p => p.Owner).WithMany(po => po.PokemonOwners).HasForeignKey(c => c.OwnerId);
        }
    }
}
