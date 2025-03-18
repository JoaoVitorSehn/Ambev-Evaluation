using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        public Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {

        }
    }
}