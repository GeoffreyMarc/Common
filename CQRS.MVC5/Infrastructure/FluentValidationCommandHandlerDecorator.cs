using Common.Interfaces.CQRS;
using FluentValidation;
using System.Linq;

namespace CQRS.MVC5.Infrastructure
{
    /// <summary>
    /// Décorateur basé sur FluentValidation et permettant de valider des commandes avant leur traitement.
    /// En cas d'erreurs de validation, un exception <see cref="ValidationException"/> sera levée avec les 
    /// erreurs de validation.
    /// </summary>
    /// <typeparam name="TCommand">Type de la commande.</typeparam>
    public class FluentValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Liste des validateurs pour ce type de commande.
        /// </summary>
        private readonly IValidator<TCommand>[] _validators;
        /// <summary>
        /// Handler décoré.
        /// </summary>
        private readonly ICommandHandler<TCommand> _decoratedHandler;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FluentValidationCommandHandlerDecorator{TCommand}"/>.
        /// </summary>
        /// <param name="validators">Liste des validateurs pour ce type de commande.</param>
        /// <param name="decoratedHandler">Handler décoré.</param>
        public FluentValidationCommandHandlerDecorator(IValidator<TCommand>[] validators, ICommandHandler<TCommand> decoratedHandler)
        {
            _validators = validators;
            _decoratedHandler = decoratedHandler;
        }

        /// <summary>
        /// Gère la validation de la commande.
        /// </summary>
        /// <param name="command">Commande.</param>
        public void Handle(TCommand command)
        {
            if (_validators != null)
            {
                // On vérifie la validité de la commande
                var context = new ValidationContext(command);

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

            // Arrivé ici, c'est valide, on passe la commande au handler décoré
            _decoratedHandler.Handle(command);
        }
    }
}