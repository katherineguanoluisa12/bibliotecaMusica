using BibliotecaMusical.DataLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class AgregarMaterial : System.Web.UI.Page
    {

        MaterialDL materialDL = new MaterialDL();

        

        protected void Guardar(object sender, EventArgs e)
        {
            // Crear un nuevo objeto Material
            Material nuevoMaterial = new Material
            {
                Titulo = txtTitulo.Value,
                Tipo = ddlTipo.SelectedValue,
                Ubicacion = ddlUbicacion.SelectedValue,
                Autor = txtAutor.Value,
                FechaPublicacion = DateTime.Parse(txtFechaPublicacion.Value),
                Descripcion = txtDescripcion.Value,
                FechaAgregado = DateTime.Parse(txtFechaAgregado.Value),
                AgregadoPor = int.Parse(ddlAgregadoPor.SelectedValue) // Se obtiene el ID del usuario seleccionado
            };

            // Guardar el material
            if (materialDL.Crear(nuevoMaterial))
            {
                // Redirigir a la página de éxito
                Response.Redirect("Materiales.aspx");
            }
            else
            {
                // Mostrar un mensaje de error
                // Por ejemplo, usar un Label o un mensaje emergente (alerta).
            }
        }
    }
}
