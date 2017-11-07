using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Infrastructure
{
    public interface IImageRepository
    {
        void Create(Image entity,int attractionId);
        void Delete(int id);
        Image GetById(int id);
        IEnumerable<Image> GetAll(int attractionId);
    }
}
