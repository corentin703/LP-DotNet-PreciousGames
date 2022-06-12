using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.EditorModels
{
    public class EditorViewModel
    {
        [Display(Name = "#")]
        [Required]
        public int Id { get; }

        [Display(Name = "Nom")]
        [Required]
        public string Name { get; set; }

        public EditorViewModel()
        {
            //
        }

        public EditorViewModel(Editor editor)
        {
            Id = editor.Id;
            Name = editor.Name;
        }
    }
}