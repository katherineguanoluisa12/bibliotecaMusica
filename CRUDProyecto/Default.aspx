<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDProyecto._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Gestión de Usuarios</h2>
        <asp:Button ID="btnNuevoUsuario" runat="server" Text="Nuevo Usuario" CssClass="btn btn-primary" OnClick="btnNuevoUsuario_Click" />
    </div>

<div class="col-6 d-flex justify-content-start mb-3">
    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" Placeholder="Buscar por nombre o apellido"></asp:TextBox>
    <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnBuscar_Click" />

</div>

    <asp:Label ID="lblErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
            <asp:BoundField DataField="Rol" HeaderText="Rol" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-sm btn-warning me-2">Editar</asp:LinkButton>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('¿Estás seguro de eliminar este usuario?');">Eliminar</asp:LinkButton>
                    <a href="AgregarMaterial.aspx" class="btn btn-primary mb-3">Crear Nuevo Material</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>