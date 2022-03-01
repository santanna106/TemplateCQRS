using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly ICustomerRepository _context;
            private readonly IMediator _mediator;

            public CreateProductCommandHandler(ICustomerRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(CreateCustomerCommand command,
                CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.Name = command.Name;
                customer.Email = command.Email;
                _context.Add(customer);
                return customer.Id;
            }
        }
    }
}
