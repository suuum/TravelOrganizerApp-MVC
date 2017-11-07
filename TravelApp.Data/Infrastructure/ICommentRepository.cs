using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface ICommentRepository
    {
        void CreateBlogComment(Comment entity,string userId,int blogId);
        void CreateAttractionComment(Comment entity, string userId, int attractionId);
        void Edit(Comment entity);
        void Delete(int id);
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
    }
}