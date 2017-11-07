using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface IRankService
    {
        RankDto GetRankWithAttractionIdAndUserId(int attractionId,string userId);
        RankDto GetRank(int id);
        void CreateRank(RankDto rank);
        void EditRank(RankDto rank);
        void Delete(int id);
        bool CheckIfHaveRank(int attractionId, string userId);
        void SaveRank();
    }
}
