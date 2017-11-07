using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;
using TravelApp.Contracts.DTO;
namespace TravelApp.Data.Repositories
{
    public class UserRepository : RepositoryBase<UserDto>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public UserInfo GetUser(string id)
        {
            return DbContext.UserInfo.Single(x => x.Id==id);
        }

        public List<UserInfo> GetUsers()
        {
          var users= DbContext.UserInfo.Include("ApplicationUser").Include("IdentityUserRole").ToList();
            //przez userinfo nie moge dostac sie do rol moge stworzyc atrybut IdentityUserRoles tylko powtorze to w dwoch klasach ale to najprostrze wyjscie

           return users;
        }
    }
}
