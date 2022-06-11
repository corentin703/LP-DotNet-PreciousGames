using System;

namespace VerotMorin.PreciousGames.BusinessLayer.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity not found with id '{id}'")
        {
            //
        }
    }
}