using MediatR;

namespace CQRS
{
    public class ProductDeletedNotification : INotification
    {
        public ProductDeletedNotification(ProductEntity product)
        {
            Product = product;
        }

        public ProductEntity Product { get; private set; }
    }
}
