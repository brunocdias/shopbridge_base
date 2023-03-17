using MediatR;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;

namespace Shopbridge_base.Application.Commands.PutProduct
{
    public class PutProductCommand : ProductModel, IRequest<ReturnModel<ProductModel>>
    {
    }
}
