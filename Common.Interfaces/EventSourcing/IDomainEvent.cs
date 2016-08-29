using System;

namespace Common.Interfaces.EventSourcing
{
	/// <summary>
	/// Représente un évènement du domaine.
	/// </summary>
	public interface IDomainEvent
	{
		/// <summary>
		/// Identifiant de l'aggrégat source.
		/// </summary>
		Guid AggregateRootId { get; }

		/// <summary>
		/// Date et heure de l'évènement.
		/// </summary>
		DateTime TimeStamp { get; }
	}
}
