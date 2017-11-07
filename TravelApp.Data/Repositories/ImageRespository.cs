using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class ImageRespository : RepositoryBase<Image>, IImageRepository 
    {
        public ImageRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(Image entity,int attractionId)
        {
            entity.Attraction = DbContext.Attraction.Single(x => x.Id == attractionId);
            DbContext.Image.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAll(int attractionId)
        {
            throw new NotImplementedException();
        }

        public override Image GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
