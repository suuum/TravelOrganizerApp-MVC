using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Infrastructure
{
    public interface IUserRepository
    {
        List<UserInfo> GetUsers();
        UserInfo GetUser(string id);
    }
}
