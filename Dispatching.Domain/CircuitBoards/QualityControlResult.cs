namespace Dispatching.Domain.CircuitBoards;

/// <summary>
/// Представляет результат контроля качества.
/// </summary>
public enum QualityControlResult
{
	/// <summary>
	/// Годная.
	/// </summary>
	Good,

	/// <summary>
	/// Негодная.
	/// </summary>
	NoGood,
}
