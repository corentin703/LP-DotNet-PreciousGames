using System.Collections.Generic;

namespace Web.Models.EditorModels
{
    public class IndexViewModel
    {
        public IEnumerable<EditorViewModel> Editors { get; set; }
        public int EditorCount { get; set; }
    }
}