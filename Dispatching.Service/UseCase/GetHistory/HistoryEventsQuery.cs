using Dispatching.Domain.History;
using MediatR;

namespace Dispatching.Service.UseCase.GetHistory;

/// <summary>
/// Представляет запрос истории.
/// </summary>
public class HistoryEventsQuery : IRequest<IEnumerable<HistoryEvent>>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="HistoryEventsQuery" />.
	/// </summary>
	/// <param name="participantId">Идентификатор платы.</param>
	public HistoryEventsQuery(Guid participantId) => ParticipantId = participantId;
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает идентификатор участника события.
	/// </summary>
	public Guid ParticipantId
	{
		get;
	}
	#endregion
}
