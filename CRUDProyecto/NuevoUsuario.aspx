<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="CRUDProyecto.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nuevo Usuario</title>

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
                    <h2 class="text-center mb-4" style="font-family: 'Georgia', serif; color: #5D5B8D;">Agregar Nuevo Usuario</h2>

                    <!-- Nombre -->
                    <div class="form-group mb-3">
                        <label for="txtNombre" class="form-label">Nombre:</label>
                        <input type="text" id="txtNombre" runat="server" class="form-control" placeholder="Ingrese el nombre" />
                    </div>

                    <!-- Apellido -->
                    <div class="form-group mb-3">
                        <label for="txtApellido" class="form-label">Apellido:</label>
                        <input type="text" id="txtApellido" runat="server" class="form-control" placeholder="Ingrese el apellido" />
                    </div>

                    <!-- Email -->
                    <div class="form-group mb-3">
                        <label for="txtEmail" class="form-label">Email:</label>
                        <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="Ingrese el correo electrónico" />
                    </div>

                    <!-- Contraseña -->
                    <div class="form-group mb-3">
                        <label for="txtContraseña" class="form-label">Contraseña:</label>
                        <input type="password" id="txtContraseña" runat="server" class="form-control" placeholder="Ingrese la contraseña" />
                    </div>

                    <!-- Rol -->
                    <div class="form-group mb-3">
                        <label for="ddlRol" class="form-label">Rol:</label>
                        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Seleccionar Rol" Value="" />
                            <asp:ListItem Text="Usuario" Value="Usuario" />
                            <asp:ListItem Text="Administrador" Value="Administrador" />
                        </asp:DropDownList>
                    </div>

                    <!-- Fecha de Registro -->
                    <div class="form-group mb-3">
                        <label for="txtFechaRegistro" class="form-label">Fecha de Registro:</label>
                        <input type="date" id="txtFechaRegistro" runat="server" class="form-control" />
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