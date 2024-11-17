namespace Dispatching.Domain.CircuitBoards;

/// <summary>
/// Представляет статус платы.
/// </summary>
public enum CircuitBoardStatus
{
	/// <summary>
	/// Создана.
	/// </summary>
	Created,

	/// <summary>
	/// В работе.
	/// </summary>
	InWorking,

	/// <summary>
	/// На контроле качества.
	/// </summary>
	InQualityControl,

	/// <summary>
	/// В ремонте.
	/// </summary>
	InRepair,

	/// <summary>
	/// Упакована.
	/// </summary>
	Packed,
}
