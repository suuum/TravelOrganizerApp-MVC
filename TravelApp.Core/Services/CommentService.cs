using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;
using TravelApp.Data.Repositories;
using TravelApp.Entities.Model;
using AutoMapper;
namespace TravelApp.Core.Services
{
    public class CommentService : ICommentService
    {
        ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void CreateBlogComment(CommentDto comment)
        {
            _commentRepository.CreateBlogComment(new Comment()
            {
                Content = comment.Content,
                 CreateDate=DateTime.Now
            },comment.UserDto.Id, comment.BlogDto.Id);
        }
        public void CreateAttractionComment(CommentDto comment)
        {
            _commentRepository.CreateAttractionComment(new Comment()
            {
                Content = comment.Content,
                CreateDate = DateTime.Now
            }
            ,comment.UserDto.Id,comment.Attraction.Id);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void EditComment(CommentDto comment)
        {
            throw new NotImplementedException();
        }

        public CommentDto GetComment(int id)
        {
            var entityDto = Mapper.Map<Comment, CommentDto>(_commentRepository.GetById(id));
            entityDto.UserDto = Mapper.Map<UserInfo, UserDto>(_commentRepository.GetById(id).User);
            return entityDto;
        }

        public IEnumerable<CommentDto> GetCommentWithAttractionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public void SaveComment()
        {
            throw new NotImplementedException();
        }
    }
}
