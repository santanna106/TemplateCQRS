using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,
            IEnumerable<Customer>>
        {
            private readonly ICustomerRepository _context;
          
            public GetAllCustomersQueryHandler(ICustomerRepository context)
            {
                _context = context;
             
            }

            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query,
                CancellationToken cancellationToken)
            {
                var customerList = await _context.GetAll();
                if (customerList == null) return default;

                return customerList;
            }
        }
    }
}
