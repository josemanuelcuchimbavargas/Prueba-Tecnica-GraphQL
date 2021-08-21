using Core.Entities;
using Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.GraphQL
{
    public class Mutation
    {
        #region Property  
        private readonly ITicketService _ticketService;
        #endregion

        #region Constructor  
        public Mutation(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        #endregion
        public async Task<Ticket> Create(CreateTicketInput ticket) => await _ticketService.Create(ticket);
        public async Task<Ticket> Updated(UpdateTicketInput ticket) => await _ticketService.Updated(ticket);
        public async Task<bool> Delete(DeleteTicketInput ticketDelete) => await _ticketService.Delete(ticketDelete);
    }
}
