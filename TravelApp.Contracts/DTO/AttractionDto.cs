using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class AttractionDto
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa Atrakcji")]
        [Required(ErrorMessage ="Pole jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa jest zbyt krótka")]
        [MaxLength(80, ErrorMessage = "Nazwa jest zbyt długa")]
        public string Name { get; set; }
        [Display(Name = "Krótki opis atrakcji")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [MinLength(10, ErrorMessage = "Opis jest zbyt krótki")]
        [MaxLength(1000, ErrorMessage = "Opis jest zbyt długi")]
        public string Description { get; set; }
        [Display(Name = "Długi opis atrakcji")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [MinLength(20, ErrorMessage = "Opis jest zbyt krótki")]
        [MaxLength(4000, ErrorMessage = "Opis jest zbyt długi")]
        public string LongDescription { get; set; }
        [Display(Name = "Adres atrakcji")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Adress { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Średni czas zwiedzania")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(1,10,ErrorMessage ="Podany czas jest nieprawidłowy")]
        public int AvrHoursTime { get; set; }
        public string Photos { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        public CountryDto Country { get; set; }
        
        public CityDto City { get; set; }
        public IEnumerable<CommentDto> Comment { get; set; }
        public IEnumerable<FavouriteDto> Favourites { get; set; }
        public string[] PhotosArray { get; set; }
        public IEnumerable<RankDto> Ranks { get; set; }
        public string FilesToBeUploaded { get; set; }
    }
}