﻿namespace Dispatching.Domain.CircuitBoards;

public interface ICircuitBoardRepository
{
	#region Overridable
	/// <summary>
	/// Добавляет плату.
	/// </summary>
	/// <param name="circuitBoard"></param>
	Task<int> Add(CircuitBoard circuitBoard);

	/// <summary>
	/// Возвращает плату по идентификатору.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	Task<CircuitBoard?> FindAsync(Guid circuitBoardId);

	/// <summary>
	/// Возвращает платы по идентификаторам.
	/// </summary>
	/// <param name="circuitBoardIds">Идентификаторы плат.</param>
	IEnumerable<CircuitBoard> FindRange(IEnumerable<Guid> circuitBoardIds);

	/// <summary>
	/// Обновляет данные по платам.
	/// </summary>
	Task<int> UpdateAsync();
	#endregion
}