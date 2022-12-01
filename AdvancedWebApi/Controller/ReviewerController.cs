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
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviews()
        {
            var reviewers = _mapper.Map<List<ReviewerDTO>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExist(reviewerId))
            {
                return NotFound();
            }

            var review = _mapper.Map<ReviewerDTO>(_reviewerRepository.GetReviewer(reviewerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(review);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewerByAReviewer(int reviewerId)
        {
            var reviewer = _mapper.Map<List<ReviewDTO>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(reviewer);
        }
    }
}
