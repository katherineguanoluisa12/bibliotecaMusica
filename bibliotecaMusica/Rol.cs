using System;

namespace CRUD.WebForm
{
    internal class Rol
    {
        public int IdRol { get; internal set; }

        public static implicit operator string(Rol v)
        {
            throw new NotImplementedException();
        }
    }
}