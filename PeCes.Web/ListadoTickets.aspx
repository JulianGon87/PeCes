<%@ Page Title="" Language="C#" MasterPageFile="~/MPSitio.master" AutoEventWireup="true" CodeBehind="ListadoTickets.aspx.cs" Inherits="PeCes.Web.ListadoTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gv-tickets { width: 100%; border-collapse: collapse; }
        .gv-tickets th { background-color: #004a99; color: white; padding: 10px; text-align: left; }
        .gv-tickets td { padding: 10px; border-bottom: 1px solid #ddd; }
        .gv-tickets tr:nth-child(even) { background-color: #f2f2f2; }
        .btn-detalle { padding: 5px 10px; background-color: #007bff; color: white; text-decoration: none; border-radius: 4px; }
        .btn-detalle:hover { background-color: #0056b3; }
        .mensaje { font-size: 1.1em; padding: 10px; border-radius: 5px; margin-bottom: 15px; }
        .mensaje-exito { background-color: #d4edda; color: #155724; border: 1px solid #c3e6cb; }
        .mensaje-error { background-color: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; }
        .mensaje-info { background-color: #d1ecf1; color: #0c5460; border: 1px solid #bee5eb; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Listado de Tickets de Soporte</h1>

    <asp:Label ID="lblMensaje" runat="server" Visible="false" CssClass="mensaje"></asp:Label>

    <asp:GridView ID="gvTickets" runat="server" 
        AutoGenerateColumns="False" 
        CssClass="gv-tickets"
        OnRowCommand="gvTickets_RowCommand"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre Cliente" />
            <asp:BoundField DataField="Cliente.Rut" HeaderText="RUT" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnVerDetalle" runat="server" 
                        Text="Ver detalle" 
                        CssClass="btn-detalle"
                        CommandName="VerDetalle" 
                        CommandArgument='<%# Eval("Id") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>