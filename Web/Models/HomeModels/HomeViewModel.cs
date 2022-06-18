using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.HomeModels
{
    public class HomeViewModel
    {
        /*[Display(Name = "Evaluations")]
        [Required]
        public List<Evaluation> Evaluations { get; set; }

        [Display(Name = "Games")]
        [Required]
        public List<Game> Games { get; set; }
*/
        public HomeViewModel()
        {
            //
        }

        /*public HomeViewModel(Kind kind)
        {
            Id = kind.Id;
            Name = kind.Name;
        }*/
    }
}