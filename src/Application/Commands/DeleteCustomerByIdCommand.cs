using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteCustomerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
        {
            private readonly ICustomerRepository _context;
            private readonly IMediator _mediator;
            public DeleteProductByIdCommandHandler(ICustomerRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customer = await _context.GetById(command.Id);
                if (customer == null) return default;
                _context.Remove(customer);
                return customer.Id;
            }
        }
    }
}
