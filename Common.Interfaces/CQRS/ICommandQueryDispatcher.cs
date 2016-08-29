namespace Common.Interfaces.CQRS
{
    /// <summary>
    /// Médiateur permettant de transférer les <see cref="ICommand"/> et les <see cref="IQuery{TResult}"/> vers leurs handlers respectifs.
    /// </summary>
    public interface ICommandQueryDispatcher
    {
        /// <summary>
        /// Dispatche une commande vers son handler.
        /// </summary>
        /// <typeparam name="TCommand">Type de la commande.</typeparam>
        /// <param name="command">Commande.</param>
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Dispatche une requête vers sont handler.
        /// </summary>
        /// <typeparam name="TQuery">Type de la requête.</typeparam>
        /// <typeparam name="TQueryResult">Type du résultat de la requête.</typeparam>
        /// <param name="query">Requête.</param>
        /// <returns>Résultat de la requête.</returns>
        TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>;
    }
}
