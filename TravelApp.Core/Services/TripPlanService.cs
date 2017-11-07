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
    public class TripPlanService : ITripPlanService
    {
        ITripRepository _tripPlanRepository;
        IUserRepository _userRepository;
        public TripPlanService(ITripRepository tripPlanRepository,IUserRepository userRepository)
        {
            _tripPlanRepository = tripPlanRepository;
            _userRepository = userRepository;
        }

        public TripPlanDto GetTripPlanById(int id)
        {
           return Mapper.Map<TripPlan,TripPlanDto>( _tripPlanRepository.GetById(id));
        }

        public void Create(TripPlanDto tripPlanDto) {
            _tripPlanRepository.Create(
                new TripPlan() {
                    PdfFile=tripPlanDto.PdfFile,                
                    CreateDate=tripPlanDto.CreateDate,
                    HoursPerDay=tripPlanDto.HoursPerDay,
                    Transport=tripPlanDto.Transport,
                    Directions=tripPlanDto.Directions,
                    GuidId = tripPlanDto.GuidId
                },tripPlanDto.User.Id
                );

        }

        public TripPlanDto GetByGuid(Guid guid)
        {
            return Mapper.Map<TripPlan,TripPlanDto>(_tripPlanRepository.GetIdByGuid(guid));
        }
    }
}
