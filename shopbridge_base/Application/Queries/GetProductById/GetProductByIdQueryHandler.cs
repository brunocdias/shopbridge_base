using AutoMapper;
using MediatR;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Infrastructure.Language;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopbridge_base.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ReturnModel<ProductModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetProductByIdQueryHandler(IMapper mapper, 
            IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnModel<ProductModel>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var errors = Array.Empty<string>();

            var product = await _repository.GetById(request.Id);

            if (product == null)
                errors = new[] { Message.DataNotFound.ToMessage() };

            var p = _mapper.Map<ProductModel>(product);

            return new ReturnModel<ProductModel>()
            {
                Errors = errors,
                Return = p,
                Success = !errors.Any()
            };
        }
    }
}
