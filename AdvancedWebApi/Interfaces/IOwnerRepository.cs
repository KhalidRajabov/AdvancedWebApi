using AdvancedWebApi.Models;

namespace AdvancedWebApi.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetAnOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonsByAnOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool Save();
    }
}
