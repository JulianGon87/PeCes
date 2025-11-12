using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeCes.Negocio;

namespace PeCes.Web
{
    public partial class CrearTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDownLists();
            }
        }

        private void CargarDropDownLists()
        {
            ddlTipoCliente.Items.Clear();
            ddlTipoCliente.Items.Add(new ListItem("Seleccionar", ""));
            ddlTipoCliente.Items[0].Attributes["disabled"] = "disabled";
            ddlTipoCliente.Items[0].Selected = true;
            ddlTipoCliente.Items.Add(new ListItem("Persona Natural", "Persona"));
            ddlTipoCliente.Items.Add(new ListItem("Empresa", "Empresa"));

            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("Seleccionar", ""));
            ddlEstado.Items[0].Attributes["disabled"] = "disabled";
            ddlEstado.Items[0].Selected = true;
            ddlEstado.Items.Add(new ListItem("Ingresado", "Ingresado"));
            ddlEstado.Items.Add(new ListItem("En Revisión", "En Revisión"));
            ddlEstado.Items.Add(new ListItem("Terminado", "Terminado"));
        }

        protected void ddlTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCliente.SelectedValue == "Empresa")
            {
                pnlRazonSocial.Visible = true;
            }
            else
            {
                pnlRazonSocial.Visible = false;
            }
        }

        protected void btnCrearTicket_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevoCliente;

                if (ddlTipoCliente.SelectedValue == "Empresa")
                {
                    nuevoCliente = new Empresa
                    {
                        Nombre = txtNombre.Text,
                        Rut = txtRut.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEmail.Text,
                        RazonSocial = txtRazonSocial.Text
                    };
                }
                else
                {
                    nuevoCliente = new PersonaNatural
                    {
                        Nombre = txtNombre.Text,
                        Rut = txtRut.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEmail.Text
                    };
                }

                Ticket nuevoTicket = new Ticket
                {
                    Cliente = nuevoCliente,
                    Producto = txtProducto.Text,
                    Descripción = txtDescripcion.Text,
                    Estado = ddlEstado.SelectedValue
                };

                string mensaje = TicketController.Create(nuevoTicket);

                Response.Redirect("~/ListadoTickets.aspx?mensaje=" + Server.UrlEncode(mensaje), false);
            }
            catch (Exception ex)
            {
                string mensajeError = "El ticket no pudo ser agregado. Error: " + ex.Message;
                Response.Redirect("~/ListadoTickets.aspx?mensaje=" + Server.UrlEncode(mensajeError));
            }
        }
    }
}