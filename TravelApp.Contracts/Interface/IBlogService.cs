using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface IBlogService
    {
        IEnumerable<BlogSlicedDto> GetBlogs();
        BlogDto GetBlog(int id);
        void CreateBlog(BlogDto blog);
        void EditBlog(BlogDto blog);
        void Delete(int id);
        void SaveBlog();
    }
}
