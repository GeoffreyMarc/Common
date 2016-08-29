namespace Common.Interfaces.CQRS
{
    /// <summary>
    /// Représente un handler pour une <see cref="IQuery{TResult}"/>.
    /// </summary>
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Gère le traitement de la requête afin d'obtenir un résultat.
        /// </summary>
        /// <param name="query">Requête à traiter.</param>
        /// <returns>Résultat de la requête.</returns>
        TResult Handle(TQuery query);
    }
}
