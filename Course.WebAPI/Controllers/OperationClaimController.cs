using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpPost("Create")]
        public Task<IActionResult> Add([FromBody] CreatedOperationClaim createdOperationClaim)
        {

        }
    }
}
