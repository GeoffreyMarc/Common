using System;

namespace Common.Interfaces.EventSourcing
{
	/// <summary>
	/// Interface pour les générateurs d'aggrégats basés sur des évènements du domaine.
	/// </summary>
	public interface IEventSourcedAggregateFactory
	{
		/// <summary>
		/// Génère une nouvelle instance d'un aggrégat dans son état initial.
		/// </summary>
		/// <typeparam name="T">Type de l'aggrégat.</typeparam>
		/// <param name="id">Identifiant de l'aggrégat.</param>
		/// <returns>Nouvelle instance de l'aggrégat.</returns>
		T Create<T>(Guid id) where T : IEventSourcedAggregate;
	}
}
