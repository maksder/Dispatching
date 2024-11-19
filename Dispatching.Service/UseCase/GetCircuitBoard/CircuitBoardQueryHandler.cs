using Dispatching.Domain.CircuitBoards;
using MediatR;

namespace Dispatching.Service.UseCase.GetCircuitBoard;

/// <summary>
/// Представляет обработчик запроса <see cref="CircuitBoardQuery" />.
/// </summary>
public class CircuitBoardQueryHandler : IRequestHandler<CircuitBoardQuery, CircuitBoard?>
{
	#region Data
	#region Fields
	private readonly ICircuitBoardRepository _circuitBoardRepository;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CircuitBoardQueryHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	public CircuitBoardQueryHandler(ICircuitBoardRepository circuitBoardRepository)
	{
		ArgumentNullException.ThrowIfNull(circuitBoardRepository);
		_circuitBoardRepository = circuitBoardRepository;
	}
	#endregion

	#region IRequestHandler<CreateCircuitBoardCommand,Guid> members
	/// <inheritdoc />
	public Task<CircuitBoard?> Handle(CircuitBoardQuery request, CancellationToken cancellationToken) => _circuitBoardRepository.FindAsync(request.Id);
	#endregion
}
