using System.ComponentModel.DataAnnotations;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Web.Models.EditorModels
{
    public class EditorViewModel
    {
        [Required]
        public string Name { get; set; }

        public EditorViewModel()
        {
            //
        }

        public EditorViewModel(Editor editor)
        {
            Name = editor.Name;
        }
    }
}