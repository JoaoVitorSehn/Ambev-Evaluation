using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using MediatR;
using NSubstitute;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="DeleteSaleHandler"/> class.
/// </summary>
public class DeleteSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMediator _mediator;
    private readonly DeleteSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public DeleteSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mediator = Substitute.For<IMediator>();
        _handler = new DeleteSaleHandler(_saleRepository);
    }

    /// <summary>
    /// Tests that a valid sale deletion request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale id When deleting sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = new DeleteSaleCommand(Guid.NewGuid());

        _saleRepository.DeleteAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(true);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();

        await _saleRepository.Received(1).DeleteAsync(command.Id, Arg.Any<CancellationToken>());
    }
}