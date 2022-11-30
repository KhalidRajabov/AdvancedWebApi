using AdvancedWebApi.Data;
using AdvancedWebApi.Interfaces;
using AdvancedWebApi.Models;
using AutoMapper;

namespace AdvancedWebApi.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CountryExist(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c=>c.Id).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owner.Select(o => o.Country).FirstOrDefault(o => o.Id == ownerId);
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owner.Where(c=>c.Country.Id==countryId).ToList();
        }
    }
}
