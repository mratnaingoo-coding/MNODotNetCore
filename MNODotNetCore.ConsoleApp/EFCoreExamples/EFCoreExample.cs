using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNODotNetCore.ConsoleApp.Dtos;

namespace MNODotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
   /*     private readonly AppDbContext appDbContext = new AppDbContext();*/
          private readonly AppDbContext appDbContext;

        public EFCoreExample(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(25);
            // Create("testTitle10", "testAuthor10", "testContent10");
            // Update(1003,"testTitle11", "testAuthor12", "testContent13");
            Delete(1003);
        }
        public void Read()
        {

            var lst = appDbContext.Blog.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("----------------------------------");
            }
        }
        public void Edit(int id)
        {
            var item = appDbContext.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data was found");
                return;
            }
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("----------------------------------");

        }
        public void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            appDbContext.Blog.Add(item);
            int result = appDbContext.SaveChanges();
            string message = result > 0 ? "Saving success." : "Saving fail.";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            var item = appDbContext.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data was found");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;



            int result = appDbContext.SaveChanges();

            string message = result > 0 ? "Updating success." : "Updating fail.";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            var item = appDbContext.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data was found");
                return;
            }
            appDbContext.Blog.Remove(item);
            int result = appDbContext.SaveChanges();

            string message = result > 0 ? "Deleting success." : "Deleting fail.";
            Console.WriteLine(message);
        }
    }
}
