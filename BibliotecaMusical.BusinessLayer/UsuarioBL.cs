using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;


namespace BibliotecaMusical.BusinessLayer
{
    public class UsuarioBL
    {
        private readonly UsuarioDL _usuarioDL = new UsuarioDL();

        public List<Usuario> Lista()
        {
            return _usuarioDL.Lista();
        }

        public Usuario Obtener(int id)
        {
            return _usuarioDL.Obtener(id);
        }

        public bool Crear(Usuario usuario)
        {
            return _usuarioDL.Crear(usuario);
        }

        public bool Editar(Usuario usuario)
        {
            return _usuarioDL.Editar(usuario);
        }

        public bool Eliminar(int id)
        {
            return _usuarioDL.Eliminar(id);
        }
        public bool Guardar(int id)
        {
            return _usuarioDL.Guardar(id);
        }
        public Usuario ClasificarUsuario(string email, string contraseña)
        {
            return _usuarioDL.ClasificarUsuario(email, contraseña);
        }
        public List<Usuario> Buscar(string textoBuscado)
        {
            return _usuarioDL.Buscar(textoBuscado);
        }
    }
}
