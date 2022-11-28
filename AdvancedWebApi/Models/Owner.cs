namespace AdvancedWebApi.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Gym { get; set; }
        public Country? Country { get; set; }
        public ICollection<PokemonOwner>? PokemonOwners { get; set; }
    }
}
