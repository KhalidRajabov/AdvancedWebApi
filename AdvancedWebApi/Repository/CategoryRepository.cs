using AdvancedWebApi.Data;
using AdvancedWebApi.Interfaces;
using AdvancedWebApi.Models;

namespace AdvancedWebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c=>c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c=>c.Id==id);
        }

        public ICollection<Pokemon> GetPokemonByCategory(int CategoryId)
        {
            return _context.PokemonCategories.Where(pc=>pc.Categoryİd==CategoryId).Select(c=>c.Pokemon).ToList();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved>0?true: false;
        }
    }
}
