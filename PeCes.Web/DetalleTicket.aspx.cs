using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeCes.Negocio;

namespace PeCes.Web
{
    public partial class DetalleTicket : System.Web.UI.Page
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
                CargarDatosTicket();
            }
        }

        private void CargarDatosTicket()
        {
            Ticket ticket = TicketController.Read(ticketId);

            if (ticket == null)
            {
                MostrarError("Error: El ticket solicitado no existe.");
                return;
            }

            litNombre.Text = ticket.Cliente.Nombre;
            litRut.Text = ticket.Cliente.Rut;
            litTelefono.Text = ticket.Cliente.Telefono;
            litEmail.Text = ticket.Cliente.Email;

             if (ticket.Cliente is Empresa)
            {
                phRazonSocial.Visible = true;
                litRazonSocial.Text = ((Empresa)ticket.Cliente).RazonSocial;
            }

            litTicketId.Text = ticket.Id;
            litProducto.Text = ticket.Producto;
            litDescripcion.Text = ticket.Descripción;
            litEstado.Text = ticket.Estado;
            litFechaCreacion.Text = ticket.GetCreatedAt().ToString("g");
        }

        private void MostrarError(string mensaje)
        {
            pnlDetalle.Visible = false;
            lblErrorDetalle.Text = mensaje;
            lblErrorDetalle.Visible = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListadoTickets.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActualizarTicket.aspx?id=" + ticketId);
        }
    }
}