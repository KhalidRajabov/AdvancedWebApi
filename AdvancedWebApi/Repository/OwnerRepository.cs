using AdvancedWebApi.Data;
using AdvancedWebApi.Interfaces;
using AdvancedWebApi.Models;

namespace AdvancedWebApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Owner> GetAnOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p=>p.Pokemon.Id==pokeId).Select(p=>p.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByAnOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p=>p.Owner.Id==ownerId).Select(p=>p.Pokemon).ToList();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owner.FirstOrDefault(o=> o.Id == ownerId);
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owner.ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owner.Any(o=>o.Id==ownerId);
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0?true:false;
        }
    }
}
