using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{

            public partial class NuevoUsuario : Page
        {
            UsuarioDL usuarioDL = new UsuarioDL();

            protected void btnGuardar_Click(object sender, EventArgs e)
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtNombre.Value,
                    Apellido = txtApellido.Value,
                    Email = txtEmail.Value,
                    Contraseña = txtContraseña.Value,
                    Rol = txtRol.Value,
                    FechaRegistro = DateTime.Parse(txtFechaRegistro.Value)
                };

                if (usuarioDL.Crear(nuevoUsuario))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    // Maneja el error, por ejemplo, mostrando un mensaje al usuario.
                }
            }
        }
    
}