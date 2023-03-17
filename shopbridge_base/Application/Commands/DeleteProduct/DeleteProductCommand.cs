using MediatR;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;

namespace Shopbridge_base.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : ProductModel, IRequest<ReturnModel<Unit>>
    {
    }
}
