using MNODotNetCore.RestApiWithNLayer.Databases;
using System.Reflection.Metadata;

namespace MNODotNetCore.RestAPIwithNLayer.Features.Blog
{
    public class DataAccess_Blog
    {
        private readonly AppDbContext _context;
        public DataAccess_Blog()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var list = _context.Blog.ToList();
            return list;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blog.Add(requestModel);
           var result = _context.SaveChanges();
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if(item is null) { return 0; }

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null) { return 0; }

            _context.Blog.Remove(item);

            var result = _context.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null) { return 0; }

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}
