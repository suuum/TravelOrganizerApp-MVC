using AutoMapper;
using System.Collections.Generic;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;
using TravelApp.Data.Infrastructure;
using TravelApp.Data.Repositories;
using TravelApp.Entities.Model;
using System;

namespace TravelApp.Core.Services
{
    public class AttractionService:IAttractionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAttractionRepository _attractionRepository;
        private readonly ICommentService _commentService;

        public AttractionService(IUnitOfWork unitOfWork, IAttractionRepository attractionRepository,ICommentService commentService)
        {
            this.unitOfWork = unitOfWork;
            this._attractionRepository = attractionRepository;
            this._commentService = commentService;
        }

        public IEnumerable<AttractionDto> GetAttractions()
        {
           return Mapper.Map<IEnumerable<Attraction>,IEnumerable<AttractionDto>>(_attractionRepository.GetAll());
        }
        public IEnumerable<AttractionDto> GetAdminAttractions()
        {
            return Mapper.Map<IEnumerable<Attraction>, IEnumerable<AttractionDto>>(_attractionRepository.GetAdminAll());
        }

        
        public AttractionDto GetAttraction(int id)
        {
           AttractionDto attraction = Mapper.Map<Attraction, AttractionDto>(_attractionRepository.GetById(id));
            foreach (var item in attraction.Comment)
            {
                item.UserDto = _commentService.GetComment(item.Id).UserDto;

            }
            attraction.PhotosArray = attraction.Photos.Split(',');
           return attraction ;
        }
        public IEnumerable<AttractionDto> GetAttractionByCityId(int id)
        {
            return Mapper.Map< IEnumerable<Attraction>, IEnumerable<AttractionDto>>(_attractionRepository.GetByCityId(id));
        }

        public void CreateAttraction(AttractionDto attraction)
        {
            _attractionRepository.Create(new Attraction() {
                Name = attraction.Name,
                Description= attraction.Description,
                City = new City() {
                    Id =attraction.City.Id
                },
                Country = new Country() {
                    Id =attraction.Country.Id
                },
                Photos= attraction.Photos,
                Adress= attraction.Adress,
                AvrHoursTime= attraction.AvrHoursTime,
                LongDescription= attraction.LongDescription,
                IsActive= attraction.IsActive
                
            });
        }

        public void DeleteAttraction(int id)
        {
            _attractionRepository.Delete(_attractionRepository.GetById(id));
        }

        public void EditAttraction(AttractionDto attraction)
        {
            _attractionRepository.Edit(new Attraction()
            {
                Id= attraction.Id,
                Name = attraction.Name,
                Description = attraction.Description,
                City = new City()
                {
                    Id = attraction.City.Id
                },
                Country = new Country()
                {
                    Id = attraction.Country.Id
                }
            });
        }

        public void SaveAttraction()
        {
            unitOfWork.Commit();
        }

        public void SetAttractionVisible(int id)
        {
            _attractionRepository.SetVisible(id);
        }
    }
}