using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;
using TravelApp.Data.Repositories;
using TravelApp.Entities.Model;

namespace TravelApp.Core.Services
{
    public class FavouriteService : IFavouriteService
    {
        IFavouriteRepository _favouriteRepository;
        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        public bool CheckIfIsFavourite(int attractionId, string userId)
        {
        var attractionList  = _favouriteRepository.GetAllByUserId(userId);
            return attractionList.SingleOrDefault(x=>x.Id==attractionId) != null ? true : false ;
        }

        public void CreateFavourite(FavouriteDto entity)
        {
            _favouriteRepository.Create(entity.Attraction.Id,entity.UserDto.Id);
        }

        public void DeleteFavourite(FavouriteDto entity)
        {
            _favouriteRepository.Delete(entity.Attraction.Id, entity.UserDto.Id);
        }

        public IEnumerable<FavouriteDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttractionDto> GetAllByUserId(string id)
        {
            return Mapper.Map<IEnumerable<Attraction>, IEnumerable< AttractionDto>>(_favouriteRepository.GetAllByUserId(id));
        }

        public AttractionDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AttractionDto GetFavouritesByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
