<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMaterial.aspx.cs" Inherits="CRUDProyecto.AgregarMaterial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nuevo Material</title>

    <!-- Incluir Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor para centrar el formulario -->
        <div class="container d-flex justify-content-center align-items-center min-vh-100">
            <!-- Card para el formulario -->
            <div class="card shadow-lg" style="width: 100%; max-width: 500px; border-radius: 15px;">
                <div class="card-body">
                    <!-- Título del formulario -->
                    <h2 class="text-center mb-4" style="font-family: 'Georgia', serif; color: #5D5B8D;">Agregar Nuevo Material</h2>

                    <!-- Titulo -->
                    <div class="form-group mb-3">
                        <label for="txtTitulo" class="form-label">Título:</label>
                        <input type="text" id="txtTitulo" runat="server" class="form-control" placeholder="Ingrese el Título" />
                    </div>

                    <!-- Tipo -->
                    <div class="form-group mb-3">
                    <label for="ddlTipo" class="form-label">Tipo:</label>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Seleccionar Tipo" Value="" />
                         <asp:ListItem Text="Partitura" Value="Partitura" />
                         <asp:ListItem Text="Grabación" Value="Grabación" />
                        <asp:ListItem Text="Documento" Value="Documento" />
                    </asp:DropDownList>
                  </div>

                   <!-- Ubicacion -->
                    <div class="form-group mb-3">
                    <label for="ddlUbicacion" class="form-label">Ubicación:</label>
                    <asp:DropDownList ID="ddlUbicacion" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Seleccionar Ubicación" Value="" />
                         <asp:ListItem Text="Museos" Value="Museos" />
                         <asp:ListItem Text="Centros Culturales" Value="Centros Culturales" />
                    </asp:DropDownList>
                  </div>

                    <!-- Autor -->
                    <div class="form-group mb-3">
                        <label for="txtAutor" class="form-label">Autor:</label>
                        <input type="text" id="txtAutor" runat="server" class="form-control" placeholder="Ingrese el Autor" />
                    </div>

                     <!-- Fecha Publicacion -->
                    <div class="form-group mb-3">
                        <label for="txtFechaPublicacion" class="form-label">Fecha de Publicación:</label>
                        <input type="date" id="txtFechaPublicacion" runat="server" class="form-control" />
                    </div>

                      <!-- Descripcion -->
                    <div class="form-group mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción:</label>
                        <input type="text" id="txtDescripcion" runat="server" class="form-control" placeholder="Ingrese la descripción" />
                    </div>

                     <!-- Fecha Agregado -->
                       <div class="form-group mb-3">
                        <label for="txtFechaAgregado" class="form-label">Fecha Agregado:</label>
                         <input type="date" id="txtFechaAgregado" runat="server" class="form-control" />
                        </div>

                    <!--  Agregado por -->
<div class="form-group mb-3">
    <label for="ddlAgregadoPor" class="form-label">Agregado Por (Usuario):</label>
    <asp:DropDownList ID="ddlAgregadoPor" runat="server" CssClass="form-control">
        <asp:ListItem Text="Seleccionar Usuario" Value="" />
    </asp:DropDownList>
</div>

                    <!-- Botón Guardar -->
                    <div class="form-group">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="Guardar" CssClass="btn btn-primary w-100" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Incluir Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
