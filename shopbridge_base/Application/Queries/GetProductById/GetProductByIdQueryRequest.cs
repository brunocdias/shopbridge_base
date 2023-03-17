using MediatR;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;

namespace Shopbridge_base.Application.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<ReturnModel<ProductModel>>
    {
        public int Id { get; set; }
    }
}
