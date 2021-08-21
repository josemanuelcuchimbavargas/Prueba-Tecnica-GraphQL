using Core.Entities;
using Core.IService;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.GraphQL
{
    public class Query
    {
        #region Property  
        private readonly ITicketService _ticketService;
        #endregion

        #region Constructor  
        public Query(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        #endregion

        [UseFiltering]
        [UseSorting]
        [UseOffsetPaging(MaxPageSize = 2)]
        public IQueryable<Ticket> Tickets => _ticketService.GetAll();



    }
}
