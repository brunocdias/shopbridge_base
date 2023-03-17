using AutoMapper;
using MediatR;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Infrastructure.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopbridge_base.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ReturnModel<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnModel<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var errors = Array.Empty<string>();

            await _repository.DeleteAsync(request.Product_Id);

            return new ReturnModel<Unit>()
            {
                Errors = errors,
                Return = Unit.Value,
                Success = !errors.Any()
            };
        }
    }
}
