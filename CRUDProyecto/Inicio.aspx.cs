using System;
using BibliotecaMusical.BusinessLayer;
using BibliotecaMusical.EntityLayer;

namespace CRUDProyecto
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty; // Limpiar mensajes al cargar la página
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text.Trim();
            string contraseña = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                lblMensaje.Text = "Por favor, complete ambos campos.";
                lblMensaje.Visible = true;
                return;
            }

            try
            {
                UsuarioBL usuarioBL = new UsuarioBL();
                Usuario usuario = usuarioBL.ClasificarUsuario(email, contraseña);

                if (usuario != null)
                {
                    // Guardar información en la sesión
                    Session["UsuarioID"] = usuario.ID;
                    Session["Nombre"] = usuario.Nombre;
                    Session["Rol"] = usuario.Rol;

                    // Redirección basada en el rol
                    if (usuario.Rol == "Administrador")
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else if (usuario.Rol == "Usuario")
                    {
                        Response.Redirect("VistaUsuarios.aspx");
                    }
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
                lblMensaje.Visible = true;
            }
        }
    }
}
