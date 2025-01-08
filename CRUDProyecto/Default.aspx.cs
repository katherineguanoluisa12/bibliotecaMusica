using BibliotecaMusical.BusinessLayer;
using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class _Default : Page
    {
        UsuarioDL usuarioDL = new UsuarioDL();
        UsuarioBL usuarioBL = new UsuarioBL();

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
                var usuarios = usuarioDL.Lista(); // Obtener todos los usuarios.

                // Filtrar por rol si se ha seleccionado un rol específico
                string rolSeleccionado = ddlFiltroRol.SelectedValue;
                if (!string.IsNullOrEmpty(rolSeleccionado))
                {
                    usuarios = usuarios.Where(u => u.Rol == rolSeleccionado).ToList(); // Filtrar según el rol seleccionado.
                }

                gvUsuarios.DataSource = usuarios;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar los usuarios: {ex.Message}");
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBuscado = txtBuscar.Text.Trim();
                var usuariosFiltrados = usuarioBL.Buscar(textoBuscado); // Método para filtrar usuarios
                gvUsuarios.DataSource = usuariosFiltrados;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al buscar usuarios: {ex.Message}");
            }
        }

        protected void ddlFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cada vez que el usuario cambie el rol, recargamos los usuarios filtrados
            CargarUsuarios();
        }

        // Método para mostrar errores
        private void MostrarError(string mensaje)
        {
            lblErrorMessage.Text = mensaje;
            lblErrorMessage.Visible = true;
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

        // Evento para manejar la visibilidad de los botones Editar, Eliminar y Crear Material
        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Evitar que el código se ejecute para las filas de encabezado o pie de página
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el rol de la sesión
                string rolSesion = Session["Rol"]?.ToString();

                // Obtener los controles de los botones en cada fila
                LinkButton lnkAgregarMaterial = (LinkButton)e.Row.FindControl("lnkAgregarMaterial");
                LinkButton lnkEditar = (LinkButton)e.Row.FindControl("lnkEditar");
                LinkButton lnkEliminar = (LinkButton)e.Row.FindControl("lnkEliminar");

                // Verificar si los controles existen antes de asignar la visibilidad
                if (lnkAgregarMaterial != null && lnkEditar != null && lnkEliminar != null)
                {
                    if (rolSesion == "Administrador")
                    {
                        // Administrador puede ver todos los botones
                        lnkEditar.Visible = true;
                        lnkEliminar.Visible = true;
                        lnkAgregarMaterial.Visible = true;
                    }
                    else if (rolSesion == "Usuario")
                    {
                        // Usuario solo puede ver Crear y Eliminar
                        lnkEditar.Visible = false; // Ocultar Editar para usuarios
                        lnkEliminar.Visible = true; // Mostrar Eliminar
                        lnkAgregarMaterial.Visible = true; // Mostrar Crear Material
                    }
                    else
                    {
                        // Si no hay rol definido, ocultar todos los botones por seguridad
                        lnkEditar.Visible = false;
                        lnkEliminar.Visible = false;
                        lnkAgregarMaterial.Visible = false;
                    }
                }
            }
        }
    }
}
