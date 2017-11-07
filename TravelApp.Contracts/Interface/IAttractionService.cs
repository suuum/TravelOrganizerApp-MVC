using System.Collections.Generic;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface IAttractionService
    {        
        IEnumerable<AttractionDto> GetAttractions();
        IEnumerable<AttractionDto> GetAdminAttractions();
        IEnumerable<AttractionDto> GetAttractionByCityId(int id);
        
        AttractionDto GetAttraction(int id);
        void SetAttractionVisible(int id);
        void CreateAttraction(AttractionDto attraction);
        void DeleteAttraction(int id);
        void EditAttraction(AttractionDto attraction);
        void SaveAttraction();
    }
}