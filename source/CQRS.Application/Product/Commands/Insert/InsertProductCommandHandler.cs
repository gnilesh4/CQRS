using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class InsertProductCommandHandler : AsyncRequestHandler<InsertProductCommand>
    {
        private readonly IMediator _mediator;

        public InsertProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override Task Handle(InsertProductCommand command, CancellationToken cancellationToken)
        {
            var entity = ProductFactory.Create(command);

            _mediator.Publish(new ProductInsertedNotification(entity));

            return Task.CompletedTask;
        }
    }
}
