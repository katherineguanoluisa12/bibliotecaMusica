<%@ Page Title="Formulario de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="bibliotecaMusica.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1 class="text-center">Formulario de Usuario</h1>

        <div class="form-container">
            <div class="form-group">
                <asp:Label ID="lbl_nombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-input" Placeholder="Ingrese su nombre" MaxLength="100" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_apellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-input" Placeholder="Ingrese su apellido" MaxLength="100" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_email" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_email" runat="server" CssClass="form-input" Placeholder="Ingrese su email" MaxLength="150" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_contrasena" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_contrasena" runat="server" CssClass="form-input" Placeholder="Ingrese su contraseña" TextMode="Password" MaxLength="255" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_rol" runat="server" Text="Rol" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddl_rol" runat="server" CssClass="form-input">
                    <asp:ListItem Text="Seleccionar Rol" Value=""></asp:ListItem>
                    <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                    <asp:ListItem Text="Usuario" Value="Usuario"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_fecha_registro" runat="server" Text="Fecha de Registro" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_fecha_registro" runat="server" CssClass="form-input" Text='<%# DateTime.Now.ToString("dd/MM/yyyy") %>' Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_guardar_Click" />
            </div>
        </div>
    </div>

</asp:Content>
