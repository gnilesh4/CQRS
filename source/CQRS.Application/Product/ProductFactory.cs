namespace CQRS
{
    public static class ProductFactory
    {
        public static ProductEntity Create(InsertProductCommand command)
        {
            return new ProductEntity(default, command.Description);
        }

        public static ProductEntity Create(DeleteProductCommand command)
        {
            return new ProductEntity(command.Id, string.Empty);
        }

        public static ProductEntity Create(UpdateProductCommand command)
        {
            return new ProductEntity(command.Id, command.Description);
        }
    }
}
