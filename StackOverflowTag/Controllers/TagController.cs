using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using StackOverflowTag.Class.DTO;
using StackOverflowTag.Services.Interface;

namespace StackOverflowTag.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IFetchService _fetchService;

        public TagController(ITagRepository tagRepository, IFetchService fetchService)
        {
            _tagRepository = tagRepository;
            _fetchService = fetchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string sortBy = GlobalVariables.Fields.Name, [FromQuery] bool desc = true)
        {
            if (page < 0 || pageSize < 0 || pageSize * (page + 1) > GlobalVariables.AmountOfTags)
            {
                return BadRequest($"Page and PageSize should be grater then 0 and pageSize * (page + 1) less than {GlobalVariables.AmountOfTags}");
            }
            var tags = await _tagRepository.GetPaginationTags(page, pageSize, sortBy, desc);
            return Ok(tags);
        }

        [HttpPost("/retrieve")]
        public async Task<IActionResult> RetrieveTags([FromQuery] int amount)
        {
            await _fetchService.FetchTags(amount);

            return Ok("Tags are fetched.");
        }
    }
}