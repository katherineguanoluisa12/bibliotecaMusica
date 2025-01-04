using System;
using System.Web.UI;
using CRUD.BusinessLayer;  // Asegúrate de que la capa de negocio esté referenciada
using CRUD.EnntyLayer;    // Asegúrate de que las entidades están correctamente importadas

namespace bibliotecaMusica
{
    public partial class Contact : Page
    {
        // Variable para almacenar el ID del usuario
        private static int ID = 0;

        // Instancias de las capas de negocio
        RolBL rolBL = new RolBL();
        UsuariosBL usuarioBL = new UsuariosBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idUsuario"] != null)
                {
                    ID = Convert.ToInt32(Request.QueryString["idUsuario"].ToString());

                    if (ID != 0)
                    {
                        lblTitulo.Text = "Editar Usuario";
                        btnSubmit.Text = "Actualizar";

                        // Aquí deberías cargar los datos del usuario para editar
                        Usuarios usuario = usuarioBL.Obtener(ID);
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        txtEmail.Text = usuario.Email;
                        CargarRoles(usuario.Rol.IdRol.ToString());
                        txtContraseña.Text = usuario.Contraseña;
                        txtFechaRegistro.Text = usuario.FechaRegistro.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Usuario";
                        btnSubmit.Text = "Guardar";
                        CargarRoles();  // Cargar roles para un nuevo usuario
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");  // Redirigir si no hay un ID en la URL
                }
            }
        }

        private void CargarRoles(string idRol = "")
        {
            var lista = rolBL.Lista();  // Obtener la lista de roles desde la capa de negocio

            ddlRol.DataTextField = "Nombre";
            ddlRol.DataValueField = "IdRol";
            ddlRol.DataSource = lista;
            ddlRol.DataBind();

            if (!string.IsNullOrEmpty(idRol))
            {
                ddlRol.SelectedValue = idRol;  // Seleccionar el rol si se está editando un usuario
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Crear el objeto Usuario
            Usuarios entidad = new Usuarios()
            {
                ID = ID,  // Si es un usuario nuevo, el ID será 0
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Contraseña = txtContraseña.Text,
                Rol = new Rol() { IdRol = Convert.ToInt32(ddlRol.SelectedValue) },
                FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text)  // Conversión de la fecha de registro
            };

            bool respuesta;

            if (ID != 0)
                respuesta = UsuariosBL.Editar(entidad);  // Llamar al método de edición
            else
                respuesta = UsuariosBL.Crear(entidad);  // Llamar al método de creación

            if (respuesta)
            {
                Response.Redirect("~/Default.aspx");  // Redirigir al listado de usuarios
            }
            else
            {
                // Mostrar un mensaje de error si no se pudo guardar
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operación')", true);
            }
        }
    }
}
