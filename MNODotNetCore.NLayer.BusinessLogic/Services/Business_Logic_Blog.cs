using MNODotNetCore.NLayer.DataAccess.Services;
using MNODotNetCore.NLayer.DataAccess.Models;


namespace MNODotNetCore.NLayer.BusinessLogic.Services
{
    public class Business_Logic_Blog
    {
        private readonly DataAccess_Blog _dataAccess_Blog;
        public Business_Logic_Blog()
        {
            _dataAccess_Blog = new DataAccess_Blog();
        }
        public List<BlogModel> GetBlogs()
        {
            var list = _dataAccess_Blog.GetBlogs();
            return list;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _dataAccess_Blog.GetBlog(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var result = _dataAccess_Blog.CreateBlog(requestModel);
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var result = _dataAccess_Blog.UpdateBlog(id, requestModel);
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _dataAccess_Blog.PatchBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {
            var result = _dataAccess_Blog.DeleteBlog(id);
            return result;
        }
    }

}
