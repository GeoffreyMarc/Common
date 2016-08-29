using Common.Core.Exceptions;
using Common.Interfaces.CQRS;
using SimpleInjector;

namespace CQRS.MVC5.Infrastructure
{
    /// <summary>
    /// Implémentation de l'interface <see cref="ICommandQueryDispatcher"/> basée sur le conteneur d'injection de dépendances SimpleInjector.
    /// </summary>
    public class SimpleInjectorCommandQueryDispatcher : ICommandQueryDispatcher
    {
        /// <summary>
        /// Container d'injection de dépendances SimpleInjector.
        /// </summary>
        private Container _container;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="SimpleInjectorCommandQueryDispatcher"/>.
        /// </summary>
        /// <param name="container">Container SimpleInjector.</param>
        public SimpleInjectorCommandQueryDispatcher(Container container)
        {
            _container = container;
        }

        /// <summary>
        /// Dispatche une commande vers son handler.
        /// </summary>
        /// <typeparam name="TCommand">Type de la commande.</typeparam>
        /// <param name="command">Commande.</param>
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _container.GetInstance<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new MissingHandlerException($"Aucun handler n'est enregistré pour gérer les commandes de type {typeof(TCommand).Name}.");

            handler.Handle(command);
        }

        /// <summary>
        /// Dispatche une requête vers sont handler.
        /// </summary>
        /// <typeparam name="TQuery">Type de la requête.</typeparam>
        /// <typeparam name="TQueryResult">Type du résultat de la requête.</typeparam>
        /// <param name="query">Requête.</param>
        /// <returns>Résultat de la requête.</returns>
        public TQueryResult Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
        {
            var handler = _container.GetInstance<IQueryHandler<TQuery, TQueryResult>>();

            if (handler == null)
                throw new MissingHandlerException($"Aucun handler n'est enregistré pour gérer les requêtes de type {typeof(TQuery).Name}.");

            return handler.Handle(query);
        }
    }
}