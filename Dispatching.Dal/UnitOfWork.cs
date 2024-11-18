using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dispatching.Dal
{
	/// <summary>
	/// Представляет реализацию UnitOfWork.
	/// </summary>
	/// <typeparam name="TContext">Тип контекста базы данных.</typeparam>
	public class UnitOfWork<TContext> : IDisposable where TContext : DbContext
	{
		#region Data
		#region Fields
		private readonly TContext _dbContext;
		private readonly IDbContextTransaction _transaction;
		#endregion
		#endregion

		#region .ctor
		/// <summary>
		/// Инициализирует новый экземпляр типа <see cref="T:Dispatching.Dal.UnitOfWork`1" />.
		/// </summary>
		/// <param name="dbContext">Контекст базы данных.</param>
		/// <exception cref="T:System.ArgumentNullException">Значение <paramref name="dbContext" /> не задано.</exception>
		public UnitOfWork(TContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
			_transaction = dbContext.Database.BeginTransaction();
		}
		#endregion

		#region Public
		/// <summary>Сохраняет изменения.</summary>
		public void Commit() =>
			CommitAsync()
				.GetAwaiter()
				.GetResult();

		/// <summary>Сохраняет изменения.</summary>
		/// <param name="cancellationToken"></param>
		public async Task CommitAsync(CancellationToken cancellationToken = default)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
			await _transaction.CommitAsync(cancellationToken);
		}
		#endregion

		#region IDisposable members
		public void Dispose() => _transaction.Dispose();
		#endregion
	}
}
