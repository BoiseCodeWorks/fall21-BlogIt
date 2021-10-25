using System;
using System.Collections.Generic;
using Bloggr.Models;
using Bloggr.Repositories;

namespace Bloggr.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _blogsRepository;
    private readonly ProfilesService _profilesService;
    private readonly BlogTagsService _bs;


    public BlogsService(BlogsRepository blogsRepository, ProfilesService profilesService, BlogTagsService bs)
    {
      _blogsRepository = blogsRepository;
      _profilesService = profilesService;
      _bs = bs;
    }
    public List<Blog> GetAll()
    {
      return _blogsRepository.Get();
    }
    public Blog GetById(int blogId)
    {
      Blog foundBlog = _blogsRepository.Get(blogId);
      if (foundBlog == null)
      {
        throw new Exception("Can't find the blog");
      }
      return foundBlog;
    }
    public Blog Post(Blog blogData)
    {
      return _blogsRepository.Create(blogData);
    }
    public Blog Edit(int blogId, Blog blogData)
    {
      var blog = GetById(blogId);
      blog.Title = blogData.Title ?? blog.Title;
      blog.Body = blogData.Body ?? blog.Body;
      blog.ImgUrl = blogData.ImgUrl ?? blog.ImgUrl;
      blog.Published = blogData.Published;
      _blogsRepository.Edit(blogId, blogData);
      return blog;
    }
    public void Delete(int blogId, string userId)
    {
      Blog blog = GetById(blogId);
      if (blog.CreatorId != userId)
      {
        throw new Exception("not authorized");
      }
      _blogsRepository.Delete(blogId);
    }

    internal void AddBlogTag(int blogId, BlogTag data)
    {
      Blog b = GetById(blogId);
      _bs.Create(data);
    }

    // public List<Blog> GetBlogByProfile(string profileId)
    // {
    //   return _blogsRepository.GetBlogByProfile(profileId);
    // }

    // public List<Blog> GetBlogByAccount(string userId)
    // {
    //   return _blogsRepository.GetBlogByAccount(userId);
    // }
  }
}
