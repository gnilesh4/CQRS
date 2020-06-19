using MediatR;

namespace CQRS
{
    public class GetByIdProductQuery : IRequest<ProductViewModel>
    {
        public long Id { get; set; }
    }
}
