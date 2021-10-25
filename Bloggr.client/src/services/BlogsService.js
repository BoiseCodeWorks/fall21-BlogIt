import { AppState } from "../AppState.js";
import { api } from "./AxiosService.js";

class BlogsService {
  async get() {
    const res = await api.get('api/blogs')
    AppState.blogs = res.data
  }
  async getById(id) {
    const res = await api.get('api/blogs/' + id)
    AppState.blog = res.data
  }
  async getTagsByBlogId(id) {
    const res = await api.get('api/blogs/' + id + '/tags')
    AppState.tags = res.data
  }


}

export const blogsService = new BlogsService()
