namespace Bloggr.Models
{
  public class Blog : DBItem<int>
  {
    public string Title { get; set; }
    public string Body { get; set; }
    public string ImgUrl { get; set; }
    public bool Published { get; set; } = false;
    public string CreatorId { get; set; }

    public Profile Profile { get; set; }
  }

}

