using System;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.EvaluationModels
{
    public class EvaluationViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }


        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "EvaluatorName")]
        [Required]
        public string EvaluatorName { get; set; }

        [Display(Name = "Game")]
        [Required]
        public GameViewModel Game { get; set; }

        [Display(Name = "Mark")]
        public float Mark { get; set; }

        public EvaluationViewModel()
        {
                //
        }

        public EvaluationViewModel(Evaluation evaluation)
        {
            EvaluatorName = evaluation.EvaluatorName;
            Date = evaluation.Date;
            Mark = evaluation.Mark;

            if (evaluation.Game != null) 
                Game = new GameViewModel(evaluation.Game);
        }
    }
}