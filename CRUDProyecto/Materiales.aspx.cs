using BibliotecaMusical.BusinessLayer;
using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDProyecto
{
    public partial class Materiales : System.Web.UI.Page
    {
        private readonly MaterialesBL _materialBL = new MaterialesBL();

        // Llamar al método que obtiene los materiales y mostrarlos en la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var materiales = _materialBL.Lista();
                MostrarMateriales(materiales);
            }
        }

        // Mostrar los materiales en la tabla
        private void MostrarMateriales(List<Material> materiales)
        {
            string materialesHtml = string.Empty;

            foreach (var material in materiales)
            {
                materialesHtml += $@"
                    <tr>
                        <td>{material.MaterialID}</td>
                        <td>{material.Titulo}</td>
                        <td>{material.Tipo}</td>
                        <td>{material.Autor}</td>
                        <td>{material.FechaPublicacion.ToString("yyyy-MM-dd")}</td>
                        <td>{material.Descripcion}</td>
                        <td>{material.FechaAgregado.ToString("yyyy-MM-dd")}</td>
                        <td>{material.AgregadoPor}</td>
                        <td>
                            <button class='btn btn-warning' onclick='editarMaterial({material.MaterialID})'>Editar</button>
                            <button class='btn btn-danger' onclick='eliminarMaterial({material.MaterialID})'>Eliminar</button>
                        </td>
                    </tr>";
            }


        }
    }
}