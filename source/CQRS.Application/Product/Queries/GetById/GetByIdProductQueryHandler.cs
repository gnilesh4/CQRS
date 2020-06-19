using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductViewModel>
    {
        public Task<ProductViewModel> Handle(GetByIdProductQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductViewModel { Id = query.Id });
        }
    }
}
