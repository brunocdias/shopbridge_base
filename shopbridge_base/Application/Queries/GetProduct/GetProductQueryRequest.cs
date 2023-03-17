using MediatR;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;
using System.Collections.Generic;

namespace Shopbridge_base.Application.Queries.GetProduct
{
    public class GetProductQueryRequest : IRequest<ReturnModel<IEnumerable<ProductModel>>>
    {
    }
}
