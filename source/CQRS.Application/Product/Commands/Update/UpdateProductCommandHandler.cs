using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {
        private readonly IMediator _mediator;

        public UpdateProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var entity = ProductFactory.Create(command);

            _mediator.Publish(new ProductUpdatedNotification(entity));

            return Task.CompletedTask;
        }
    }
}
