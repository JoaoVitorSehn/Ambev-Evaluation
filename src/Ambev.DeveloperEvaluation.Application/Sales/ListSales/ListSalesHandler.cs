using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class ListSalesHandler : IRequestHandler<ListSalesCommand, ListSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListSalesHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ListSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<ListSaleResult> Handle(ListSalesCommand request, CancellationToken cancellationToken)
    {
        var salesQuery = await _saleRepository.GetAsync(request.PageNumber, request.PageSize, cancellationToken, "SaleItems");
        var sales = salesQuery.Sales.Select(sale => _mapper.Map<GetSaleResult>(sale));

        return new ListSaleResult
        {
            Sales = sales,
            Count = salesQuery.Count
        };
    }
}