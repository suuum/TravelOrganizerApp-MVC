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
    public class RankService : IRankService
    {
        IRankRepository _rankRepository;
        public RankService(IRankRepository rankRepository)
        {
            _rankRepository = rankRepository;
        }
        public bool CheckIfHaveRank(int attractionId, string userId)
        {
            var attractionList = _rankRepository.GetAllByUserId(userId);
            return attractionList.SingleOrDefault(x => x.Id == attractionId) != null ? true : false;
        }

        public void CreateRank(RankDto rank)
        {
            _rankRepository.Create(rank.Number,rank.Attraction.Id, rank.User.Id);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void EditRank(RankDto rank)
        {
            _rankRepository.Edit(rank.Number, rank.Attraction.Id, rank.User.Id);
        }

        public RankDto GetRank(int id)
        {
            throw new NotImplementedException();
        }

        public RankDto GetRankWithAttractionIdAndUserId(int attractionId, string userId)
        {
           return Mapper.Map<Rank,RankDto>(_rankRepository.GetById(attractionId,userId));
        }

        public void SaveRank()
        {
            throw new NotImplementedException();
        }
    }
}
