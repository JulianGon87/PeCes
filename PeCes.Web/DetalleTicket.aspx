<%@ Page Title="" Language="C#" MasterPageFile="~/MPSitio.master" AutoEventWireup="true" CodeBehind="DetalleTicket.aspx.cs" Inherits="PeCes.Web.DetalleTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-table { width: 600px; border-collapse: collapse; }
        .form-table td { padding: 8px; }
        .form-table .label-cell { width: 150px; text-align: right; font-weight: bold; }
        .form-table .input-cell { width: 450px; }
        .form-table h3 { border-bottom: 2px solid #004a99; padding-bottom: 5px; }
        .button-bar { text-align: right; margin-top: 15px; }
        .button-bar .btn { padding: 8px 15px; margin-left: 10px; text-decoration: none; border-radius: 4px; font-weight: bold; cursor: pointer; border: none; }
        .btn-volver { background-color: #6c757d; color: white; }
        .btn-actualizar { background-color: #007bff; color: white; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Detalle del Ticket</h1>

    <asp:Label ID="lblErrorDetalle" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>

    <asp:Panel ID="pnlDetalle" runat="server">
        <table class="form-table">
            <tr>
                <td colspan="2"><h3>Datos del Cliente</h3></td>
            </tr>
            <tr>
                <td class="label-cell">Nombre:</td>
                <td class="input-cell"><asp:Literal ID="litNombre" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td class="label-cell">RUT:</td>
                <td class="input-cell"><asp:Literal ID="litRut" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td class="label-cell">Teléfono:</td>
                <td class="input-cell"><asp:Literal ID="litTelefono" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td class="label-cell">Email:</td>
                <td class="input-cell"><asp:Literal ID="litEmail" runat="server"></asp:Literal></td>
            </tr>
            
            <asp:PlaceHolder ID="phRazonSocial" runat="server" Visible="false">
                <tr>
                    <td class="label-cell">Razón Social:</td>
                    <td class="input-cell"><asp:Literal ID="litRazonSocial" runat="server"></asp:Literal></td>
                </tr>
            </asp:PlaceHolder>

            <tr>
                <td colspan="2"><h3>Datos del Ticket</h3></td>
            </tr>
            <tr>
                <td class="label-cell">ID Ticket:</td>
                <td class="input-cell"><asp:Literal ID="litTicketId" runat="server"></asp:Literal></td>
            </tr>
             <tr>
                <td class="label-cell">Producto:</td>
                <td class="input-cell"><asp:Literal ID="litProducto" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td class="label-cell">Descripción:</td>
                <td class="input-cell"><asp:Literal ID="litDescripcion" runat="server"></asp:Literal></td>
            </tr>
             <tr>
                <td class="label-cell">Estado:</td>
                <td class="input-cell"><asp:Literal ID="litEstado" runat="server"></asp:Literal></td>
            </tr>
             <tr>
                <td class="label-cell">Fecha Creación:</td>
                <td class="input-cell"><asp:Literal ID="litFechaCreacion" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="2" class="button-bar">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-volver" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-actualizar" OnClick="btnActualizar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>