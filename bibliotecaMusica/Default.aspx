<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bibliotecaMusica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVUsuarios" CssClass="table table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton 
                                ID="btnEditar" 
                                runat="server" 
                                CommandName="Editar" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-primary btn-sm">
                                Editar
                            </asp:LinkButton>
                            <asp:LinkButton 
                                ID="btnEliminar" 
                                runat="server" 
                                CommandName="Eliminar" 
                                CommandArgument='<%# Eval("ID") %>' 
                                CssClass="btn btn-danger btn-sm"
                                OnClientClick="return confirm('¿Está seguro que desea eliminar este registro?');">
                                Eliminar
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
