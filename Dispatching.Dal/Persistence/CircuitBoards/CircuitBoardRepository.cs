using Dispatching.Domain.CircuitBoards;
using Microsoft.EntityFrameworkCore;

namespace Dispatching.Dal.Persistence.CircuitBoards;

/// <summary>
/// Представляет реализацию <see cref="ICircuitBoardRepository" />.
/// </summary>
public class CircuitBoardRepository : ICircuitBoardRepository
{
	#region Data
	#region Fields
	private readonly WriteDbContext _dbContext;
	#endregion
	#endregion

	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр <see cref="CircuitBoardRepository" />.
	/// </summary>
	/// <param name="dbContext"><see cref="WriteDbContext" />.</param>
	public CircuitBoardRepository(WriteDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);
		_dbContext = dbContext;
	}
	#endregion

	#region ICircuitBoardRepository members
	/// <inheritdoc />
	public void Add(CircuitBoard circuitBoard)
	{
		_dbContext.CircuitBoards.Add(circuitBoard);
	}

	/// <inheritdoc />
	public Task<CircuitBoard?> FindAsync(Guid circuitBoardId) => _dbContext.CircuitBoards.SingleOrDefaultAsync(p => p.Id == circuitBoardId);

	/// <inheritdoc />
	public IEnumerable<CircuitBoard> FindRange(IEnumerable<Guid> circuitBoardIds) =>
		_dbContext.CircuitBoards.Where(p => circuitBoardIds.ToList()
														   .Contains(p.Id));

	/// <inheritdoc />
	public Task<int> UpdateAsync() => _dbContext.SaveChangesAsync();
	#endregion
}
