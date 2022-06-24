using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.EvaluationModels
{
    public class EvaluationViewModel
    {
        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "EvaluatorName")]
        [Required]
        public string EvaluatorName { get; set; }

        [Display(Name = "Game")]
        [Required]
        public Game Game { get; set; }

        [Display(Name = "Mark")]
        public float Mark { get; set; }

        public EvaluationViewModel()
        {

        }

        public EvaluationViewModel(Evaluation evaluation)
        {
            Date = evaluation.Date;
            EvaluatorName = evaluation.EvaluatorName;
            Game = evaluation.Game;
            Mark = evaluation.Mark;
        }
    }
}