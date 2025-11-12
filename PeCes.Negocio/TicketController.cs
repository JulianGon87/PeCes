using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeCes.Datos;

namespace PeCes.Negocio
{
    public static class TicketController
    {
        public static string Create(Ticket ticket)
        {
            try
            {
                TicketEntity ticketEntity = new TicketEntity();

                if (ticket.Cliente is Empresa)
                {
                    Empresa clienteNegocio = (Empresa)ticket.Cliente;
                    EmpresaEntity clienteEntity = new EmpresaEntity
                    {
                        Id = clienteNegocio.Id,
                        Nombre = clienteNegocio.Nombre,
                        Rut = clienteNegocio.Rut,
                        Telefono = clienteNegocio.Telefono,
                        Email = clienteNegocio.Email,
                        RazonSocial = clienteNegocio.RazonSocial
                    };
                    ticketEntity.Cliente = clienteEntity;
                }
                else
                {
                    PersonaNatural clienteNegocio = (PersonaNatural)ticket.Cliente;
                    PersonaNaturalEntity clienteEntity = new PersonaNaturalEntity
                    {
                        Id = clienteNegocio.Id,
                        Nombre = clienteNegocio.Nombre,
                        Rut = clienteNegocio.Rut,
                        Telefono = clienteNegocio.Telefono,
                        Email = clienteNegocio.Email
                    };
                    ticketEntity.Cliente = clienteEntity;
                }

                ticketEntity.Producto = ticket.Producto;
                ticketEntity.Descripción = ticket.Descripción;
                ticketEntity.Estado = ticket.Estado;

                TicketEntityCollection.ListadoTickets.Add(ticketEntity);

                return "El ticket fue agregado con éxito";
            }
            catch (Exception)
            {
                return "El ticket no pudo ser agregado";
            }
        }

        public static Ticket Read(string id)
        {
            TicketEntity ticketEntity = TicketEntityCollection.ListadoTickets.Find(t => t.Id == id);

            if (ticketEntity == null)
            {
                return null;
            }

            Ticket ticketNegocio = new Ticket();

            if (ticketEntity.Cliente is EmpresaEntity)
            {
                EmpresaEntity clienteEntity = (EmpresaEntity)ticketEntity.Cliente;
                Empresa clienteNegocio = new Empresa
                {
                    Id = clienteEntity.Id,
                    Nombre = clienteEntity.Nombre,
                    Rut = clienteEntity.Rut,
                    Telefono = clienteEntity.Telefono,
                    Email = clienteEntity.Email,
                    RazonSocial = clienteEntity.RazonSocial
                };
                ticketNegocio.Cliente = clienteNegocio;
            }
            else
            {
                PersonaNaturalEntity clienteEntity = (PersonaNaturalEntity)ticketEntity.Cliente;
                PersonaNatural clienteNegocio = new PersonaNatural
                {
                    Id = clienteEntity.Id,
                    Nombre = clienteEntity.Nombre,
                    Rut = clienteEntity.Rut,
                    Telefono = clienteEntity.Telefono,
                    Email = clienteEntity.Email
                };
                ticketNegocio.Cliente = clienteNegocio;
            }

            ticketNegocio.Id = ticketEntity.Id;
            ticketNegocio.Producto = ticketEntity.Producto;
            ticketNegocio.Descripción = ticketEntity.Descripción;
            ticketNegocio.Estado = ticketEntity.Estado;

            return ticketNegocio;
        }

        public static string Update(string id, string producto, string descripcion, string estado, string email, string telefono)
        {
            try
            {
                TicketEntity ticketEntity = TicketEntityCollection.ListadoTickets.Find(t => t.Id == id);

                if (ticketEntity == null)
                {
                    return "Error: No se encontró el ticket";
                }

                ticketEntity.Producto = producto;
                ticketEntity.Descripción = descripcion;
                ticketEntity.Estado = estado;
                ticketEntity.Cliente.Email = email;
                ticketEntity.Cliente.Telefono = telefono;

                return "Ticket actualizado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public static string Delete(string id)
        {
            try
            {
                TicketEntity ticketEntity = TicketEntityCollection.ListadoTickets.Find(t => t.Id == id);

                if (ticketEntity == null)
                {
                    return "Error: No se encontró el ticket";
                }

                TicketEntityCollection.ListadoTickets.Remove(ticketEntity);
                return "Ticket eliminado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }

        public static List<Ticket> ReadAll()
        {
            List<Ticket> listadoNegocio = new List<Ticket>();

            foreach (TicketEntity ticketEntity in TicketEntityCollection.ListadoTickets)
            {
                Ticket ticketNegocio = new Ticket();

                if (ticketEntity.Cliente is EmpresaEntity)
                {
                    EmpresaEntity clienteEntity = (EmpresaEntity)ticketEntity.Cliente;
                    Empresa clienteNegocio = new Empresa
                    {
                        Id = clienteEntity.Id,
                        Nombre = clienteEntity.Nombre,
                        Rut = clienteEntity.Rut,
                        Telefono = clienteEntity.Telefono,
                        Email = clienteEntity.Email,
                        RazonSocial = clienteEntity.RazonSocial
                    };
                    ticketNegocio.Cliente = clienteNegocio;
                }
                else
                {
                    PersonaNaturalEntity clienteEntity = (PersonaNaturalEntity)ticketEntity.Cliente;
                    PersonaNatural clienteNegocio = new PersonaNatural
                    {
                        Id = clienteEntity.Id,
                        Nombre = clienteEntity.Nombre,
                        Rut = clienteEntity.Rut,
                        Telefono = clienteEntity.Telefono,
                        Email = clienteEntity.Email
                    };
                    ticketNegocio.Cliente = clienteNegocio;
                }

                ticketNegocio.Id = ticketEntity.Id;
                ticketNegocio.Producto = ticketEntity.Producto;
                ticketNegocio.Descripción = ticketEntity.Descripción;
                ticketNegocio.Estado = ticketEntity.Estado;

                listadoNegocio.Add(ticketNegocio);
            }

            return listadoNegocio;
        }

        public static List<Ticket> Search(string filtro)
        {
            List<Ticket> listadoNegocio = new List<Ticket>();

            var listadoFiltrado = TicketEntityCollection.ListadoTickets.Where(
                t => t.Cliente.Nombre.Contains(filtro) ||
                     t.Cliente.Rut.Contains(filtro) ||
                     t.Estado.Contains(filtro)
            ).ToList();


            foreach (TicketEntity ticketEntity in listadoFiltrado)
            {
                Ticket ticketNegocio = new Ticket();

                if (ticketEntity.Cliente is EmpresaEntity)
                {
                    EmpresaEntity clienteEntity = (EmpresaEntity)ticketEntity.Cliente;
                    Empresa clienteNegocio = new Empresa
                    {
                        Id = clienteEntity.Id,
                        Nombre = clienteEntity.Nombre,
                        Rut = clienteEntity.Rut,
                        Telefono = clienteEntity.Telefono,
                        Email = clienteEntity.Email,
                        RazonSocial = clienteEntity.RazonSocial
                    };
                    ticketNegocio.Cliente = clienteNegocio;
                }
                else
                {
                    PersonaNaturalEntity clienteEntity = (PersonaNaturalEntity)ticketEntity.Cliente;
                    PersonaNatural clienteNegocio = new PersonaNatural
                    {
                        Id = clienteEntity.Id,
                        Nombre = clienteEntity.Nombre,
                        Rut = clienteEntity.Rut,
                        Telefono = clienteEntity.Telefono,
                        Email = clienteEntity.Email
                    };
                    ticketNegocio.Cliente = clienteNegocio;
                }

                ticketNegocio.Id = ticketEntity.Id;
                ticketNegocio.Producto = ticketEntity.Producto;
                ticketNegocio.Descripción = ticketEntity.Descripción;
                ticketNegocio.Estado = ticketEntity.Estado;

                listadoNegocio.Add(ticketNegocio);
            }

            return listadoNegocio;
        }
    }
}