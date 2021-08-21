using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.IService
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetAll();
        Task<Ticket> Create(CreateTicketInput ticket);
        Task<Ticket> Updated(UpdateTicketInput ticketUpdate);
        Task<bool> Delete(DeleteTicketInput ticketDelete);
    }
}
