using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class ProductDeletedNotificationHandler : INotificationHandler<ProductDeletedNotification>
    {
        public Task Handle(ProductDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
