using System.Collections.Generic;
using Common.Interfaces.DDD;

namespace Common.Interfaces.EventSourcing
{
	/// <summary>
	/// Interface de base pour les aggrégats basés sur des évènements du domaine.
	/// </summary>
	public interface IEventSourcedAggregate : IAggregate
	{
		/// <summary>
		/// Version.
		/// </summary>
		int Version { get; }

		/// <summary>
		/// Applique un évènement du domaine à l'aggrégat.
		/// </summary>
		/// <param name="event">Evènement du domaine.</param>
		void ApplyEvent(IDomainEvent @event);

		/// <summary>
		/// Obtient la liste des évènements du domaine non enregistrés de l'aggrégat.
		/// </summary>
		/// <returns>Liste des évènements du domaine non enregistrés de l'aggrégat.</returns>
		IEnumerable<IDomainEvent> GetUncommittedEvents();

		/// <summary>
		/// Vide la liste des évènements du domaine non enregistrés.
		/// </summary>
		void ClearUncommittedEvents();
	}
}
