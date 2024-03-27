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

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string sortBy = GlobalVariables.Fields.Name, [FromQuery] bool desc = true)
        {
            if (page < 0 || pageSize < 0 || pageSize * page > GlobalVariables.AmountOfTags)
            {
                return BadRequest($"Page and PageSize should be grater then 0 and pageSize * page less than {GlobalVariables.AmountOfTags}");
            }
            var tags = await _tagRepository.GetPaginationTags(page, pageSize, sortBy, desc);
            return Ok(tags);
        }
    }
}