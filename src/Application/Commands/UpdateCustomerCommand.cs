using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly ICustomerRepository _context;
            private readonly IMediator _mediator;
            public UpdateProductCommandHandler(ICustomerRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _context.GetById(command.Id);
                if (customer == null) return default;
                customer.Name = command.Name;
                customer.Email = command.Email;
                _context.Update(customer);
                return customer.Id;
            }
        }
    }
}

