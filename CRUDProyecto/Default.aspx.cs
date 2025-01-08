using BibliotecaMusical.BusinessLayer;
using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class _Default : Page
    {
        UsuarioDL usuarioDL = new UsuarioDL();
        UsuarioBL usuarioBL = new UsuarioBL(); // Añadimos una instancia de UsuarioBL

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoUsuario.aspx");
        }

        private void CargarUsuarios()
        {
            try
            {
                gvUsuarios.DataSource = usuarioDL.Lista(); // Asegúrate de que este método devuelva una lista válida.
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar los usuarios: {ex.Message}");
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUsuario = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Response.Redirect($"NuevoUsuario.aspx?idUsuario={idUsuario}");
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    if (usuarioDL.Eliminar(idUsuario))
                    {
                        CargarUsuarios();
                    }
                    else
                    {
                        MostrarError("Error al eliminar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al eliminar el usuario: {ex.Message}");
                }
            }
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento puede dejarse vacío si no necesitas implementar lógica aquí.
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBuscado = txtBuscar.Text.Trim();
                var usuariosFiltrados = usuarioBL.Buscar(textoBuscado); // Ahora usamos la instancia usuarioBL
                gvUsuarios.DataSource = usuariosFiltrados;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al buscar usuarios: {ex.Message}");
            }
        }

        // Método para mostrar errores
        private void MostrarError(string mensaje)
        {
            // Asegúrate de que lblErrorMessage esté definido en tu página ASPX
            lblErrorMessage.Text = mensaje;
            lblErrorMessage.Visible = true;
        }
    }
}
