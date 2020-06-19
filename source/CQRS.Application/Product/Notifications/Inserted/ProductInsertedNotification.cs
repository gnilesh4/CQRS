using MediatR;

namespace CQRS
{
    public class ProductInsertedNotification : INotification
    {
        public ProductInsertedNotification(ProductEntity product)
        {
            Product = product;
        }

        public ProductEntity Product { get; private set; }
    }
}
