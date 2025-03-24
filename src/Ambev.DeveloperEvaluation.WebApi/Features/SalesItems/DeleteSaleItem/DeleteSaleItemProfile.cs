using Ambev.DeveloperEvaluation.Application.SalesItems.DeleteSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSaleItem;

/// <summary>
/// Profile for mapping between Application and API DeleteSaleItem responses
/// </summary>
public class DeleteSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSaleItem feature
    /// </summary>
    public DeleteSaleItemProfile()
    {
        CreateMap<Guid, DeleteSaleItemCommand>()
            .ConstructUsing(id => new DeleteSaleItemCommand(id));
    }
}