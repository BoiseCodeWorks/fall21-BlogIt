using Bloggr.Models;
using Bloggr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagsController : ControllerBase
  {

    private readonly TagsService _ts;

    public TagsController(TagsService ts)
    {
      _ts = ts;
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Tag> Create([FromBody] Tag data)
    {
      try
      {
        var tag = _ts.Create(data);
        return Created("api/tags/" + tag.Id, tag);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}