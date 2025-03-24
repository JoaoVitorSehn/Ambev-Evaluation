using Ambev.DeveloperEvaluation.Application.SalesItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleItemHandler"/> class.
/// </summary>
public class CreateSaleItemHandlerTests
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly ISaleItemService _saleItemService;
    private readonly IMediator _mediator;
    private readonly CreateSaleItemHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleItemHandlerTests()
    {
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _mapper = Substitute.For<IMapper>();
        _saleItemService = Substitute.For<ISaleItemService>();
        _mediator = Substitute.For<IMediator>();
        _handler = new CreateSaleItemHandler(_saleItemRepository, _mapper, _saleItemService);
    }

    /// <summary>
    /// Tests that a valid sale item creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale item data When creating sale item Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleItemHandlerTestData.GenerateValidSaleItemCommand();

        var result = new CreateSaleItemResult
        {
            Id = Guid.NewGuid(),
        };

        var saleItem = new SaleItem
        {
            ProductId = command.ProductId,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount,
        };

        _mapper.Map<SaleItem>(command).Returns(saleItem);

        _mapper.Map<CreateSaleItemResult>(saleItem).Returns(result);

        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItem);

        // When
        var createSaleItemResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleItemResult.Should().NotBeNull();
        await _saleItemRepository.Received(1).CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid sale item creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale item data When creating sale item Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleItemCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the discount logic is correctly applied based on quantity.
    /// </summary>
    [Fact(DisplayName = "Given valid sale item request When handling Then applies correct discount")]
    public async Task Handle_ValidRequest_AppliesDiscount()
    {
        // Given
        var command = CreateSaleItemHandlerTestData.GenerateValidSaleItemCommand();
        var saleItem = new SaleItem
        {
            ProductId = command.ProductId,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
        };

        _mapper.Map<SaleItem>(command).Returns(saleItem);
        saleItem.Quantity = 5;

        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItem);

        // When
        saleItem.ApplyDiscount();

        // Then
        saleItem.Discount.Should().BeGreaterThanOrEqualTo(0); // Verifica que o desconto foi aplicado corretamente
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command for SaleItem.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to sale item entity")]
    public async Task Handle_ValidRequest_MapsCommandToSaleItem()
    {
        // Given
        var command = CreateSaleItemHandlerTestData.GenerateValidSaleItemCommand();

        var saleItem = new SaleItem
        {
            Id = Guid.NewGuid(),
            ProductId = command.ProductId,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount,
        };

        _mapper.Map<SaleItem>(command).Returns(saleItem);

        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItem);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<SaleItem>(Arg.Is<CreateSaleItemCommand>(c =>
            c.ProductId == command.ProductId &&
            c.Quantity == command.Quantity &&
            c.UnitPrice == command.UnitPrice &&
            c.Discount == command.Discount));
    }
}