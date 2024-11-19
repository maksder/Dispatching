using Dispatching.Domain.CircuitBoards;
using MediatR;

namespace Dispatching.Service.UseCase.GetCircuitBoard;

/// <summary>
/// Представляет запрос платы.
/// </summary>
public class CircuitBoardQuery : IRequest<CircuitBoard?>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CircuitBoardQuery" />.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	public CircuitBoardQuery(Guid id) => Id = id;
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает идентификатор платы.
	/// </summary>
	public Guid Id
	{
		get;
	}
	#endregion
}
