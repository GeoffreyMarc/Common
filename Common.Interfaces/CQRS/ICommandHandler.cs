namespace Common.Interfaces.CQRS
{
    /// <summary>
    /// Représente un handler pour une <see cref="ICommand"/>.
    /// </summary>
    /// <typeparam name="TCommand">Type de la commande.</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Gère le traitement demandé par la commande.
        /// </summary>
        /// <param name="command">Commande à traiter.</param>
        void Handle(TCommand command);
    }
}
