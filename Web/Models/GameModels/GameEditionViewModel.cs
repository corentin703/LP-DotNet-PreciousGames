using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    public class GameEditionViewModel
    {
        public GameViewModel GameViewModel { get; set; }
        public List<Kind> Kinds { get; set; }
    }
}