using Dispatching.Domain.CircuitBoards;

namespace Dispatching.Service.Helpers;

public class CircuitBoardFindHelper
{
	/// <summary>
	/// Возвращает плату.
	/// </summary>
	/// <param name="CircuitBoardId">Идентфикиатор платы.</param>
	/// <param name="circuitBoardRepository"><see cref="ICircuitBoardRepository" />.</param>
	/// <returns>Плата, если найдена.</returns>
	/// <exception cref="EntityNotFoundException">Если плата не найдена.</exception>
	public static async Task<CircuitBoard?> GetCircuitBoardAsync(Guid CircuitBoardId, ICircuitBoardRepository circuitBoardRepository)
	{
		var circuitBoard = await circuitBoardRepository.FindAsync(CircuitBoardId);
		if (circuitBoard == null)
		{
			throw new EntityNotFoundException("Плата", CircuitBoardId.ToString());
		}

		return circuitBoard;
	}
}
