namespace CQRS
{
    public sealed class ProductEntity
    {
        public ProductEntity
        (
            long id,
            string description
        )
        {
            Id = id;
            Description = description;
        }

        public long Id { get; private set; }

        public string Description { get; private set; }
    }
}
