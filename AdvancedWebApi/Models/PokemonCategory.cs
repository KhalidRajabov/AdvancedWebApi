namespace AdvancedWebApi.Models
{
    public class PokemonCategory
    {
        public int Pokemonİd { get; set; }
        public int Categoryİd { get; set; }
        public Pokemon? Pokemon { get; set; }
        public Category? Category { get; set; }
    }
}
