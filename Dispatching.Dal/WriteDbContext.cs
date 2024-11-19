using Dispatching.Domain.CircuitBoards;
using Dispatching.Domain.History;
using Microsoft.EntityFrameworkCore;

namespace Dispatching.Dal;

/// <summary>
/// Определяет контекст для записи данных.
/// </summary>
public class WriteDbContext : DbContext
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="WriteDbContext" />.
	/// </summary>
	/// <param name="options">Настройки контекста.</param>
	public WriteDbContext(DbContextOptions<WriteDbContext> options)
		: base(options)
	{
	}
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает платы.
	/// </summary>
	public DbSet<CircuitBoard> CircuitBoards
	{
		get;
		private set;
	}

	/// <summary>
	/// Возвращает исторические события.
	/// </summary>
	public DbSet<HistoryEvent> HistoryEvents
	{
		get;
		private set;
	}
	#endregion

	#region Overrided
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dispatching;Username=postgres;Password=1234"); //todo пренести в  apssetings.
	}

	/// <inheritdoc />
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(GetType()
														 .Assembly,
													 type => type.Namespace!.StartsWith(GetType()
																							.Namespace!));
	}
	#endregion
}
