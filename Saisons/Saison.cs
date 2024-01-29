using System;

namespace TopScore.Saisons
{
    /// <summary>
    /// Saison dans laquelle les parties ont lieu
    /// </summary>
    internal class Saison
    {
        /// <summary>
        /// Date de début de la saison
        /// </summary>
        public DateOnly Debut { get; set; }

        /// <summary>
        /// Date de fin de la saison
        /// </summary>
        public DateOnly Fin { get; set; }
    }
}
