using AutoMapper;
using MediatR;

using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Infrastructure.Language;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopbridge_base.Application.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ReturnModel<IEnumerable<ProductModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetProductQueryHandler(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var errors = Array.Empty<string>();

            var productList = await _repository.Get();
            
            if (productList.Count() == 0)
                errors = new[] { Message.DataNotFound.ToMessage() };
            
            var p = _mapper.Map<IEnumerable<ProductModel>>(productList);

            return new ReturnModel<IEnumerable<ProductModel>>()
            {
                Errors = errors,
                Return = p,
                Success = !errors.Any()
            };
        }
    }
}
