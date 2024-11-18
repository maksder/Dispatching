using MediatR;

namespace Dispatching.Service.UseCase.Create;

/// <summary>
/// Представляет команду создания платы.
/// </summary>
public class CreateCircuitBoardCommand : IRequest<Guid>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CreateCircuitBoardCommand" />.
	/// </summary>
	/// <param name="name">Наименование платы.</param>
	public CreateCircuitBoardCommand(string name) => Name = name;
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает наименование платы.
	/// </summary>
	public string Name
	{
		get;
	}
	#endregion
}
