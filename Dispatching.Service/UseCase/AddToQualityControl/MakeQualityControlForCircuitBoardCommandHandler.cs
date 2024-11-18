using Dispatching.Dal;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service.Helpers;
using MediatR;

namespace Dispatching.Service.UseCase.AddToQualityControl;

/// <summary>
/// Представляет обработчик команды <see cref="MakeQualityControlForCircuitBoardCommand" />.
/// </summary>
public class MakeQualityControlForCircuitBoardCommandHandler : IRequestHandler<MakeQualityControlForCircuitBoardCommand, bool>
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
	/// Инициализирует новый экземпляр класса <see cref="MakeQualityControlForCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <param name="historyEventRepository"><see cref="IHistoryEventRepository" />.</param>
	/// <param name="unitOfWork"><see cref="UnitOfWork{WriteDbContext}" />.</param>
	public MakeQualityControlForCircuitBoardCommandHandler(ICircuitBoardRepository circuitBoardRepository,
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
	public async Task<bool> Handle(MakeQualityControlForCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var circuitBoard = await CircuitBoardFindHelper.GetCircuitBoardAsync(request.CircuitBoardId, _circuitBoardRepository);
		circuitBoard!.MakeQualityControl();
		_historyEventRepository.Add(new HistoryEvent(Guid.NewGuid(), $"Плата {circuitBoard.Name} произведен контроль качества.", [circuitBoard.Id]));
		await _unitOfWork.CommitAsync(cancellationToken);
		return true;
	}
	#endregion
}
