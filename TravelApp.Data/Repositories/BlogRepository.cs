using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(Blog entity, string userId)
        {
            try
            {
                entity.User = DbContext.UserInfo.Single(x => x.Id == userId);
                DbContext.Blog.Add(entity);
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Delete(int id)
        {
            Blog deleteBlog = DbContext.Blog.Find(id);
            DbContext.Blog.Remove(deleteBlog);
            DbContext.SaveChanges();
        }

        public void Edit(Blog entity)
        {
            Blog updateBlog = DbContext.Blog.Find(entity.Id);
            updateBlog.Name = entity.Name;
            updateBlog.ShortContent = entity.ShortContent;
           // updateBlog.BlogCoverPhoto = entity.BlogCoverPhoto;
            updateBlog.Content = entity.Content;
            updateBlog.Comment = entity.Comment;
            DbContext.Entry(updateBlog).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public override Blog GetById(int id)
        {
            return DbContext.Blog.Include("Comment").Include("User").Single(x => x.Id == id);
        }

        public override IEnumerable<Blog> GetAll()
        {
            return DbContext.Blog.Include("User");
        }
    }
}
