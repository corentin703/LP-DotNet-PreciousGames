using System.ComponentModel.DataAnnotations;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Web.Models.EditorModels
{
    public class EditorViewModel
    {
        public int Id { get; }

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