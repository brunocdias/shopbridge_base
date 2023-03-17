using MediatR;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;

namespace Shopbridge_base.Application.Commands.PostProduct
{
    public class PostProductCommand : ProductModel, IRequest<ReturnModel<ProductModel>>
    {
       
    }
}
