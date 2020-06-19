using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IMediator _mediator;

        public DeleteProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var entity = ProductFactory.Create(command);

            _mediator.Publish(new ProductDeletedNotification(entity));

            return Task.CompletedTask;
        }
    }
}
