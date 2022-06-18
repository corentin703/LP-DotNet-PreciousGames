using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    public class GameEditionViewModel
    {
        [Required]
        public GameViewModel Game { get; set; }
        public List<SelectListItem> Editors { get; set; }
        public List<SelectListItem> Kinds { get; set; }
    }
}