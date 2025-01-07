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
            gvUsuarios.DataSource = usuarioDL.Lista(); // Asegúrate de que este método devuelva una lista válida.
            gvUsuarios.DataBind();
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
                if (usuarioDL.Eliminar(idUsuario))
                {
                    CargarUsuarios();
                }
                else
                {
                    // Aquí podrías agregar un mensaje de error, si lo necesitas.
                }
            }
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento puede dejarse vacío si no necesitas implementar lógica aquí.
        }
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Verificar que el usuario tiene rol de Administrador
                if (Session["Rol"] == null || Session["Rol"].ToString() != "Administrador")
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
        }
    }
}
