using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bloggr.Interfaces;
using Bloggr.Models;
using Dapper;

namespace Bloggr.Repositories
{
  public class TagsRepository : DbContext, IRepository<Tag>
  {
    public TagsRepository(IDbConnection db) : base(db)
    {
    }

    public Tag Create(Tag data)
    {
      string sql = "INSERT INTO tags(name)VALUES(@Name); SELECT LAST_INSERT_ID()";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

    internal List<BlogTag> GetTagsByBlogId(int blogId)
    {
      string sql = @"
      SELECT bt.*, t.* FROM blog_tags bt
      
      JOIN tags t ON t.id = bt.tagId

      WHERE bt.blogId = @blogId";

      return _db.Query<BlogTag, Tag, BlogTag>(sql, (bt, t) =>
      {
        bt.Tag = t;
        return bt;
      }, new { blogId }).ToList();

    }



    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Tag Edit(int id, Tag data)
    {
      throw new System.NotImplementedException();
    }

    public List<Tag> Get()
    {
      throw new System.NotImplementedException();
    }

    public Tag Get(int id)
    {
      string sql = "SELECT * FROM tags WHERE id = @id";
      return _db.Query<Tag>(sql, new { id }).FirstOrDefault();
    }
    public Tag Get(string name)
    {
      string sql = "SELECT * FROM tags WHERE name = @name";
      return _db.QueryFirstOrDefault<Tag>(sql, new { name });
    }
  }
}