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
    public class MonitoringQueryHandlerDecorator<TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult> 
        where TQuery : IQuery<TQueryResult>
    {
        /// <summary>
        /// Instance de logger.
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Handle décoré.
        /// </summary>
        private readonly IQueryHandler<TQuery, TQueryResult> _decoratedHandler;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MonitoringQueryHandlerDecorator{TQuery, TQueryResult}"/>.
        /// </summary>
        /// <param name="logger">Instance de logger.</param>
        /// <param name="decoratedHandler">Handler décoré.</param>
        public MonitoringQueryHandlerDecorator(ILogger logger, IQueryHandler<TQuery, TQueryResult> decoratedHandler)
        {
            _logger = logger;
            _decoratedHandler = decoratedHandler;
        }

        /// <summary>
        /// Enregistre le temps d'exécution et le contenu de la requête (format JSON) dans les logs.
        /// </summary>
        /// <param name="query">Requête.</param>
        /// <returns>Résultat de la requête.</returns>
        public TQueryResult Handle(TQuery query)
        {
            string queryType = typeof(TQuery).Name;
            string queryValues;

            try
            {
                queryValues = JsonConvert.SerializeObject(query, Formatting.None);
            }
            catch (Exception)
            {
                queryValues = $"Impossible de sérialiser les requêtes de type {queryType}.";
            }

            _logger.Trace($"Execution d'une requête de type {queryType} : {queryValues}");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            var result = _decoratedHandler.Handle(query);

            _logger.Trace($"Temps de traitement de la requête de type {queryType} : {sw.Elapsed}.");

            return result;
        }
    }
}