using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.Entities
{
    public class Kind
    {
        public int Id{ get; set; }

        public string Name{ get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
