<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="bibliotecaMusica.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Contraseña</label>
        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Estado</label>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha de Registro</label>
        <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Rol</label>
        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning">Volver</asp:LinkButton>

</asp:Content>
