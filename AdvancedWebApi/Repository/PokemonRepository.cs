using AdvancedWebApi.Data;
using AdvancedWebApi.Interfaces;
using AdvancedWebApi.Models;

namespace AdvancedWebApi.Repository
{
    public class PokemonRepository:IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owner.FirstOrDefault(a => a.Id == ownerId);
            var category = _context.Categories.FirstOrDefault(a => a.Id == categoryId);

            var pokemonOwner = new PokemonOwner()
            {
                Owner= pokemonOwnerEntity,
                Pokemon = pokemon
            };
            _context.Add(pokemonOwner);
            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon= pokemon
            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return true;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.FirstOrDefault(p => p.Id == id);
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.FirstOrDefault(p => p.Name == name);
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);
            if (review.Count()<=0)
            {
                return 0;
            }
            return (decimal)review.Sum(r => r.Rating) / review.Count();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p=>p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
