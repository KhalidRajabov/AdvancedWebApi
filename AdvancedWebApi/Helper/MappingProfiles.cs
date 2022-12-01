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
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Reviewer, ReviewerDTO>();
        }
    }
}
