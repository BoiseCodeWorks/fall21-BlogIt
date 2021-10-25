namespace Bloggr.Models
{
  public class BlogTag : DBItem<int>
  {
    public int BlogId { get; set; }
    public int TagId { get; set; }
    public Blog Blog { get; set; }
    public Tag Tag { get; set; }
  }
}

