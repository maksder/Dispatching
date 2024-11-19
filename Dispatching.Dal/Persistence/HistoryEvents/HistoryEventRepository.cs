using Dispatching.Domain.History;

namespace Dispatching.Dal.Persistence.HistoryEvents;

/// <summary>
/// Представляет реализацию <see cref="IHistoryEventRepository" />.
/// </summary>
public class HistoryEventRepository : IHistoryEventRepository
{
	#region Data
	#region Fields
	private readonly WriteDbContext _dbContext;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр <see cref="HistoryEventRepository" />.
	/// </summary>
	/// <param name="dbContext"><see cref="WriteDbContext" />.</param>
	public HistoryEventRepository(WriteDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);
		_dbContext = dbContext;
	}
	#endregion

	#region IHistoryEventRepository members
	/// <inheritdoc />
	public void Add(HistoryEvent historyEvent)
	{
		_dbContext.HistoryEvents.Add(historyEvent);
	}

	/// <inheritdoc />
	public IEnumerable<HistoryEvent> FindByParticipants(Guid participantId) =>
		_dbContext.HistoryEvents.Where(p => p.Participants.Any(t => t == participantId))
				  .OrderBy(p => p.CreatedDateTime)
				  .ToList();
	#endregion
}
