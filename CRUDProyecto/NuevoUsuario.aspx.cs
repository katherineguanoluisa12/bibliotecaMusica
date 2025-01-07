using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UsuarioDL usuarioDL = new UsuarioDL();

        protected void Guardar(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Value,
                Apellido = txtApellido.Value,
                Email = txtEmail.Value,
                Contraseña = txtContraseña.Value,
                Rol = ddlRol.SelectedValue,
                FechaRegistro = DateTime.Parse(txtFechaRegistro.Value)
            };

            if (usuarioDL.Crear(nuevoUsuario))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                // Maneja el error, por ejemplo, mostrando un mensaje al usuario.
            }
        }
    }
    
}
