using MediatR;

namespace CQRS
{
    public class ProductUpdatedNotification : INotification
    {
        public ProductUpdatedNotification(ProductEntity product)
        {
            Product = product;
        }

        public ProductEntity Product { get; private set; }
    }
}
