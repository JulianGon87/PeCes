using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeCes.Negocio;

namespace PeCes.Web
{
    public partial class ListadoTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManejarMensajesUrl();
                CargarGrilla();
            }
        }

        private void ManejarMensajesUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mensaje"]))
            {
                string mensaje = Request.QueryString["mensaje"];
                lblMensaje.Text = Server.HtmlDecode(mensaje);

                if (mensaje.Contains("éxito"))
                {
                    lblMensaje.CssClass = "mensaje mensaje-exito";
                }
                else
                {
                    lblMensaje.CssClass = "mensaje mensaje-error";
                }
                lblMensaje.Visible = true;
            }
        }

        private void CargarGrilla()
        {
            List<Ticket> listado;
            string filtro = Request.QueryString["filtro"];

            if (!string.IsNullOrEmpty(filtro))
            {
                listado = TicketController.Search(filtro);
                if (listado.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron registros con el filtro: '" + filtro + "'";
                    lblMensaje.CssClass = "mensaje mensaje-info";
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                listado = TicketController.ReadAll();
            }

            if (listado.Count > 0)
            {
                gvTickets.DataSource = listado;
                gvTickets.DataBind();
                gvTickets.Visible = true;
            }
            else
            {
                gvTickets.Visible = false;
                if (!lblMensaje.Visible)
                {
                    lblMensaje.Text = "No existen registros disponibles para mostrar";
                    lblMensaje.CssClass = "mensaje mensaje-info";
                    lblMensaje.Visible = true;
                }
            }
        }

        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                string ticketId = e.CommandArgument.ToString();
                Response.Redirect("~/DetalleTicket.aspx?id=" + ticketId);
            }
        }
    }
}