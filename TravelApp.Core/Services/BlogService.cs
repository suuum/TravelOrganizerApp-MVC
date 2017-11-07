using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;
using TravelApp.Data.Infrastructure;
using TravelApp.Data.Repositories;
using TravelApp.Entities.Model;

namespace TravelApp.Core.Services
{
    public class BlogService : IBlogService
    {
        IBlogRepository _blogRepository;
        IUserRepository _userRepository;
        ICommentService _commentService;
        public BlogService(IBlogRepository blogRepository, IUserRepository userRepository, ICommentService commentService)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
            _commentService = commentService;
        }

        public void CreateBlog(BlogDto blog)
        {
            Blog newblog = new Blog()
            {
                Name = blog.Name,
                Content = blog.Content,
                BlogCoverPhoto = blog.BlogCoverPhoto,
                ShortContent = blog.ShortContent
            };

            _blogRepository.Create(newblog, blog.User.Id);
        }

        public void Delete(int id)
        {
            _blogRepository.Delete(id);
        }

        public void EditBlog(BlogDto blog)
        {
            Blog newblog = new Blog()
            {
                Id =blog.Id,
                Name = blog.Name,
                Content = blog.Content,
                BlogCoverPhoto=blog.BlogCoverPhoto,
                ShortContent=blog.ShortContent,                
                User = new UserInfo()
                {
                    Id = blog.User.Id,
                    BirthDate=DateTime.Now
                    
                }
            };
            _blogRepository.Edit(newblog);
        }

        public BlogDto GetBlog(int id)
        {BlogDto entityDto = Mapper.Map<Blog, BlogDto>(_blogRepository.GetById(id));
            foreach(var item in entityDto.Comment)
            {
                item.UserDto = _commentService.GetComment(item.Id).UserDto;

            }
            return entityDto;
        }

        public IEnumerable<BlogSlicedDto> GetBlogs()
        {
            return Mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSlicedDto>>(_blogRepository.GetAll());
        }

        public void SaveBlog()
        {

        }
    }
}
