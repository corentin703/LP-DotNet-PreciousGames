using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.KindModels
{
    public class KindViewModel
    {
        [Display(Name = "Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public string Name { get; set; }

        public KindViewModel()
        {
            //
        }

        public KindViewModel(Kind kind)
        {
            Id = kind.Id;
            Name = kind.Name;
        }
    }
}