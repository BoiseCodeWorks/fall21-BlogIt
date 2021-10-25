namespace Bloggr.Models
{
  public class Comment : DBItem<int>
  {
    public string Body { get; set; }
    public int BlogId { get; set; }
    public string CreatorId { get; set; }

    public Blog Blog { get; set; }
    public Profile Profile { get; set; }
  }
}

