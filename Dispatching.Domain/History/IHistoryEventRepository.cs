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
	/// Возвращает события.
	/// </summary>
	/// <returns>События.</returns>
	IReadOnlyCollection<HistoryEvent> FindRange();
	#endregion
}
