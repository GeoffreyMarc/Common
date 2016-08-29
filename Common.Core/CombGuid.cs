using System;

namespace Common.Core
{
    /// <summary>
    /// Classe utilitaire permettant d'obtenir des 'CombGuid', c'est à dire des Guid séquentiels ayant une répartition 
    /// beaucoup plus mesurée permettant une indexation plus performante.
    /// </summary>
    public static class CombGuid
    {
        /// <summary>
        /// Représente un <see cref="CombGuid"/> vide.
        /// </summary>
        public static readonly Guid Empty = Guid.Parse("00000000-0000-0000-0000-000000000000");

        /// <summary>
        /// Génère un nouveau Guid séquentiel.
        /// </summary>
        /// <returns>Instance de <see cref="Guid"/>.</returns>
        public static Guid NewCombGuid()
        {
            return _generator();
        }

        /// <summary>
        /// Remet à zéro le générateur de Guid séquentiels.
        /// </summary>
        public static void Reset()
        {
            _generator = GeneratorCore;
        }

        /// <summary>
        /// Remplace le générateur de Guid séquentiels par une valeur fixe jusqu'au relachement.
        /// </summary>
        /// <param name="value">Valeur fixe à utiliser.</param>
        /// <returns><see cref="IDisposable"/> qui réinitialisera le générateur une fois relaché.</returns>
        public static IDisposable Stub(Guid value)
        {
            _generator = () => value;
            return new DisposableAction(Reset);
        }

        /// <summary>
        /// Générateur de Guid séquentiels.
        /// </summary>
        private static readonly Func<Guid> GeneratorCore = () =>
        {
            var destinationArray = Guid.NewGuid().ToByteArray();
            var time = new DateTime(1900, 1, 1);
            var now = DateTime.UtcNow;
            var span = new TimeSpan(now.Ticks - time.Ticks);
            var timeOfDay = now.TimeOfDay;
            var bytes = BitConverter.GetBytes(span.Days);
            var array = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333));
            Array.Reverse(bytes);
            Array.Reverse(array);
            Array.Copy(bytes, bytes.Length - 2, destinationArray, destinationArray.Length - 6, 2);
            Array.Copy(array, array.Length - 4, destinationArray, destinationArray.Length - 4, 4);
            return new Guid(destinationArray);
        };

        /// <summary>
        /// Référence vers le générateur séquentiel.
        /// </summary>
        private static Func<Guid> _generator = GeneratorCore;
    }
}
