using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class VistaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar que el usuario tiene rol de Usuario
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Usuario")
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}
