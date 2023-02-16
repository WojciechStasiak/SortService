using Microsoft.AspNetCore.Mvc;
using SortService.Services;

namespace SortService.Controllers
{
    // main controller of the service 
    [ApiController]
    [Route("sorting")]
    public class SortController : ControllerBase
    {
        readonly ISortService _sortService;

        public SortController(ISortService sortService)
        {
            _sortService = sortService;
        }


        [HttpGet("sort/{multipleValues}")]
        public List<int> Sort(string multipleValues)
        {
            return _sortService.Sort(multipleValues);
        }

        [HttpGet("reverse/{multipleValues}")]
        public List<int> Reverse(string multipleValues)
        {
            return _sortService.Reverse(multipleValues);
        }

    }
}
