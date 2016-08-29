using System;

namespace Common.Interfaces.DDD
{
    /// <summary>
    /// Interface pour les dépôts d'aggrégats.
    /// </summary>
    public interface IAggregateRepository
    {
        /// <summary>
        /// Générateur en charge de la création des aggrégats.
        /// </summary>
        IAggregateFactory AggregateFactory { get; }

        /// <summary>
        /// Recherche un aggrégat à partir de son identifiant.
        /// </summary>
        /// <typeparam name="T">Type de l'aggrégat.</typeparam>
        /// <param name="id">Identifiant de l'aggrégat.</param>
        /// <returns>Instance de l'aggrégat chargée depuis l'infrastructure de stockage si il existe, ou
        /// nouvelle instance de l'aggrégat si il n'existe pas.</returns>
        T GetById<T>(Guid id) where T : IAggregate;

        /// <summary>
        /// Enregistre un aggrégat dans l'infrastructure de stockage sous-jacente.
        /// </summary>
        /// <param name="aggregate">Aggrégat à enregistrer.</param>
        void Save(IAggregate aggregate);
    }
}
