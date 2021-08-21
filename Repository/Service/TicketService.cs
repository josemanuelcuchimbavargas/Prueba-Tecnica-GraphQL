using Backend.Model;
using Core.Entities;
using Core.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class TicketService : ITicketService
    {        

        private readonly DBContext _dbContext;

        public TicketService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> Create(CreateTicketInput ticket)
        {
            var data = new Ticket
            {
               user = ticket.user,
               status = ticket.status,
               created_date = DateTime.Now,
               updated_date = DateTime.Now
            };
            await _dbContext.Tickets.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public async Task<Ticket> Updated(UpdateTicketInput ticketUpdate)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(c => c.id == ticketUpdate.id);
            ticket.user = ticketUpdate.user;
            ticket.status = ticketUpdate.status;
            ticket.updated_date = DateTime.Now;

            await _dbContext.Tickets.AddAsync(ticket);
            _dbContext.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> Delete(DeleteTicketInput ticketDelete)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(c => c.id == ticketDelete.id);
            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _dbContext.Tickets.AsQueryable();
        }

    }
}
