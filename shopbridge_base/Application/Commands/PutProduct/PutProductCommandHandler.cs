using AutoMapper;
using MediatR;
using Shopbridge_base.Application.Commands.PostProduct;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Infrastructure.Models;
using Shopbridge_base.Infrastructure.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopbridge_base.Application.Commands.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, ReturnModel<ProductModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public PutProductCommandHandler(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnModel<ProductModel>> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var errors = Array.Empty<string>();

            var product = _mapper.Map<Product>(request);

            await _repository.UpdateAsync(product);

            var p = _mapper.Map<PostProductCommand>(product);

            return new ReturnModel<ProductModel>()
            {
                Errors = errors,
                Return = p,
                Success = !errors.Any()
            };
        }
    }
}
