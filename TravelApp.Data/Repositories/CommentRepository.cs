using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        

        public void Delete(int id)
        {
            Comment deleteComment = DbContext.Comment.Find(id);
            DbContext.Comment.Remove(deleteComment);
            DbContext.SaveChanges();
        }

        public void Edit(Comment entity)
        {
            Comment updateComment = DbContext.Comment.Find(entity.Id);
            updateComment.Content = entity.Content;
            updateComment.Attraction = entity.Attraction;
            updateComment.User = entity.User;
            DbContext.Entry(updateComment).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public override Comment GetById(int id)
        {
            return DbContext.Comment.Include("User").Single(x => x.Id == id);
        }

 
        public override IEnumerable<Comment> GetAll()
        {
            return DbContext.Comment;
        }

        public void CreateBlogComment(Comment entity, string userId, int blogId)
        {
            entity.User = DbContext.UserInfo.Single(x=>x.Id == userId);
            entity.Blog = DbContext.Blog.Single(x => x.Id == blogId);
            DbContext.Comment.Add(entity);
            DbContext.SaveChanges();

        }

        public void CreateAttractionComment(Comment entity, string userId, int attractionId)
        {
            entity.User = DbContext.UserInfo.Single(x => x.Id == userId);
            entity.Attraction = DbContext.Attraction.Single(x => x.Id == attractionId);
            DbContext.Comment.Add(entity);
            DbContext.SaveChanges();

        }
    }
}
