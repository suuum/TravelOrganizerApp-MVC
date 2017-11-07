using System.ComponentModel.DataAnnotations.Schema;
using TravelApp.Contracts.Enums;

namespace TravelApp.Entities.Model
{
    public abstract class Entity:IEntityBase
    {
        public int Id { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}