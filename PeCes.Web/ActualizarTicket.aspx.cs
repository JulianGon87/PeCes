using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeCes.Negocio;

namespace PeCes.Web
{
    public partial class ActualizarTicket : System.Web.UI.Page
    {
        private string ticketId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                MostrarError("Error: No se ha proporcionado un ID de ticket.");
                return;
            }

            ticketId = Request.QueryString["id"];

            if (!IsPostBack)
            {
                CargarEstados();
                CargarDatosTicket();
            }
        }

        private void CargarEstados()
        {
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("Ingresado", "Ingresado"));
            ddlEstado.Items.Add(new ListItem("En Revisión", "En Revisión"));
            ddlEstado.Items.Add(new ListItem("Terminado", "Terminado"));
        }

        private void CargarDatosTicket()
        {
            Ticket ticket = TicketController.Read(ticketId);

            if (ticket == null)
            {
                MostrarError("Error: El ticket solicitado no existe.");
                return;
            }

            txtNombre.Text = ticket.Cliente.Nombre;
            txtRut.Text = ticket.Cliente.Rut;
            txtTelefono.Text = ticket.Cliente.Telefono;
            txtEmail.Text = ticket.Cliente.Email;

            if (ticket.Cliente is Empresa)
            {
                phRazonSocial.Visible = true;
                txtRazonSocial.Text = ((Empresa)ticket.Cliente).RazonSocial;
            }

            txtTicketId.Text = ticket.Id;
            txtProducto.Text = ticket.Producto;
            txtDescripcion.Text = ticket.Descripción;
            txtFechaCreacion.Text = ticket.GetCreatedAt().ToString("g");

            ListItem itemEstado = ddlEstado.Items.FindByValue(ticket.Estado);
            if (itemEstado != null)
            {
                itemEstado.Selected = true;
            }
        }

        private void MostrarError(string mensaje)
        {
            pnlActualizar.Visible = false;
            lblErrorActualizar.Text = mensaje;
            lblErrorActualizar.Visible = true;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = TicketController.Update(
                    ticketId,
                    txtProducto.Text,
                    txtDescripcion.Text,
                    ddlEstado.SelectedValue,
                    txtEmail.Text,
                    txtTelefono.Text
                );

                Response.Redirect("~/ListadoTickets.aspx?mensaje=" + Server.UrlEncode(mensaje), false);
            }
            catch (Exception ex)
            {
                string mensajeError = "Error al actualizar: " + ex.Message;
                Response.Redirect("~/ListadoTickets.aspx?mensaje=" + Server.UrlEncode(mensajeError));
            }
        }
    }
}