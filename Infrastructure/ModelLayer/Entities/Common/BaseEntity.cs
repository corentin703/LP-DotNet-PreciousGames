using System;

namespace VerotMorin.PreciousGames.ModelLayer.Entities.Common
{
    public abstract class BaseEntity : ICloneable
    {
        public int Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}