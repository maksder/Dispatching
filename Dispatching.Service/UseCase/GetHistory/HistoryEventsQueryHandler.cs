using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Dispatching.Service.UseCase.GetCircuitBoard;
using MediatR;

namespace Dispatching.Service.UseCase.GetHistory;

/// <summary>
/// Представляет обработчик запроса <see cref="CircuitBoardQuery" />.
/// </summary>
public class HistoryEventsQueryHandler : IRequestHandler<HistoryEventsQuery, IEnumerable<HistoryEvent>>
{
	#region Data
	#region Fields
	private readonly IHistoryEventRepository _historyEventRepository;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CircuitBoardQueryHandler" />.
	/// </summary>
	/// <param name="historyEventRepository"><see cref="ICircuitBoardRepository" />.</param>
	public HistoryEventsQueryHandler(IHistoryEventRepository historyEventRepository)
	{
		ArgumentNullException.ThrowIfNull(historyEventRepository);
		_historyEventRepository = historyEventRepository;
	}
	#endregion

	/// <inheritdoc />
	public Task<IEnumerable<HistoryEvent>> Handle(HistoryEventsQuery request, CancellationToken cancellationToken) =>
		Task.FromResult(_historyEventRepository.FindByParticipants(request.ParticipantId));
}
