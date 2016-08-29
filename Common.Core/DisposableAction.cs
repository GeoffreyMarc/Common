using System;
using System.Threading;

namespace Common.Core
{
    /// <summary>
    /// Classe utilitaire permettant d'englober une continuation (la suite des instructions) dans un IDisposable.
    /// Ex : 
    /// <code>
    ///		int x = 0;
    ///		var resetX = new DisposableAction(() => x = 2);
    ///		using (resetX) {
    ///			System.Console.WriteLine("Valeur de x : {0}", x);
    ///			x = 5;
    ///			System.Console.WriteLine("Valeur de x : {0}", x);
    ///		}
    ///		System.Console.WriteLine("Valeur de x : {0}", x);
    /// </code>
    /// L'affichage sera :
    ///		Valeur de x : 0
    ///		Valeur de x : 5
    ///		Valeur de x : 2
    /// </summary>
    public class DisposableAction : IDisposable
    {
        /// <summary>
        /// Action à exécuter dans le dispose.
        /// </summary>
        private Action _disposeAction;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DisposableAction"/>.
        /// </summary>
        /// <param name="disposeAction">Action à exécuter lors du dispose.</param>
        public DisposableAction(Action disposeAction)
        {
            if (disposeAction == null) throw new ArgumentNullException("action");

            _disposeAction = disposeAction;
        }

        /// <summary>
        /// Sur le dispose, on exécute l'action.
        /// </summary>
        public void Dispose()
        {
            // Utilisation d'Interlocked pour être thread-safe et s'assurer que l'action
            // n'est exécutée qu'une seule fois.
            Interlocked.Exchange(ref _disposeAction, null)?.Invoke();
        }
    }
}
