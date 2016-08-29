using System;

namespace Common.Core.Exceptions
{
    /// <summary>
    /// Exception lancée lorsqu'aucun handler n'est trouvé pour gérer un message (IQuery, ICommand, etc.).
    /// </summary>
    public class MissingHandlerException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MissingHandlerException"/>.
        /// </summary>
        public MissingHandlerException() : base()
        { }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MissingHandlerException"/>.
        /// </summary>
        /// <param name="message">Message décrivant l'exception.</param>
        public MissingHandlerException(string message) : base(message)
        { }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MissingHandlerException"/>.
        /// </summary>
        /// <param name="message">Message décrivant l'exception.</param>
        /// <param name="innerException">Exception interne ayant causée l'exception.</param>
        public MissingHandlerException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
