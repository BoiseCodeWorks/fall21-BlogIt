using Bloggr.Models;
using Bloggr.Repositories;

namespace Bloggr.Services
{
  public class BlogTagsService
  {
    private readonly BlogTagsRepository _btr;
    private readonly TagsService _ts;

    public BlogTagsService(BlogTagsRepository btr, TagsService ts)
    {
      _btr = btr;
      _ts = ts;
    }

    public BlogTag Create(BlogTag data)
    {
      Tag t = _ts.Get(data.TagId);
      return _btr.Create(data);
    }
  }
}