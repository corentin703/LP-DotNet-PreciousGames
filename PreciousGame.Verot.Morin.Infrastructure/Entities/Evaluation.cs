using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.Entities
{
    public class Evaluation
    {
        public int Id{ get; set; }
        public string EvaluatorName{ get; set; }
        public DateTime Date{ get; set; }
        public float Mark{ get; set; }
        public int GameId{ get; set; }
        public Game Game{ get; set; }


        
    }
}
