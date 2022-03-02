using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
        {
            private readonly ICustomerRepository _context;
            private readonly IMediator _mediator;
            public GetProductByIdQueryHandler(ICustomerRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = await _context.GetById(query.Id);

                if (customer == null) return default;

                return customer;
            }
        }
    }
}
