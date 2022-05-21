using System;

namespace PreciousGames.Verot.Morin.BusinessLayer.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity not found with id '{id}'")
        {
            //
        }
    }
}