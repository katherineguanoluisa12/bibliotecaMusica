using BibliotecaMusical.BusinessLayer;
using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Web;

namespace CRUDProyecto
{
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
        UsuarioDL usuarioDL = new UsuarioDL();

        protected void Page_Load(object sender, EventArgs e)

        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            if (!IsPostBack)
            {
                int idUsuario;
                // Verificamos si existe el parámetro idUsuario en la URL
                if (int.TryParse(Request.QueryString["idUsuario"], out idUsuario))
                {
                    // Si el idUsuario existe, cargamos los datos del usuario
                    Usuario usuario = usuarioDL.Obtener(idUsuario);
                    if (usuario != null)
                    {
                        // Rellenamos los campos del formulario con los datos del usuario
                        txtNombre.Text = usuario.Nombre ?? string.Empty;
                        txtApellido.Text = usuario.Apellido ?? string.Empty;
                        txtEmail.Text = usuario.Email ?? string.Empty;
                        txtContraseña.Text = usuario.Contraseña ?? string.Empty;
                        ddlRol.SelectedValue = usuario.Rol ?? string.Empty;
                        txtFechaRegistro.Text = usuario.FechaRegistro.ToString("yyyy-MM-dd") ?? string.Empty;
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario no encontrado.";
                        lblMensaje.CssClass = "text-danger";
                    }
                }
                else
                {
                    lblMensaje.Text = "ID de usuario no válido.";
                    lblMensaje.CssClass = "text-danger";
                }
            }
        }

        protected void Guardar(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo objeto Usuario con los datos del formulario
                Usuario usuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Contraseña = txtContraseña.Text,
                    Rol = ddlRol.SelectedValue
                };

                DateTime fechaRegistro;
                // Verificar si la fecha es válida antes de asignarla
                if (DateTime.TryParse(txtFechaRegistro.Text, out fechaRegistro))
                {
                    usuario.FechaRegistro = fechaRegistro;
                }
                else
                {
                    lblMensaje.Text = "Fecha de registro inválida.";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

                int idUsuario;
                if (int.TryParse(Request.QueryString["idUsuario"], out idUsuario))
                {
                    // Si estamos editando un usuario existente
                    usuario.ID = idUsuario;

                    if (usuarioDL.Editar(usuario))
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Error al actualizar el usuario.";
                        lblMensaje.CssClass = "text-danger";
                    }
                }
                else
                {
                    lblMensaje.Text = "Operación inválida.";
                    lblMensaje.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}
