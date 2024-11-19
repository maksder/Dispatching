namespace Dispatching.Domain.History;

/// <summary>
/// Представляет репозиторий исторических событий.
/// </summary>
public interface IHistoryEventRepository
{
	#region Overridable
	/// <summary>
	/// Добавляет событие.
	/// </summary>
	/// <param name="historyEvent">Событие.</param>
	void Add(HistoryEvent historyEvent);

	/// <summary>
	/// Возвращает события по идентфикатору участника.
	/// </summary>
	/// <returns>События.</returns>
	IEnumerable<HistoryEvent> FindByParticipants(Guid participantId);
	#endregion
}
