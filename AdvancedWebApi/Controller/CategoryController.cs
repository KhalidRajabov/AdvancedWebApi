using AdvancedWebApi.DTO;
using AdvancedWebApi.Interfaces;
using AdvancedWebApi.Models;
using AdvancedWebApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetAllCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetAllCategories());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int categoryId)
        {
            if (!_categoryRepository.CategoryExist(categoryId))
            {
                return NotFound();
            }

            var cateogry = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cateogry);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId) 
        {
            var pokemons = _mapper.Map<List<Pokemon>>(_categoryRepository.GetPokemonByCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }


        [HttpPost,ProducesResponseType(204), ProducesResponseType(400)]
        public IActionResult CreateCateogry([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest(ModelState);
            var category = _categoryRepository.GetAllCategories()
                .Where(c=>c.Name.Trim().ToLower()==categoryDTO.Name.TrimEnd().ToLower()).FirstOrDefault();
            if (category!=null)
            {
                ModelState.AddModelError("", "Category Already Exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryDTO);
            if (!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong on saving");
                return StatusCode(500, ModelState);
            }

            return StatusCode(422, ModelState);
        }
    }
}
