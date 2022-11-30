using AdvancedWebApi.DTO;
using AdvancedWebApi.Models;
using AutoMapper;

namespace AdvancedWebApi.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
        }
    }
}
