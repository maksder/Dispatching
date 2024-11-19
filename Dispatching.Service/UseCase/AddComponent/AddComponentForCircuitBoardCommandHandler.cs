using Dispatching.Dal;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service.Helpers;
using MediatR;

namespace Dispatching.Service.UseCase.AddComponent;

/// <summary>
/// Представляет обработчик команды <see cref="AddComponentForCircuitBoardCommand" />.
/// </summary>
public class AddComponentForCircuitBoardCommandHandler : IRequestHandler<AddComponentForCircuitBoardCommand>
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
	/// Инициализирует новый экземпляр класса <see cref="AddComponentForCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <param name="historyEventRepository"><see cref="IHistoryEventRepository" />.</param>
	/// <param name="unitOfWork"><see cref="UnitOfWork{WriteDbContext}" />.</param>
	public AddComponentForCircuitBoardCommandHandler(ICircuitBoardRepository circuitBoardRepository,
													 IHistoryEventRepository historyEventRepository,
													 UnitOfWork<WriteDbContext> unitOfWork)
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
	public async Task<Unit> Handle(AddComponentForCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var componentId = Guid.NewGuid();
		var circuitBoard = await CircuitBoardFindHelper.GetCircuitBoardAsync(request.CircuitBoardId, _circuitBoardRepository);
		circuitBoard!.AddComponent(new CircuitBoardComponent(Guid.NewGuid(), request.ComponentName));
		_historyEventRepository.Add(new HistoryEvent(Guid.NewGuid(), $"На плату {circuitBoard.Name} добавлен компонент {request.ComponentName}.", [circuitBoard.Id, componentId]));
		await _unitOfWork.CommitAsync(cancellationToken);
		return Unit.Value;
	}
	#endregion
}
