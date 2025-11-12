<%@ Page Title="" Language="C#" MasterPageFile="~/MPSitio.master" AutoEventWireup="true" CodeBehind="ActualizarTicket.aspx.cs" Inherits="PeCes.Web.ActualizarTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-table { width: 600px; border-collapse: collapse; }
        .form-table td { padding: 8px; }
        .form-table .label-cell { width: 150px; text-align: right; font-weight: bold; }
        .form-table .input-cell { width: 450px; }
        .form-table input[type="text"], .form-table select { width: 95%; padding: 5px; }
        .form-table input[readonly] { background-color: #eee; }
        .form-table h3 { border-bottom: 2px solid #004a99; padding-bottom: 5px; }
        .button-bar { text-align: right; margin-top: 15px; }
        .btn-guardar { padding: 8px 15px; background-color: #28a745; color: white; border: none; border-radius: 4px; cursor: pointer; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Actualizar Ticket de Soporte</h1>
    
    <asp:Label ID="lblErrorActualizar" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
    
    <asp:Panel ID="pnlActualizar" runat="server">
        <table class="form-table">
            <tr>
                <td colspan="2"><h3>Datos del Cliente</h3></td>
            </tr>
            <tr>
                <td class="label-cell">Nombre:</td>
                <td class="input-cell"><asp:TextBox ID="txtNombre" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-cell">RUT:</td>
                <td class="input-cell"><asp:TextBox ID="txtRut" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-cell">Teléfono: (Editable)</td>
                <td class="input-cell"><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-cell">Email: (Editable)</td>
                <td class="input-cell"><asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
            
            <asp:PlaceHolder ID="phRazonSocial" runat="server" Visible="false">
                <tr>
                    <td class="label-cell">Razón Social:</td>
                    <td class="input-cell"><asp:TextBox ID="txtRazonSocial" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
            </asp:PlaceHolder>

            <tr>
                <td colspan="2"><h3>Datos del Ticket</h3></td>
            </tr>
            <tr>
                <td class="label-cell">ID Ticket:</td>
                <td class="input-cell"><asp:TextBox ID="txtTicketId" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="label-cell">Producto: (Editable)</td>
                <td class="input-cell"><asp:TextBox ID="txtProducto" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-cell">Descripción: (Editable)</td>
                <td class="input-cell"><asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="label-cell">Estado: (Editable)</td>
                <td class="input-cell"><asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList></td>
            </tr>
             <tr>
                <td class="label-cell">Fecha Creación:</td>
                <td class="input-cell"><asp:TextBox ID="txtFechaCreacion" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" class="button-bar">
                    <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" CssClass="btn-guardar" OnClick="btnGuardarCambios_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>