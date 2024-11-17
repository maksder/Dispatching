using MediatR;

namespace Dispatching.Service.UseCase;

/// <summary>
/// Представляет команду создания платы.
/// </summary>
public class CreateCircuitBoardCommand : IRequest<Guid>
{
	#region .ctor
	public CreateCircuitBoardCommand(string name) => Name = name;
	#endregion

	#region Properties
	public string Name
	{
		get;
	}
	#endregion
}
