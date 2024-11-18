using Dispatching.Dal;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using MediatR;

namespace Dispatching.Service.UseCase.Create;

/// <summary>
/// Представляет обработчик команды <see cref="CreateCircuitBoardCommand" />.
/// </summary>
public class CreateCircuitBoardCommandHandler : IRequestHandler<CreateCircuitBoardCommand, Guid>
{
	#region Data
	#region Fields
	private readonly ICircuitBoardRepository _circuitBoardRepository;
	private readonly IHistoryEventRepository _historyEventRepository;
	private readonly UnitOfWork<WriteDbContext> _unitOfWork;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CreateCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <param name="historyEventRepository"><see cref="IHistoryEventRepository" />.</param>
	/// <param name="unitOfWork"><see cref="UnitOfWork{WriteDbContext}" />.</param>
	public CreateCircuitBoardCommandHandler(ICircuitBoardRepository circuitBoardRepository, IHistoryEventRepository historyEventRepository, UnitOfWork<WriteDbContext> unitOfWork)
	{
		ArgumentNullException.ThrowIfNull(circuitBoardRepository);
		ArgumentNullException.ThrowIfNull(historyEventRepository);
		_circuitBoardRepository = circuitBoardRepository;
		_historyEventRepository = historyEventRepository;
		_unitOfWork = unitOfWork;
	}
	#endregion

	#region IRequestHandler<CreateCircuitBoardCommand,Guid> members
	/// <inheritdoc />
	public async Task<Guid> Handle(CreateCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var id = Guid.NewGuid();
		_circuitBoardRepository.Add(new CircuitBoard(id, request.Name));
		_historyEventRepository.Add(new HistoryEvent(Guid.NewGuid(), $"Зарегистрирована плата {request.Name}.", [id]));
		await _unitOfWork.CommitAsync(cancellationToken);
		return id;
	}
	#endregion
}
