<%@ Page Title="Actualizar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="CRUDProyecto.ActualizarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-form">
        <h2 class="form-title">Actualizar Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese el apellido"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese el correo electrónico"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtContraseña">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese la contraseña"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlRol">Rol:</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccionar Rol" Value="" />
                <asp:ListItem Text="Usuario" Value="Usuario" />
                <asp:ListItem Text="Administrador" Value="Administrador" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtFechaRegistro">Fecha de Registro:</label>
            <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="Guardar" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
