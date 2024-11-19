using Dispatching.Dal;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service.Helpers;
using MediatR;

namespace Dispatching.Service.UseCase.SetQualityControlResult;

/// <summary>
/// Представляет обработчик команды <see cref="SetQualityControlResultForCircuitBoardCommand" />.
/// </summary>
public class SetQualityControlResultForCircuitBoardCommandHandler : IRequestHandler<SetQualityControlResultForCircuitBoardCommand>
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
	/// Инициализирует новый экземпляр класса <see cref="SetQualityControlResultForCircuitBoardCommandHandler" />.
	/// </summary>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <param name="historyEventRepository"><see cref="IHistoryEventRepository" />.</param>
	/// <param name="unitOfWork"><see cref="UnitOfWork{WriteDbContext}" />.</param>
	public SetQualityControlResultForCircuitBoardCommandHandler(ICircuitBoardRepository circuitBoardRepository,
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

	#region IRequestHandler<SetQualityControlResultForCircuitBoardCommand,bool> members
	/// <inheritdoc />
	public async Task<Unit> Handle(SetQualityControlResultForCircuitBoardCommand request, CancellationToken cancellationToken)
	{
		var circuitBoard = await CircuitBoardFindHelper.GetCircuitBoardAsync(request.CircuitBoardId, _circuitBoardRepository);
		circuitBoard!.SetQualityControlResult(request.QualityControlResult);
		_historyEventRepository.Add(new HistoryEvent(Guid.NewGuid(),
													 $"Установлен результат контроля качества плате {circuitBoard.Name}. Результат: плата {(request.QualityControlResult ? "годная" : "негодная")}.",
													 [circuitBoard.Id]));
		await _unitOfWork.CommitAsync(cancellationToken);
		return Unit.Value;
	}
	#endregion
}
