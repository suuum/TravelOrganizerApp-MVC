using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface IFavouriteService
    {
        AttractionDto GetFavouritesByUserId(string id);
        void CreateFavourite(FavouriteDto entity);
        void DeleteFavourite(FavouriteDto entity);
        AttractionDto GetById(int id);
        IEnumerable<FavouriteDto> GetAll();
        IEnumerable<AttractionDto> GetAllByUserId(string id);
        bool CheckIfIsFavourite(int attractionId, string userId);
    }
}
