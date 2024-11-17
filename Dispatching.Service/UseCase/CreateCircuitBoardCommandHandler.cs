using Dispatching.Domain.CircuitBoards;
using MediatR;

namespace Dispatching.Service.UseCase;

/// <summary>
/// Представляет обработчик команды <see cref="CreateCircuitBoardCommand" />.
/// </summary>
public class CreateCircuitBoardCommandHandler : IRequestHandler<CreateCircuitBoardCommand, Guid>
{
	#region Data
	#region Fields
	private readonly ICircuitBoardRepository _repository;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CreateCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="repository"><see cref="ICircuitBoardRepository" />.</param>
	public CreateCircuitBoardCommandHandler(ICircuitBoardRepository repository)
	{
		ArgumentNullException.ThrowIfNull(repository);
		_repository = repository;
	}
	#endregion

	#region IRequestHandler<CreateCircuitBoardCommand,Guid> members
	/// <inheritdoc />
	public async Task<Guid> Handle(CreateCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var id = Guid.NewGuid();
		await _repository.Add(new CircuitBoard(id, request.Name));
		return id;
	}
	#endregion
}
