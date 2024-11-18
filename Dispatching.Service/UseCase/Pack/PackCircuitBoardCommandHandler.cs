using Dispatching.Dal;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service.Helpers;
using MediatR;

namespace Dispatching.Service.UseCase.Pack;

/// <summary>
/// Представляет обработчик команды <see cref="PackCircuitBoardCommandHandler" />.
/// </summary>
public class PackCircuitBoardCommandHandler : IRequestHandler<PackCircuitBoardCommand, bool>
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
	/// Инициализирует новый экземпляр класса <see cref="PackCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <param name="historyEventRepository"><see cref="IHistoryEventRepository" />.</param>
	/// <param name="unitOfWork"><see cref="UnitOfWork{WriteDbContext}" />.</param>
	public PackCircuitBoardCommandHandler(ICircuitBoardRepository circuitBoardRepository, IHistoryEventRepository historyEventRepository, UnitOfWork<WriteDbContext> unitOfWork)
	{
		ArgumentNullException.ThrowIfNull(circuitBoardRepository);
		ArgumentNullException.ThrowIfNull(historyEventRepository);
		_circuitBoardRepository = circuitBoardRepository;
		_historyEventRepository = historyEventRepository;
		_unitOfWork = unitOfWork;
	}
	#endregion

	#region IRequestHandler<SetQualityControlResultForCircuitBoardCommand,Unit> members
	/// <inheritdoc />
	public async Task<bool> Handle(PackCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var circuitBoard = await CircuitBoardFindHelper.GetCircuitBoardAsync(request.CircuitBoardId, _circuitBoardRepository);
		circuitBoard!.Pack();
		_historyEventRepository.Add(new HistoryEvent(Guid.NewGuid(), $"Произведен упаковка платы {circuitBoard.Name}.", [circuitBoard.Id]));
		await _unitOfWork.CommitAsync(cancellationToken);
		return true;
	}
	#endregion
}
