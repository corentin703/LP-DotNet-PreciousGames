using System;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.EvaluationModels
{
    public class EvaluationViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Nom de l'évaluateur")]
        [Required]
        public string EvaluatorName { get; set; }

        [Display(Name = "Jeu")]
        [Required]
        public int GameId { get; set; }
        public GameViewModel Game { get; set; }

        [Display(Name = "Note")]
        public float Mark { get; set; }

        public EvaluationViewModel()
        {
                //
        }

        public EvaluationViewModel(Evaluation evaluation)
        {
            Id = evaluation.Id;
            EvaluatorName = evaluation.EvaluatorName;
            Date = evaluation.Date;
            Mark = evaluation.Mark;
            GameId = evaluation.GameId;

            if (evaluation.Game != null) 
                Game = new GameViewModel(evaluation.Game);
        }
    }
}