using System;

namespace Common.Interfaces.DDD
{
	/// <summary>
	/// Interface pour les aggrégats.
	/// </summary>
	public interface IAggregate
	{
		/// <summary>
		/// Identifiant unique.
		/// </summary>
		Guid Id { get; }
	}
}
