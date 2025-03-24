using Ambev.DeveloperEvaluation.Application.SalesItems.GetSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSaleItem;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<Guid, GetSaleItemCommand>()
            .ConstructUsing(id => new GetSaleItemCommand(id));
    }
}