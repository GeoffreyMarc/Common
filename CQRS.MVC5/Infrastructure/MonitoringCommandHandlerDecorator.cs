using Common.Interfaces.CQRS;
using Common.Interfaces.Logging;
using Newtonsoft.Json;
using System;

namespace CQRS.MVC5.Infrastructure
{
    /// <summary>
    /// Décorateur permettant de tracer le contenu et le temps d'exécution des requêtes.
    /// </summary>
    /// <typeparam name="TQuery">Type de la requête.</typeparam>
    /// <typeparam name="TQueryResult">Type du résultat de la requête.</typeparam>
    public class MonitoringCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Instance de logger.
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Handle décoré.
        /// </summary>
        private readonly ICommandHandler<TCommand> _decoratedHandler;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MonitoringCommandHandlerDecorator{TCommand}"/>.
        /// </summary>
        /// <param name="logger">Instance de logger.</param>
        /// <param name="decoratedHandler">Handler décoré.</param>
        public MonitoringCommandHandlerDecorator(ILogger logger, ICommandHandler<TCommand> decoratedHandler)
        {
            _logger = logger;
            _decoratedHandler = decoratedHandler;
        }

        /// <summary>
        /// Enregistre le temps d'exécution et le contenu de la commande (format JSON) dans les logs.
        /// </summary>
        /// <param name="command">Commande.</param>
        public void Handle(TCommand command)
        {
            string commandType = typeof(TCommand).Name;
            string commandValues;

            try
            {
                commandValues = JsonConvert.SerializeObject(command, Formatting.None);
            }
            catch (Exception)
            {
                commandValues = $"Impossible de sérialiser les commandes de type {commandType}.";
            }

            _logger.Trace($"Execution d'une commande de type {commandType} : {commandValues}");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            _decoratedHandler.Handle(command);

            _logger.Trace($"Temps de traitement de la commande de type {commandType} : {sw.Elapsed}.");
        }
    }
}