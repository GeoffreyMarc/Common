using System;

namespace Common.Interfaces.Logging
{
    /// <summary>
    /// Interface représentant un logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Le mode Debug est-il loggé ?
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Le mode Error est-il loggé ?
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Le mode Fatal est-il loggé ?
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Le mode Info est-il loggé ?
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Le mode Trace est-il loggé ?
        /// </summary>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Le mode Warn est-il loggé ?
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Log une exception en mode Debug.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Debug(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Debug.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Debug.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Debug(Exception exception, string format, params object[] args);

        /// <summary>
        /// Log une exception en mode Error.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Error(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Error.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Error.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Error(Exception exception, string format, params object[] args);

        /// <summary>
        /// Log une exception en mode Fatal.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Fatal(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Fatal.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Fatal(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Fatal.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Fatal(Exception exception, string format, params object[] args);

        /// <summary>
        /// Log une exception en mode Info.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Info(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Info.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Info.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Info(Exception exception, string format, params object[] args);

        /// <summary>
        /// Log une exception en mode Trace.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Trace(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Trace.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Trace.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Trace(Exception exception, string format, params object[] args);

        /// <summary>
        /// Log une exception en mode Warn.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        void Warn(Exception exception);

        /// <summary>
        /// Log un message paramétré en mode Warn.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Warn.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        void Warn(Exception exception, string format, params object[] args);
    }
}