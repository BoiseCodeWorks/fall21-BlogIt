using System;
using System.Collections.Generic;
using System.Data;
using Bloggr.Interfaces;
using Bloggr.Models;

namespace Bloggr.Repositories
{
  public class CommentsRepository : DbContext, IRepository<Comment>
  {
    public CommentsRepository(IDbConnection db) : base(db)
    {
    }

    public Comment Create(Comment data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Comment Edit(int id, Comment data)
    {
      throw new System.NotImplementedException();
    }

    internal List<Comment> GetByBlogId(int blogId)
    {
      throw new NotImplementedException();
    }

    public List<Comment> Get()
    {
      throw new System.NotImplementedException();
    }

    public Comment Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}