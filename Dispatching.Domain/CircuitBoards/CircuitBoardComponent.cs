using Dispatching.Domain.Common;

namespace Dispatching.Domain.CircuitBoards;

/// <summary>
/// Представляет компонент.
/// </summary>
public class CircuitBoardComponent : IEntity
{
	#region .ctor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public CircuitBoardComponent()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	{
	}

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CircuitBoardComponent" />.
	/// </summary>
	/// <param name="id"></param>
	/// <param name="name"></param>
	public CircuitBoardComponent(Guid id, string name)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);
		Id = id;
		Name = name;
	}
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает наименование компонента.
	/// </summary>
	public string Name
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
