using Dispatching.Domain.Common;

namespace Dispatching.Domain.History;

/// <summary>
/// Представляет историческое событие
/// </summary>
public class HistoryEvent : IEntity
{
	#region .ctor
	public HistoryEvent(Guid id, string description)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(description);
		Id = id;
		Description = description;
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
