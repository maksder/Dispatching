using MediatR;

namespace Dispatching.Service.UseCase.AddComponent;

/// <summary>
/// Представляет команду добавления элемента на плату.
/// </summary>
public class AddComponentForCircuitBoardCommand : IRequest<bool>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="AddComponentForCircuitBoardCommand" />.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	/// <param name="componentName">Наименование компонента.</param>
	public AddComponentForCircuitBoardCommand(Guid circuitBoardId, string componentName)
	{
		CircuitBoardId = circuitBoardId;
		ComponentName = componentName;
	}
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает идентификатор платы.
	/// </summary>
	public Guid CircuitBoardId
	{
		get;
	}
	/// <summary>
	/// Возвращает наименование компонента.
	/// </summary>
	public string ComponentName
	{
		get;
	}
	#endregion
}
