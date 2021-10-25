using System.Collections.Generic;
using System.Data;
using Bloggr.Interfaces;
using Bloggr.Models;
using Dapper;

namespace Bloggr.Repositories
{
  public class BlogTagsRepository : DbContext, IRepository<BlogTag>
  {
    public BlogTagsRepository(IDbConnection db) : base(db)
    {
    }

    // TODO implement this
    public BlogTag Create(BlogTag data)
    {
      string sql = @"INSERT INTO blog_tags(
        blogId,
        tagId
      ) VALUES (
        @BlogId,
        @TagId
      );
      SELECT LAST_INSERT_ID();
      ";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public BlogTag Edit(int id, BlogTag data)
    {
      throw new System.NotImplementedException();
    }

    public List<BlogTag> Get()
    {
      throw new System.NotImplementedException();
    }

    public BlogTag Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}