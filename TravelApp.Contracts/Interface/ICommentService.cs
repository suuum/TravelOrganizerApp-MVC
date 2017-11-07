using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentWithAttractionId(int attractionId);
        CommentDto GetComment(int id);
        void CreateBlogComment(CommentDto comment);
        void CreateAttractionComment(CommentDto comment);
        void EditComment(CommentDto comment);
        void Delete(int id);
        void SaveComment();
    }
}
