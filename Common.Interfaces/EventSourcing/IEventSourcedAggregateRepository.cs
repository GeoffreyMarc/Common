using System;

namespace Common.Interfaces.EventSourcing
{
	/// <summary>
	/// Interface pour les dépôts d'aggrégats basés sur des évènements du domaine.
	/// </summary>
	public interface IEventSourcedAggregateRepository
	{
		/// <summary>
		/// Générateur en charge de la création des aggrégats.
		/// </summary>
		IEventSourcedAggregateFactory AggregateFactory { get; }

		/// <summary>
		/// Recherche un aggrégat à partir de son identifiant.
		/// </summary>
		/// <typeparam name="T">Type de l'aggrégat.</typeparam>
		/// <param name="id">Identifiant de l'aggrégat.</param>
		/// <returns>Instance de l'aggrégat chargée depuis l'infrastructure de stockage si il existe, ou
		/// nouvelle instance de l'aggrégat si il n'existe pas.</returns>
		T GetById<T>(Guid id) where T : IEventSourcedAggregate;

		/// <summary>
		/// Enregistre un aggrégat dans l'infrastructure de stockage sous-jacente.
		/// </summary>
		/// <param name="aggregate">Aggrégat à enregistrer.</param>
		void Save(IEventSourcedAggregate aggregate);
	}
}
