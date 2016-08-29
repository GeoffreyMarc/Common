using Common.Interfaces.CQRS;
using FluentValidation;
using System.Linq;

namespace CQRS.MVC5.Infrastructure
{
    /// <summary>
    /// Décorateur basé sur FluentValidation et permettant de valider des requêtes avant leur traitement.
    /// En cas d'erreurs de validation, un exception <see cref="ValidationException"/> sera levée avec les 
    /// erreurs de validation.
    /// </summary>
    /// <typeparam name="TQuery">Type de la requête.</typeparam>
    /// <typeparam name="TQueryResult">Type du résultat de la requête.</typeparam>
    public class FluentValidationQueryHandlerDecorator<TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
        /// <summary>
        /// Liste des validateurs pour ce type de requête.
        /// </summary>
        private readonly IValidator<TQuery>[] _validators;
        /// <summary>
        /// Handler décoré.
        /// </summary>
        private readonly IQueryHandler<TQuery, TQueryResult> _decoratedHandler;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FluentValidationQueryHandlerDecorator{TQuery, TQueryResult}"/>.
        /// </summary>
        /// <param name="validators">Liste des validateurs pour ce type de requête.</param>
        /// <param name="decoratedHandler">Handler décoré.</param>
        public FluentValidationQueryHandlerDecorator(IValidator<TQuery>[] validators, IQueryHandler<TQuery, TQueryResult> decoratedHandler)
        {
            _validators = validators;
            _decoratedHandler = decoratedHandler;
        }

        /// <summary>
        /// Gère la validation de la requête.
        /// </summary>
        /// <param name="query">Requête.</param>
        /// <returns>Résultat de la requête si elle est valide, sinon lève une <see cref="ValidationException"/> avec les erreurs.</returns>
        public TQueryResult Handle(TQuery query)
        {
            if (_validators != null)
            {
                // On vérifie la validité de la requête
                var context = new ValidationContext(query);

                // Extraction des erreurs potentielles
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(error => error != null)
                    .ToList();

                // Exception en cas d'erreur
                if (failures.Any())
                    throw new ValidationException(failures);
            }

            // Arrivé ici, c'est valide, on passe la requête au handler décoré
            return _decoratedHandler.Handle(query);
        }
    }
}