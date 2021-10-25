using System.Collections.Generic;
using Bloggr.Models;
using Bloggr.Repositories;

namespace Bloggr.Services
{
  public class TagsService
  {
    private readonly TagsRepository _tr;

    public TagsService(TagsRepository tr)
    {
      _tr = tr;
    }

    public Tag Create(Tag data)
    {
      return _tr.Create(data);
    }

    public Tag Get(int id)
    {
      var tag = _tr.Get(id);
      if (tag == null)
      {
        throw new System.Exception("Bad Tag Id");
      }
      return tag;
    }

    public List<BlogTag> GetByBlogId(int blogId)
    {
      return _tr.GetTagsByBlogId(blogId);
    }

  }
}