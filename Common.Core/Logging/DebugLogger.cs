using System;
using Common.Interfaces.Logging;

namespace Common.Core.Logging
{
    /// <summary>
    /// Implémentation de l'interface <see cref="ILogger" /> qui écrit dans la console de debug de Visual Studio en mode DEBUG uniquement.
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Le mode Debug est-il loggé ?
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Le mode Error est-il loggé ?
        /// </summary>
        public bool IsErrorEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Le mode Fatal est-il loggé ?
        /// </summary>
        public bool IsFatalEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Le mode Info est-il loggé ?
        /// </summary>
        public bool IsInfoEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Le mode Trace est-il loggé ?
        /// </summary>
        public bool IsTraceEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Le mode Warn est-il loggé ?
        /// </summary>
        public bool IsWarnEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Log une exception en mode Debug.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Debug(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Debug.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Debug(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[DEBUG] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Debug.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Debug(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[DEBUG] {0}", format), args, exception);
        }

        /// <summary>
        /// Log une exception en mode Error.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Error(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[ERROR] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Error.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Error(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[ERROR] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Error.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Error(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[ERROR] {0}", format), args, exception);
        }

        /// <summary>
        /// Log une exception en mode Fatal.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Fatal(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[FATAL] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Fatal.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Fatal(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[FATAL] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Fatal.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Fatal(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[FATAL] {0}", format), args, exception);
        }

        /// <summary>
        /// Log une exception en mode Info.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Info(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[INFO] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Info.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Info(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[INFO] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Info.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Info(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[INFO] {0}", format), args, exception);
        }

        /// <summary>
        /// Log une exception en mode Trace.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Trace(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[TRACE] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Trace.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Trace(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[TRACE] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Trace.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Trace(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[TRACE] {0}", format), args, exception);
        }

        /// <summary>
        /// Log une exception en mode Warn.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        public void Warn(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("[WARNING] {0}", exception);
        }

        /// <summary>
        /// Log un message paramétré en mode Warn.
        /// </summary>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Warn(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[WARNING] {0}", format), args);
        }

        /// <summary>
        /// Log une exception ainsi qu'un message paramétré en mode Warn.
        /// </summary>
        /// <param name="exception">L'exception à logger.</param>
        /// <param name="format">Format du message.</param>
        /// <param name="args">Paramètres du message.</param>
        public void Warn(Exception exception, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[WARNING] {0}", format), args, exception);
        }
    }
}
