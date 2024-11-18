using Dispatching.Domain.Common;

namespace Dispatching.Domain.History;

/// <summary>
/// Представляет историческое событие
/// </summary>
public class HistoryEvent : IEntity
{
	private readonly Guid[] _participants;
	#region .ctor
	public HistoryEvent(Guid id, string description, Guid[] participants)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(description);
		Id = id;
		Description = description;
		_participants = participants;
		CreatedDateTime = DateTime.UtcNow;
	}
	#endregion

	#region Properties
	/// <summary>
	/// Представляет дату и время создания события.
	/// </summary>
	public DateTime CreatedDateTime
	{
		get;
	}

	public IReadOnlyCollection<Guid> Participants => _participants;

	/// <summary>
	/// Возвращает описание события.
	/// </summary>
	public string Description
	{
		get;
	}
	#endregion

	#region IEntity members
	/// <inheritdoc />
	public Guid Id
	{
		get;
	}
	#endregion
}
