using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.Enums;

namespace TravelApp.Entities.Model
{
    public interface IEntityBase
    {
        int Id { get; set; }
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
