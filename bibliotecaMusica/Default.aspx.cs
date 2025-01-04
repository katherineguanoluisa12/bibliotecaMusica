using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.EnntyLayer;  // Asegúrate de que el namespace sea el correcto para tu clase de entidad
using CRUD.BusinessLayer; // Asegúrate de que el namespace sea el correcto para la clase de negocio

namespace bibliotecaMusica
{
    public partial class _Default : Page
    {
        // Esta propiedad de clase se usa para interactuar con la capa de negocio
        private UsuariosBL usuariosBL = new UsuariosBL();

        // El evento Page_Load se ejecuta cuando la página se carga
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarUsuarios(); // Llamamos al método que llena el GridView con los usuarios
            }
        }

        // Método para obtener la lista de usuarios y asignarla al GridView
        private void MostrarUsuarios()
        {
            try
            {
                // Obtenemos la lista de usuarios desde la capa de negocio
                List<Usuarios> lista = usuariosBL.ObtenerUsuarios(); // Usamos el método ObtenerUsuarios() de la capa BL

                // Asignamos la lista al GridView
                GVUsuarios.DataSource = lista;
                GVUsuarios.DataBind(); // Realizamos el enlace de datos al GridView
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, podrías mostrar un mensaje de error si fuera necesario
                // Aquí puedes manejar la excepción como desees, por ejemplo, mostrar un mensaje
                Response.Write("<script>alert('Error al cargar los usuarios: " + ex.Message + "');</script>");
            }
        }
    }
}
