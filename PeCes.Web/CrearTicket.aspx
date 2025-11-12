<%@ Page Title="" Language="C#" MasterPageFile="~/MPSitio.master" AutoEventWireup="true" CodeBehind="CrearTicket.aspx.cs" Inherits="PeCes.Web.CrearTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-table { width: 600px; border-collapse: collapse; }
        .form-table td { padding: 8px; }
        .form-table .label-cell { width: 150px; text-align: right; font-weight: bold; }
        .form-table .input-cell { width: 450px; }
        .form-table input[type="text"], .form-table select { width: 95%; padding: 5px; }
        .form-table h3 { border-bottom: 2px solid #004a99; padding-bottom: 5px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Formulario de Ingreso de Ticket</h1>
    
    <table class="form-table">
        <tr>
            <td colspan="2"><h3>Datos del Cliente</h3></td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblRut" runat="server" Text="RUT:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblTipoCliente" runat="server" Text="Tipo Cliente:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:DropDownList ID="ddlTipoCliente" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCliente_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>

        <asp:Panel ID="pnlRazonSocial" runat="server" Visible="false">
             <tr>
                <td class="label-cell">
                    <asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social:"></asp:Label>
                </td>
                <td class="input-cell">
                    <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
       
        <tr>
            <td colspan="2"><h3>Datos del Ticket</h3></td>
        </tr>
         <tr>
            <td class="label-cell">
                <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label-cell">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="label-cell">
                <asp:Label ID="lblEstado" runat="server" Text="Estado Inicial:"></asp:Label>
            </td>
            <td class="input-cell">
                <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label-cell"></td>
            <td class="input-cell" style="text-align: right;">
                <asp:Button ID="btnCrearTicket" runat="server" Text="Crear Ticket" OnClick="btnCrearTicket_Click" />
            </td>
        </tr>

    </table>

</asp:Content>